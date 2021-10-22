using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppCsharpquarium
{
    public class Aquarium
    {
        public int Turns { get; private set; }
        public List<Seaweeds> liste_algues { get; private set; }
        public List<Fishs> liste_poissons { get; private set; }

        public Aquarium()
        {
            this.Turns = 0;
            this.liste_algues = new List<Seaweeds>();
            this.liste_poissons = new List<Fishs>();
        }

        //public void AddFishs(string nom, Gender sexe, Races race, int age)
        //{
        //    liste_poissons.Add(new Fishs(nom, sexe, race, age, this));
        //}

        //public void AddSeaweeds(int age)
        //{
        //    liste_algues.Add(new Seaweeds(age, this));
        //}

        public void EndTurn(List<Fishs> liste_poissons, List<Seaweeds> liste_algues)
        {
            for (int i = 0; i < liste_algues.Count; i++)
            {
                liste_algues[i].TooOld();
                liste_algues[i].Grow(liste_algues);
            }
            for (int i = 0; i < liste_poissons.Count; i++)
            {
                liste_poissons[i].TooOld();
                liste_poissons[i].Hungry(liste_poissons, i, liste_algues);
            }  
            Turns++;
        }

    }
}
