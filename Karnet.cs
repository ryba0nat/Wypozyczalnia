using System;

namespace WypozyczalniaSprzetu
{
    public class Karnet
    {
        public string Rodzaj { get; set; }
        public double Cena { get; set; }
        public DateTime DataZakupu { get; set; }
        public int CzasTrwania { get; set; } // Liczba dni/godzin

        public Karnet(string rodzaj, double cena, DateTime dataZakupu, int czasTrwania)
        {
            Rodzaj = rodzaj;
            Cena = cena;
            DataZakupu = dataZakupu;
            CzasTrwania = czasTrwania;
        }

        public double ObliczKoszt()
        {
            return Cena * CzasTrwania;
        }
    }
}
