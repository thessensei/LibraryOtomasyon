using System;
using System.Globalization;

namespace MttSinema.Modeller
{
    internal sealed class Film
    {
        public long Id { get; set; }
        public string Ad { get; set; }
        public string Tur { get; set; }
        public int SureDakika { get; set; }
        public decimal Ucret { get; set; }
        public override string ToString() => Ad;
    }

    internal sealed class Salon
    {
        public long Id { get; set; }
        public string Ad { get; set; }
        public int Kapasite { get; set; }
        public override string ToString() => Ad;
    }

    internal sealed class SaatAraligi
    {
        public long Id { get; set; }
        public int BaslangicDakika { get; set; }
        public int BitisDakika { get; set; }
        public int SureDakika => BitisDakika - BaslangicDakika;
        public string Baslangic => SaatYaz(BaslangicDakika);
        public string Bitis => SaatYaz(BitisDakika);
        public override string ToString() => Baslangic + " – " + Bitis;

        internal static string SaatYaz(int dakika) =>
            TimeSpan.FromMinutes(dakika).ToString(@"hh\:mm", CultureInfo.InvariantCulture);
    }

    internal sealed class SeansOzeti
    {
        public long Id { get; set; }
        public string FilmAdi { get; set; }
        public string SalonAdi { get; set; }
        public int FilmSuresi { get; set; }
        public SaatAraligi Saat { get; set; }
        public int Kapasite { get; set; }
        public int Satilan { get; set; }
        public decimal BiletFiyati { get; set; }
        public decimal Hasilat { get; set; }
        public override string ToString() => $"{Saat.Baslangic} · {FilmAdi} · {SalonAdi}";
    }

    internal sealed class Bilet
    {
        public long Id { get; set; }
        public int KoltukNo { get; set; }
        public decimal Ucret { get; set; }
    }
}
