"""MTT Sinema kaynak paketini oluştur veya çalışma ağacına göre doğrula."""
import argparse
import sys
from pathlib import Path
from zipfile import BadZipFile, ZIP_DEFLATED, ZipFile, ZipInfo

KOK = Path(__file__).resolve().parents[1]
PAKET = KOK / 'MTT-Sinema.zip'
ON_EK = 'MTT-Sinema/'

# Windows ve farklı yerel ayarlarda Türkçe karakterlerin çıktıyı bozmasını önler.
for akis in (sys.stdout, sys.stderr):
    if hasattr(akis, 'reconfigure'):
        akis.reconfigure(encoding='utf-8', errors='replace')


def icerik():
    # İzin listesi: derleme klasörleri, IDE ayarları, yerel veriler ve ZIP'in kendisi taranmaz.
    yollar = [KOK / ad for ad in ('MttSinema.sln', 'README.md', '.gitattributes', '.gitignore',
                                   'araclar/paketle.py', '.github/workflows/dogrulama.yml')]
    for kalip in ('src/MttSinema/*.cs', 'src/MttSinema/*.csproj', 'src/MttSinema/App.config',
                  'src/MttSinema/Formlar/*.cs', 'src/MttSinema/Formlar/*.resx',
                  'src/MttSinema/Modeller/*.cs', 'src/MttSinema/Veri/*.cs', 'src/MttSinema/Veri/*.sql',
                  'src/MttSinema/Properties/*.cs', 'src/MttSinema/Properties/*.resx', 'src/MttSinema/Resources/*.png',
                  'docs/*.svg', 'tests/test_*.py', 'tests/MttSinema.Testler/*.csproj', 'tests/MttSinema.Testler/*.cs'):
        yollar.extend(KOK.glob(kalip))
    return {ON_EK + yol.relative_to(KOK).as_posix(): yol for yol in sorted(yollar)}


def olustur(dosyalar):
    gecici = PAKET.with_suffix('.zip.tmp')
    try:
        with ZipFile(gecici, 'w') as zip_dosyasi:
            for ad, yol in dosyalar.items():
                # Sabit tarih, sıra ve izinler: aynı kaynaklarla yeniden paketleme fark üretmez.
                bilgi = ZipInfo(ad, date_time=(2024, 1, 1, 0, 0, 0))
                bilgi.create_system = 3
                bilgi.external_attr = 0o100644 << 16
                zip_dosyasi.writestr(bilgi, yol.read_bytes(), compress_type=ZIP_DEFLATED, compresslevel=9)
        gecici.replace(PAKET)
    finally:
        gecici.unlink(missing_ok=True)


def kontrol(dosyalar):
    with ZipFile(PAKET) as zip_dosyasi:
        if sorted(zip_dosyasi.namelist()) != sorted(dosyalar):
            raise ValueError('ZIP dosya listesi güncel değil.')
        for ad, yol in dosyalar.items():
            if zip_dosyasi.read(ad) != yol.read_bytes():
                raise ValueError(f'Paketlenmiş kopya güncel değil: {ad}')


if __name__ == '__main__':
    komut = argparse.ArgumentParser(description=__doc__)
    komut.add_argument('--kontrol', action='store_true', help='Dosyaları karşılaştır; paketi değiştirme.')
    secim = komut.parse_args()
    dosyalar = icerik()
    try:
        if not secim.kontrol:
            olustur(dosyalar)
        kontrol(dosyalar)
    except (OSError, ValueError, BadZipFile) as hata:
        komut.exit(1, f'{hata}\n')
    print(f'{PAKET.name}: {len(dosyalar)} kaynak dosyası doğrulandı.')
