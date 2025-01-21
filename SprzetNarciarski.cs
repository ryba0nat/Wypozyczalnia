using System;

namespace WypozyczalniaSprzetu
{
    public abstract class SprzetNarciarski
    {
        public string Rodzaj { get; set; }
        public int Rozmiar { get; set; }
        public string StanTechniczny { get; set; }
        public bool CzyWypozyczony { get; set; }

        protected SprzetNarciarski(string rodzaj, int rozmiar, string stanTechniczny, bool czyWypozyczony)
        {
            Rodzaj = rodzaj;
            Rozmiar = rozmiar;
            StanTechniczny = stanTechniczny;
            CzyWypozyczony = czyWypozyczony;
        }

        public virtual string Opis()
        {
            return $"Rodzaj: {Rodzaj}, Rozmiar: {Rozmiar}, Stan: {StanTechniczny}, Wypożyczony: {(CzyWypozyczony ? "Tak" : "Nie")}";
        }

        public abstract double CenaZaDzien();
    }
}
