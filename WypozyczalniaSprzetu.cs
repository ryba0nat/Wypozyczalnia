using System;
using System.Collections.Generic;

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

    public class Narty : SprzetNarciarski
    {
        public string TypNart { get; set; }

        public Narty(string typNart, int rozmiar, string stanTechniczny, bool czyWypozyczony)
            : base("Narty", rozmiar, stanTechniczny, czyWypozyczony)
        {
            TypNart = typNart;
        }

        public override string Opis()
        {
            return base.Opis() + $", Typ: {TypNart}";
        }

        public override double CenaZaDzien()
        {
            return 50; // Przykładowa cena za dzień
        }
    }

    public class Snowboard : SprzetNarciarski
    {
        public string TypSnowboardu { get; set; }

        public Snowboard(string typSnowboardu, int rozmiar, string stanTechniczny, bool czyWypozyczony)
            : base("Snowboard", rozmiar, stanTechniczny, czyWypozyczony)
        {
            TypSnowboardu = typSnowboardu;
        }

        public override string Opis()
        {
            return base.Opis() + $", Typ: {TypSnowboardu}";
        }

        public override double CenaZaDzien()
        {
            return 60; // Przykładowa cena za dzień
        }
    }

    public class SprzetManager
    {
        private List<SprzetNarciarski> ListaSprzetu { get; } = new List<SprzetNarciarski>();

        public void DodajSprzet(SprzetNarciarski sprzet)
        {
            ListaSprzetu.Add(sprzet);
        }

        public void UsunSprzet(int indeks)
        {
            if (indeks >= 0 && indeks < ListaSprzetu.Count)
            {
                ListaSprzetu.RemoveAt(indeks);
            }
        }

        public List<SprzetNarciarski> FiltrujDostepny()
        {
            return ListaSprzetu.FindAll(sprzet => !sprzet.CzyWypozyczony);
        }

        public string PobierzStanSprzetu(SprzetNarciarski sprzet)
        {
            return $"Stan: {sprzet.StanTechniczny}, Wypożyczony: {(sprzet.CzyWypozyczony ? "Tak" : "Nie")}";
        }
    }
}
