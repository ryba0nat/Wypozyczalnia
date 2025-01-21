using System.Collections.Generic;

namespace WypozyczalniaSprzetu
{
    public class WypozyczenieManager
    {
        private List<Wypozyczenie> ListaWypozyczen { get; } = new List<Wypozyczenie>();

        public void DodajWypozyczenie(Wypozyczenie wypozyczenie)
        {
            ListaWypozyczen.Add(wypozyczenie);
        }

        public void ZwrocSprzet(Wypozyczenie wypozyczenie)
        {
            wypozyczenie.DataZwrotu = System.DateTime.Now;
            wypozyczenie.Sprzet.CzyWypozyczony = false;
        }

        public List<Wypozyczenie> WyszukajWypozyczeniaPoKliencie(Klient klient)
        {
            return ListaWypozyczen.FindAll(w => w.Klient == klient);
        }

        public List<Wypozyczenie> WyszukajWypozyczeniaPoSprzecie(SprzetNarciarski sprzet)
        {
            return ListaWypozyczen.FindAll(w => w.Sprzet == sprzet);
        }

        //  Pobiera aktywne wypożyczenia (te, które nie mają ustawionej daty zwrotu)
        public List<Wypozyczenie> GetAktywneWypozyczenia()
        {
            return ListaWypozyczen.FindAll(w => w.DataZwrotu == null);
        }

        public void WypozyczSprzet(int idSprzetu, Klient klient)
        {
            SprzetNarciarski sprzet = ListaWypozyczen.Find(w => w.Sprzet.ID == idSprzetu)?.Sprzet;
            if (sprzet != null && !sprzet.CzyWypozyczony)
            {
                Wypozyczenie wypozyczenie = new Wypozyczenie(sprzet, klient, DateTime.Now);
                ListaWypozyczen.Add(wypozyczenie);
                klient.DodajWypozyczenie(wypozyczenie);
            }
        }

        public void ZwrocSprzet(int idSprzetu)
        {
            Wypozyczenie wypozyczenie = ListaWypozyczen.Find(w => w.Sprzet.ID == idSprzetu && w.DataZwrotu == null);
            if (wypozyczenie != null)
            {
                wypozyczenie.DataZwrotu = DateTime.Now;
                wypozyczenie.Sprzet.CzyWypozyczony = false;
            }
        }

    }
}
