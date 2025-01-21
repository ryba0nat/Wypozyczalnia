using System;

namespace WypozyczalniaSprzetu
{
    [Serializable]
    public abstract class SprzetNarciarski
    {
        private static int globalId = 1; // Globalny licznik ID
        public int ID { get; }
        public string Rodzaj { get; set; }
        public int Rozmiar { get; set; }
        public string StanTechniczny { get; set; }
        public bool CzyWypozyczony { get; set; }

        protected SprzetNarciarski(string rodzaj, int rozmiar, string stanTechniczny, bool czyWypozyczony)
        {
            ID = globalId++;
            Rodzaj = rodzaj;
            Rozmiar = rozmiar;
            StanTechniczny = stanTechniczny;
            CzyWypozyczony = czyWypozyczony;
        }

        public virtual string Opis()
        {
            return $"ID: {ID}, Rodzaj: {Rodzaj}, Rozmiar: {Rozmiar}, Stan: {StanTechniczny}, Wypożyczony: {(CzyWypozyczony ? "Tak" : "Nie")}";
        }

        public abstract double CenaZaDzien();
    }
}
