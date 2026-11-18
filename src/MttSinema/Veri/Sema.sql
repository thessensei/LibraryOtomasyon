-- Sürüm 1. Uygulama bu dosyayı ilk açılışta tek işlem içinde çalıştırır.
-- Saatler gece yarısından itibaren dakika, parasal tutarlar kuruş cinsindendir.
CREATE TABLE film (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    ad TEXT NOT NULL CHECK (length(trim(ad)) BETWEEN 1 AND 120),
    ad_anahtari TEXT NOT NULL UNIQUE,
    tur TEXT NOT NULL CHECK (length(trim(tur)) > 0),
    sure_dk INTEGER NOT NULL CHECK (sure_dk BETWEEN 30 AND 1439),
    ucret_kr INTEGER NOT NULL CHECK (ucret_kr BETWEEN 0 AND 99999999)
) STRICT;

CREATE TABLE salon (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    ad TEXT NOT NULL CHECK (length(trim(ad)) BETWEEN 1 AND 120),
    ad_anahtari TEXT NOT NULL UNIQUE,
    kapasite INTEGER NOT NULL CHECK (kapasite BETWEEN 10 AND 9999)
) STRICT;

CREATE TABLE saat_araligi (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    baslangic_dk INTEGER NOT NULL CHECK (baslangic_dk BETWEEN 0 AND 1438),
    bitis_dk INTEGER NOT NULL CHECK (bitis_dk > baslangic_dk AND bitis_dk < 1440),
    UNIQUE (baslangic_dk, bitis_dk)
) STRICT;

CREATE TABLE seans (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    tarih TEXT NOT NULL CHECK (date(tarih, '+0 days') IS NOT NULL AND tarih = date(tarih, '+0 days')),
    film_id INTEGER NOT NULL REFERENCES film(id) ON DELETE RESTRICT,
    salon_id INTEGER NOT NULL REFERENCES salon(id) ON DELETE RESTRICT,
    saat_id INTEGER NOT NULL REFERENCES saat_araligi(id) ON DELETE RESTRICT,
    UNIQUE (tarih, salon_id, saat_id)
) STRICT;
CREATE INDEX seans_film ON seans(film_id);
CREATE INDEX seans_salon ON seans(salon_id);
CREATE INDEX seans_saat ON seans(saat_id);

CREATE TABLE bilet (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    seans_id INTEGER NOT NULL REFERENCES seans(id) ON DELETE RESTRICT,
    koltuk_no INTEGER NOT NULL CHECK (koltuk_no >= 1),
    ucret_kr INTEGER NOT NULL CHECK (ucret_kr BETWEEN 0 AND 99999999),
    UNIQUE (seans_id, koltuk_no)
) STRICT;

CREATE TRIGGER seans_planla BEFORE INSERT ON seans BEGIN
    SELECT RAISE(ABORT, 'Kural: Film seçilen saat aralığına sığmıyor.')
    FROM saat_araligi a, film f
    WHERE a.id = NEW.saat_id AND f.id = NEW.film_id AND f.sure_dk > a.bitis_dk - a.baslangic_dk;

    -- Bitiş anı aralığa dahil değildir: 12:00'de biten ve başlayan seanslar çakışmaz.
    SELECT RAISE(ABORT, 'Kural: Bu salonda seçilen saatle çakışan bir seans var.')
    FROM seans s JOIN saat_araligi eski ON eski.id = s.saat_id
    JOIN saat_araligi yeni ON yeni.id = NEW.saat_id
    WHERE s.tarih = NEW.tarih AND s.salon_id = NEW.salon_id
      AND eski.baslangic_dk < yeni.bitis_dk AND yeni.baslangic_dk < eski.bitis_dk;
END;

CREATE TRIGGER film_suresini_koru BEFORE UPDATE OF sure_dk ON film BEGIN
    SELECT RAISE(ABORT, 'Kural: Yeni film süresi planlanmış bir seansa sığmıyor.')
    FROM seans s JOIN saat_araligi a ON a.id = s.saat_id
    WHERE s.film_id = OLD.id AND NEW.sure_dk > a.bitis_dk - a.baslangic_dk;
END;

CREATE TRIGGER koltugu_denetle BEFORE INSERT ON bilet BEGIN
    SELECT RAISE(ABORT, 'Kural: Koltuk numarası salon kapasitesini aşıyor.')
    FROM seans s JOIN salon l ON l.id = s.salon_id
    WHERE s.id = NEW.seans_id AND NEW.koltuk_no > l.kapasite;
END;

CREATE TRIGGER satilan_koltugu_koru BEFORE UPDATE OF kapasite ON salon BEGIN
    SELECT RAISE(ABORT, 'Kural: Satılmış bir koltuğun numarası yeni kapasiteyi aşıyor.')
    FROM seans s JOIN bilet b ON b.seans_id = s.id
    WHERE s.salon_id = OLD.id AND b.koltuk_no > NEW.kapasite;
END;

-- Bu kayıtlar yerinde düzenlenmez; değişiklik için iptal edip yeniden oluşturulur.
CREATE TRIGGER seans_degistirme BEFORE UPDATE ON seans BEGIN
    SELECT RAISE(ABORT, 'Kural: Seansı silip yeniden planlayın.');
END;
CREATE TRIGGER saat_degistirme BEFORE UPDATE ON saat_araligi BEGIN
    SELECT RAISE(ABORT, 'Kural: Yeni bir saat aralığı tanımlayın.');
END;
CREATE TRIGGER bilet_degistirme BEFORE UPDATE ON bilet BEGIN
    SELECT RAISE(ABORT, 'Kural: Bileti iptal edip yeniden satın.');
END;

CREATE VIEW seans_ozeti AS
SELECT s.id, s.tarih, f.ad AS film_adi, f.sure_dk, f.ucret_kr, l.ad AS salon_adi,
       l.kapasite, a.baslangic_dk, a.bitis_dk, count(b.id) AS satilan,
       coalesce(sum(b.ucret_kr), 0) AS gelir_kr
FROM seans s
JOIN film f ON f.id = s.film_id
JOIN salon l ON l.id = s.salon_id
JOIN saat_araligi a ON a.id = s.saat_id
LEFT JOIN bilet b ON b.seans_id = s.id
GROUP BY s.tarih, s.id;

PRAGMA user_version = 1;
