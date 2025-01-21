using System.Collections.Generic;

namespace WypozyczalniaSprzetu
{
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
