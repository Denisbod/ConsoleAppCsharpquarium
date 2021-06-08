using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppCsharpquarium
{
    public class Aquarium
    {
        private int Turns { get; set; }
        public List<Seaweeds> liste_algues { get; private set; }
        public List<Fishs> liste_poissons { get; private set; }
        //public Meal Meal { get; set; }
        public Aquarium()
        {
            this.Turns = 0;
            this.liste_algues = new List<Seaweeds>();
            this.liste_poissons = new List<Fishs>();
            //this.Meal = default;
        }

        public void AddFishs(string nom, Gender sexe, Races race, int age)
        {
            liste_poissons.Add(new Fishs(nom, sexe, race, age, this));
        }

        public void AddSeaweeds(int age)
        {
            liste_algues.Add(new Seaweeds(age));
        }

        public void EndTurn(List<Fishs> liste_poissons, List<Seaweeds> liste_algues)
        {
            for (int i = 0; i < liste_algues.Count; i++)
            {
                liste_algues[i].TooOld(liste_algues,i);
                if (liste_algues[i].IsAlive)
                {
                    liste_algues[i].Grow(liste_algues, i);
                    if (liste_algues[i].PV >= 10)
                    {
                        this.AddSeaweeds(1);
                        liste_algues[liste_algues.Count-1].PV = liste_algues[i].PV /= 2;
                        liste_algues[i].PV /= 2;
                    }
                }
                
            }
            for (int i = 0; i < liste_poissons.Count; i++)
            {
                liste_poissons[i].TooOld(liste_poissons, i);
                liste_poissons[i].Hungry(liste_poissons, i);
                if (liste_poissons[i].IsAlive && liste_poissons[i].IsHungry)
                {
                    liste_poissons[i].Eat(liste_poissons, liste_algues, i);
                }
                else if (liste_poissons[i].IsAlive)
                {
                    liste_poissons[i].MakeBabies(liste_poissons, i);
                }
            }
            int count = 0;
            foreach (Seaweeds s in liste_algues)
            {
                if (s.IsAlive) count++;
            }
            Console.WriteLine($"\nLe nombre d'algues en vie est de :{count} sur {liste_algues.Count}");
            for (int i = 0; i < liste_poissons.Count; i++)
            {
                Console.WriteLine($"Le sexe du poisson {liste_poissons[i].Race}, nommé {liste_poissons[i].Name}, est : {liste_poissons[i].Sex}. Est-il tj en vie , {liste_poissons[i].IsAlive}");
            }
            //Meal.RandomMeal(this.liste_poissons, this.liste_algues);
            Turns++;
            Console.WriteLine($"Le tour {Turns} prend fin.");
        }
    }
}
