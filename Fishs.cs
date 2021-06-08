using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppCsharpquarium
{
    public class Fishs : Alives
    {
        Random dice = new Random();

        public Aquarium Habitat { get; private set; }
        public string Name { get; private set; }
        public Gender Sex { get; private set; }
        public Races Race { get; private set; }
        public bool IsHungry { get; private set; }

        public Fishs(string nom, Gender sexe, Races race, int age, Aquarium habitat)
        {
            this.Name = nom;
            this.Sex = sexe;
            this.Race = race;
            this.IsHungry = true;
            //this.IsAlive = true;
            this.PV = 10;
            this.Age = age;
        }

        public void Hungry(List<Fishs> liste_poissons, int i)
        {
            liste_poissons[i].PV--;
            //liste_poissons[i].CheckAlive(liste_poissons, i); ;
        }

        public void CheckHungry(List<Fishs> liste_poissons, int i)
        {
            if (liste_poissons[i].PV <= 5) liste_poissons[i].IsHungry = true;
            else liste_poissons[i].IsHungry = false;
        }

        //public void CheckAlive(List<Fishs> liste_poissons, int i)
        //{
        //    if (this.PV > 0) this.IsAlive = true;
        //    else liste_poissons[i].IsAlive = false;
        //}

        public void TooOld(List<Fishs> liste_poissons, int i)
        {
            if ((liste_poissons[i].Race == Races.Sole || liste_poissons[i].Race == Races.PoissonClown) && (liste_poissons[i].Age == 10))
            {
                liste_poissons[i].Sex = (liste_poissons[i].Sex == Gender.Female) ? Gender.Male : Gender.Female;
            }
            liste_poissons[i].Age++;
            if (liste_poissons[i].Age>20)
            {
                liste_poissons[i].PV = 0;
                //liste_poissons[i].IsAlive = false;
            }
        }

        public void Eat(List<Fishs> liste_poissons, List<Seaweeds> liste_algues, int i)
        {
            switch (liste_poissons[i].Race)
            {
                case Races.Merou:
                case Races.Thon:
                case Races.PoissonClown:
                    int CarnivorousFood = dice.Next(liste_poissons.Count);
                    if (liste_poissons[CarnivorousFood].IsAlive && liste_poissons[i].Race != liste_poissons[CarnivorousFood].Race)
                    {
                        liste_poissons[CarnivorousFood].PV -= 4;
                        //liste_poissons[CarnivorousFood].CheckAlive(liste_poissons, CarnivorousFood);
                        liste_poissons[CarnivorousFood].CheckHungry(liste_poissons, CarnivorousFood);
                        liste_poissons[i].PV += 5;
                        liste_poissons[i].CheckHungry(liste_poissons, i);
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
                            //liste_algues[HerbivorousFoods].CheckAlive(liste_algues, HerbivorousFoods);
                            liste_poissons[i].PV += 3;
                            liste_poissons[i].CheckHungry(liste_poissons, i);
                        }
                    }
                    break;
            } 
        }
        public void MakeBabies(List<Fishs> liste_poissons, int i)
        {
            switch (liste_poissons[i].Race)
            {
                case Races.Carpe:
                case Races.Thon:
                    int Monosexe = dice.Next(liste_poissons.Count);
                    if (liste_poissons[Monosexe].IsAlive && liste_poissons[i].Race == liste_poissons[Monosexe].Race && liste_poissons[i].Sex != liste_poissons[Monosexe].Sex)
                    {
                        liste_poissons.Add(new Fishs("Baby"+ (liste_poissons.Count + 1).ToString(), (dice.Next(2) == 0) ? Gender.Male : Gender.Female, liste_poissons[i].Race, 0));
                    }
                    break;
                
                case Races.Bar:
                case Races.Merou:
                    int Hermaphrodite = dice.Next(liste_poissons.Count);
                    if (liste_poissons[Hermaphrodite].IsAlive && liste_poissons[i].Race != liste_poissons[Hermaphrodite].Race && liste_poissons[i].Sex != liste_poissons[Hermaphrodite].Sex)
                    {
                        liste_poissons.Add(new Fishs("Baby" + (liste_poissons.Count + 1).ToString(), (dice.Next(2) == 0) ? Gender.Male : Gender.Female, liste_poissons[i].Race, 0));
                    }
                    break;
                case Races.Sole:
                case Races.PoissonClown:
                    int Opportuniste = dice.Next(liste_poissons.Count);
                    if (liste_poissons[Opportuniste].IsAlive && liste_poissons[i].Race != liste_poissons[Opportuniste].Race)
                    {
                        if (liste_poissons[i].Sex == liste_poissons[Opportuniste].Sex)
                        {
                            liste_poissons[i].Sex = (liste_poissons[i].Sex == Gender.Female) ? Gender.Male : Gender.Female;
                        }
                        liste_poissons.Add(new Fishs("Baby" + (liste_poissons.Count + 1).ToString(), (dice.Next(2) == 0) ? Gender.Male : Gender.Female, liste_poissons[i].Race, 0));
                    }
                    break;
            }
        }
    }
}
