"""WinForms gerektirmeden, uygulamaya gömülen gerçek SQLite şemasını sınar."""
import sqlite3
import tempfile
import unittest
from pathlib import Path

SEMA = (Path(__file__).resolve().parents[1] / 'src/MttSinema/Veri/Sema.sql').read_text(encoding='utf-8')
GUN = '2026-11-18'


class SemaTestleri(unittest.TestCase):
    def setUp(self):
        gecici = tempfile.TemporaryDirectory()
        self.addCleanup(gecici.cleanup)
        self.yol = Path(gecici.name) / 'sinema.db'
        self.db = self.baglan()
        self.db.executescript(SEMA)
        self.db.execute("INSERT INTO film(ad, ad_anahtari, tur, sure_dk, ucret_kr) VALUES ('Ada','ADA','Dram',90,9000)")
        self.db.execute("INSERT INTO salon(ad, ad_anahtari, kapasite) VALUES ('Mavi','MAVİ',24), ('Yeşil','YEŞİL',12)")
        self.saat = self.aralik(600, 690)

    def baglan(self):
        db = sqlite3.connect(self.yol)
        db.execute('PRAGMA foreign_keys=ON')
        self.addCleanup(db.close)
        return db

    def aralik(self, basla, bitir):
        return self.db.execute('INSERT INTO saat_araligi(baslangic_dk, bitis_dk) VALUES (?,?)', (basla, bitir)).lastrowid

    def planla(self, saat=None, gun=GUN, salon=1):
        return self.db.execute('INSERT INTO seans(tarih, film_id, salon_id, saat_id) VALUES (?,1,?,?)',
                               (gun, salon, self.saat if saat is None else saat)).lastrowid

    def bilet(self, seans, koltuk, fiyat=9000):
        return self.db.execute('INSERT INTO bilet(seans_id, koltuk_no, ucret_kr) VALUES (?,?,?)', (seans, koltuk, fiyat)).lastrowid

    def test_surumu_ve_kapanistan_sonra_kayitlari_korur(self):
        self.bilet(self.planla(), 3)
        self.db.commit()
        self.db.close()
        db = self.baglan()
        self.assertEqual(db.execute('PRAGMA user_version').fetchone(), (1,))
        self.assertEqual(db.execute('PRAGMA foreign_key_check').fetchall(), [])
        self.assertEqual(db.execute('SELECT satilan, gelir_kr FROM seans_ozeti').fetchone(), (1, 9000))

    def test_kesisim_ve_sinir_anlari(self):
        self.planla()
        # Aynı aralık, iki taraftan kısmi kesişme ve kapsayan aralık reddedilmeli.
        for saat in (self.saat, self.aralik(570, 660), self.aralik(660, 750), self.aralik(550, 760)):
            with self.subTest(saat=saat), self.assertRaisesRegex(sqlite3.IntegrityError, 'çakışan'):
                self.planla(saat)
        self.planla(self.aralik(690, 780))
        self.planla(salon=2)
        self.planla(gun='2026-11-19')
        self.assertEqual(self.db.execute('SELECT count(*) FROM seans').fetchone(), (4,))

    def test_sure_ve_saat_kurallari(self):
        with self.assertRaisesRegex(sqlite3.IntegrityError, 'sığmıyor'):
            self.planla(self.aralik(700, 789))
        self.planla()  # Eşit süre sığar.
        with self.assertRaisesRegex(sqlite3.IntegrityError, 'sığmıyor'):
            self.db.execute('UPDATE film SET sure_dk=91')
        for basla, bitir in ((600, 690), (600, 600), (700, 600), (-1, 120), (1380, 1441)):
            with self.subTest(aralik=(basla, bitir)), self.assertRaises(sqlite3.IntegrityError):
                self.aralik(basla, bitir)

    def test_gecersiz_tarih_ve_sayisal_degerler(self):
        for gun in ('2026-02-30', '18.11.2026', '2026-11-18 10:00', ''):
            with self.subTest(gun=gun), self.assertRaises(sqlite3.IntegrityError):
                self.planla(gun=gun)
        for sql in ("UPDATE film SET ad='  '", 'UPDATE film SET sure_dk=29', 'UPDATE film SET ucret_kr=-1',
                    'UPDATE film SET ucret_kr=10.5', 'UPDATE salon SET kapasite=9'):
            with self.subTest(sql=sql), self.assertRaises(sqlite3.IntegrityError):
                self.db.execute(sql)

    def test_koltuk_bir_kez_ve_kapasite_icinde_satilir(self):
        seans = self.planla()
        self.bilet(seans, 24)
        for koltuk in (24, 0, 25):
            with self.subTest(koltuk=koltuk), self.assertRaises(sqlite3.IntegrityError):
                self.bilet(seans, koltuk)
        with self.assertRaisesRegex(sqlite3.IntegrityError, 'kapasite'):
            self.db.execute('UPDATE salon SET kapasite=23 WHERE id=1')
        self.bilet(self.planla(gun='2026-11-19'), 24)

    def test_bagli_kayitlar_silinemez(self):
        seans = self.planla()
        self.bilet(seans, 1)
        for sql in ('DELETE FROM film', 'DELETE FROM salon', 'DELETE FROM saat_araligi', 'DELETE FROM seans'):
            with self.subTest(sql=sql), self.assertRaises(sqlite3.IntegrityError):
                self.db.execute(sql)
        with self.assertRaises(sqlite3.IntegrityError):
            self.bilet(seans + 1, 1)
        self.db.execute('DELETE FROM bilet')
        self.db.execute('DELETE FROM seans')
        self.db.execute('DELETE FROM film')
        self.assertEqual(self.db.execute('PRAGMA foreign_key_check').fetchall(), [])

    def test_hasilat_gosterim_gunune_ve_bilet_fiyatina_aittir(self):
        seans = self.planla()
        self.planla(gun='2026-11-19')
        bilet = self.bilet(seans, 1, 12345)
        self.bilet(seans, 2, 12000)
        self.db.execute('UPDATE film SET ucret_kr=15000')
        sql = 'SELECT satilan, gelir_kr FROM seans_ozeti ORDER BY tarih'
        self.assertEqual(self.db.execute(sql).fetchall(), [(2, 24345), (0, 0)])
        self.db.execute('DELETE FROM bilet WHERE id=?', (bilet,))
        self.assertEqual(self.db.execute(sql).fetchall(), [(1, 12000), (0, 0)])
        self.bilet(seans, 1, 15000)
        self.assertEqual(self.db.execute(sql).fetchall(), [(2, 27000), (0, 0)])

    def test_plan_ve_bilet_yerinde_degistirilemez(self):
        self.bilet(self.planla(), 1)
        for sql in ('UPDATE seans SET salon_id=2', 'UPDATE bilet SET koltuk_no=1000',
                    'UPDATE saat_araligi SET bitis_dk=baslangic_dk+1'):
            with self.subTest(sql=sql), self.assertRaises(sqlite3.IntegrityError):
                self.db.execute(sql)


if __name__ == '__main__':
    unittest.main()
