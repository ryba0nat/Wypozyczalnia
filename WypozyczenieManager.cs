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
    }
}
