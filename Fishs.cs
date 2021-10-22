using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppCsharpquarium
{
    public class Fishs : Alives
    {
        public Random dice = new Random();
        public string Name { get; private set; }
        public Gender Sex { get; private set; }
        public Races Race { get; private set; }
        public bool Had_a_date { get; private set; }
        public Fishs(int id, int pv, int age, string nom, Gender sexe, Races race, Aquarium habitat)
        {
            this.Id = id;
            this.PV = pv;
            this.Name = nom;
            this.Sex = sexe;
            this.Race = race;
            this.Age = age;
            this.Habitat = habitat;
            this.Had_a_date = false;
        }
        //public Fishs(string nom, Gender sexe, Races race, int age, Aquarium habitat)
        //{
        //    this.Name = nom;
        //    this.Sex = sexe;
        //    this.Race = race;
        //    this.Age = age;
        //    this.Habitat = Habitat;
        //    this.Had_a_date = false;
        //}
        public void TooOld()
        {
            this.Age++;
            if (this.IsAlive && this.Age > 20)
            {
                this.PV = 0;
            }
            this.ChangementEtat?.Invoke("Changement");
            if (this.IsAlive && (this.Race == Races.Bar || this.Race == Races.Merou) && this.Age == 11)
            {
                this.Sex = (this.Sex == Gender.Female) ? Gender.Male : Gender.Female;
                //ICI!!!
                this.ChangementEtat?.Invoke("Changement");
            }     
        }
        public void Hungry(List<Fishs> liste_poissons, int i, List<Seaweeds> liste_algues)
        {
            this.PV--;
            this.ChangementEtat?.Invoke("Changement");
            if (this.IsAlive && this.PV <=5)
            {
                this.Eat(liste_poissons, liste_algues);
            }
            else if (this.IsAlive && !this.Had_a_date)
            {
                this.MakeBabies(liste_poissons, i);
            }
        }

        public void Eat(List<Fishs> liste_poissons, List<Seaweeds> liste_algues)
        {
            switch (this.Race)
            {
                case Races.Merou:
                case Races.Thon:
                case Races.PoissonClown:
                    int CarnivorousFood = dice.Next(liste_poissons.Count);
                    if (liste_poissons[CarnivorousFood].IsAlive && this.Race != liste_poissons[CarnivorousFood].Race)
                    {
                        liste_poissons[CarnivorousFood].PV -= 4;
                        liste_poissons[CarnivorousFood].ChangementEtat?.Invoke("Changement");
                        this.PV += 5;
                        //ICI!!!
                        this.ChangementEtat?.Invoke("Changement");
                    }
                    break;
                case Races.Sole:
                case Races.Bar:
                case Races.Carpe:
                    if (liste_algues.Count > 0)
                    {
                        int HerbivorousFoods = dice.Next(liste_algues.Count);
                        if (liste_algues[HerbivorousFoods].IsAlive)
                        {
                            liste_algues[HerbivorousFoods].PV -= 2;
                            liste_algues[HerbivorousFoods].ChangementEtat?.Invoke("Changement");
                            this.PV += 3;
                            //ICI!!!
                            this.ChangementEtat?.Invoke("Changement");
                        }
                    }
                    break;
            } 
        }
        public void MakeBabies(List<Fishs> liste_poissons, int i)
        {
            switch (this.Race)
            {
                case Races.Carpe:
                case Races.Thon:
                case Races.Bar:
                case Races.Merou:
                    int NonOppOrtunistic = dice.Next(liste_poissons.Count);
                    if (liste_poissons[NonOppOrtunistic].IsAlive && liste_poissons[NonOppOrtunistic].Age > 0 && !liste_poissons[NonOppOrtunistic].Had_a_date && this.Race == liste_poissons[NonOppOrtunistic].Race && this.Sex != liste_poissons[NonOppOrtunistic].Sex)
                    {
                        this.Had_a_date = true;
                        liste_poissons[NonOppOrtunistic].Had_a_date = true;
                        this.ChangementEtat?.Invoke("Naissance");
                        //liste_poissons.Add(new Fishs("Baby" + (liste_poissons.Count + 1).ToString(), (dice.Next(2) == 0) ? Gender.Male : Gender.Female, this.Race, 0, this.Habitat));
                    }
                    break;
                case Races.Sole:
                case Races.PoissonClown:
                    int Opportunistic = dice.Next(liste_poissons.Count);
                    if (liste_poissons[Opportunistic].IsAlive && liste_poissons[Opportunistic].Age > 0 && !liste_poissons[Opportunistic].Had_a_date && this.Race == liste_poissons[Opportunistic].Race)
                    {
                        if (this.Sex == liste_poissons[Opportunistic].Sex)
                        {
                            this.Sex = (this.Sex == Gender.Female) ? Gender.Male : Gender.Female;
                        }
                        this.Had_a_date = true;
                        liste_poissons[Opportunistic].Had_a_date = true;
                        this.ChangementEtat?.Invoke("Naissance");
                        //liste_poissons.Add(new Fishs("Baby" + (liste_poissons.Count + 1).ToString(), (dice.Next(2) == 0) ? Gender.Male : Gender.Female, liste_poissons[i].Race, 0, this.Habitat));
                    }
                    break;
            }
        }
    }
}
