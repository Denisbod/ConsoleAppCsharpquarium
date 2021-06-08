using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppCsharpquarium
{
    public struct Meal
    {
    }
}
//        public void RandomMeal(List<Fishs> liste_poissons, List<Seaweeds> liste_algues)
//        {
//            Random dice = new Random();
//            for (int i = 0; i < liste_poissons.Count; i++)
//            {
//                if (liste_poissons[i].IsAlive && liste_poissons[i].IsHungry)
//                {
//                    switch (liste_poissons[i].Race)
//                    {
//                        case Races.Merou:
//                        case Races.Thon:
//                        case Races.PoissonClown:
//                            while (liste_poissons[i].IsHungry && liste_poissons.Count > 1)
//                            {
//                                int CarnivorousFood = dice.Next(liste_poissons.Count);
//                                if (liste_poissons[CarnivorousFood].IsAlive && liste_poissons[i].Race != liste_poissons[CarnivorousFood].Race)
//                                {
//                                    liste_poissons[CarnivorousFood].IsAlive = false;
//                                    liste_poissons[i].IsHungry = false;
//                                }
//                            }
//                            break;
//                        case Races.Sole:
//                        case Races.Bar:
//                        case Races.Carpe:
//                            while (liste_algues.Count > 0)
//                            {
//                                int HerbivorousFoods = dice.Next(liste_algues.Count);
//                                if (liste_algues[HerbivorousFoods].IsAlive)
//                                {
//                                    liste_algues[HerbivorousFoods].IsAlive = false;
//                                    liste_poissons[i].IsHungry = false;
//                                }
//                            }
//                            break;
//                    }
//                }
//            }
//        }
//    }
//}
            



//public struct Meal
//{
//    public void RandomMeal(List<Fishs> liste_poissons, List<Seaweeds> liste_algues)
//    {
//        Random dice = new Random();
//        List<int> Eaters = new List<int>();
//        for (int i = 0; i < liste_poissons.Count; i++)
//        {
//            Eaters.Add(i);
//        }
//        List<int> CarnivorousFoods = new List<int>();
//        for (int i = 0; i < liste_poissons.Count; i++)
//        {
//            CarnivorousFoods.Add(i);
//        }
//        List<int> HerbivorousFoods = new List<int>();
//        for (int i = 0; i < liste_algues.Count; i++)
//        {
//            HerbivorousFoods.Add(i);
//        }
//        bool LastIsCarnivorous = false;

//        while ((Eaters.Count >= 1) && !LastIsCarnivorous)
//        {
//            int NbrEater = dice.Next(Eaters.Count);
//            {
//                switch (liste_poissons[Eaters[NbrEater]].Race)
//                {
//                    case Races.Merou:
//                    case Races.Thon:
//                    case Races.PoissonClown:
//                        bool CarnivousAttacked = false;
//                        if (Eaters.Count == 1)
//                        {
//                            LastIsCarnivorous = true;
//                            CarnivousAttacked = true;
//                        }
//                        do
//                        {
//                            int NbrCarnivorousFood = dice.Next(CarnivorousFoods.Count);
//                            if (Eaters[NbrEater] != CarnivorousFoods[NbrCarnivorousFood])
//                            {
//                                if (liste_poissons[Eaters[NbrEater]].Race != liste_poissons[CarnivorousFoods[NbrCarnivorousFood]].Race)
//                                {

//                                    Eaters.Remove(Eaters[NbrEater]);
//                                    CarnivorousFoods.Remove(CarnivorousFoods[NbrCarnivorousFood]);
//                                    Eaters.Remove(CarnivorousFoods[NbrCarnivorousFood]);
//                                    liste_poissons[Eaters[NbrEater]].Eat(liste_poissons, CarnivorousFoods[NbrCarnivorousFood]);
//                                }
//                                else
//                                {
//                                    Eaters.Remove(Eaters[NbrEater]);
//                                }
//                                CarnivousAttacked = true;
//                            }
//                        } while (!CarnivousAttacked);
//                        break;
//                    case Races.Sole:
//                    case Races.Bar:
//                    case Races.Carpe:
//                        if (HerbivorousFoods.Count > 0)
//                        {
//                            int NbrHerbivorousFoods = dice.Next(HerbivorousFoods.Count);
//                            HerbivorousFoods.Remove(HerbivorousFoods[NbrHerbivorousFoods]);
//                            liste_poissons[Eaters[NbrEater]].Eat(liste_algues, HerbivorousFoods[NbrHerbivorousFoods]);
//                        }
//                        Eaters.Remove(Eaters[NbrEater]);
//                        break;
//                }
//            }
//        }
//    }


//public void RandomMeal(List<Fishs> liste_poissons, List<Seaweeds> liste_algues)
//{
//    Random dice = new Random();
//    bool LastIsCarnivorous = false;
//    int nbr_attacked;
//    do
//    {
//        nbr_attacked = 0;
//        for (int i = 0; i < liste_poissons.Count; i++)
//        {
//            if (liste_poissons[i].Atacked) nbr_attacked++;
//        }

//        while ((liste_poissons.Count - nbr_attacked >= 1) && !LastIsCarnivorous)
//        {
//            int NbrEater = dice.Next(liste_poissons.Count);
//            {
//                switch (liste_poissons[NbrEater].Race)
//                {
//                    case Races.Merou:
//                    case Races.Thon:
//                    case Races.PoissonClown:
//                        if (liste_poissons.Count - nbr_attacked == 1)
//                        {
//                            LastIsCarnivorous = true;
//                            liste_poissons[NbrEater].Atacked = true;
//                        }
//                        do
//                        {
//                            int NbrCarnivorousFood = dice.Next(liste_poissons.Count);
//                            if (liste_poissons[NbrEater] != liste_poissons[NbrCarnivorousFood])
//                            {
//                                if (liste_poissons[NbrEater].Race != liste_poissons[NbrCarnivorousFood].Race)
//                                {
//                                    liste_poissons[NbrEater].Eat(liste_poissons, liste_poissons[NbrCarnivorousFood]);
//                                    liste_poissons.Remove(liste_poissons[NbrCarnivorousFood]);
//                                    liste_poissons[NbrEater].Atacked = true;
//                                    nbr_attacked += 1;
//                                }
//                            }
//                            else
//                            {
//                                liste_poissons[NbrEater].Atacked = true;
//                                nbr_attacked += 1;
//                            }
//                        } while (!liste_poissons[NbrEater].Atacked);
//                        break;
//                    case Races.Sole:
//                    case Races.Bar:
//                    case Races.Carpe:
//                        if (liste_algues.Count > 0)
//                        {
//                            int NbrHerbivorousFoods = dice.Next(liste_algues.Count);
//                            liste_poissons[NbrEater].Eat(liste_algues, liste_algues[NbrHerbivorousFoods]);
//                            liste_algues.Remove(liste_algues[NbrHerbivorousFoods]);
//                            liste_poissons[NbrEater].Atacked = true;
//                            nbr_attacked += 1;
//                        }
//                        break;
//                }
//            }
//        }

//    } while (liste_poissons.Count > nbr_attacked);
//}
//    }
//}
