using System;

namespace ConsoleAppCsharpquarium
{
    class Program
    {
        static void Main(string[] args)
        {
            //if (!Convert.ToBoolean((int)Gender.Female)) Console.WriteLine($"Male");
            //else Console.WriteLine($"Female");
            //Console.ReadLine();

            Aquarium aquarium = new Aquarium();

            aquarium.AddSeaweeds(20);
            aquarium.AddSeaweeds(9);
            aquarium.AddSeaweeds(1);

            aquarium.AddFishs("Toto1", Gender.Male, Races.Carpe, 4);
            aquarium.AddFishs("Toto2", Gender.Female, Races.Carpe, 1);
            aquarium.AddFishs("Toto33", Gender.Male, Races.Bar, 20);
            aquarium.AddFishs("Toto3", Gender.Male, Races.Bar, 5);
            aquarium.AddFishs("Toto44", Gender.Female, Races.Bar,1);
            aquarium.AddFishs("Toto4", Gender.Female, Races.Sole, 1);
            aquarium.AddFishs("Toto3", Gender.Male, Races.Sole, 20);
            aquarium.AddFishs("Titi1", Gender.Male, Races.Merou, 2);
            aquarium.AddFishs("Titi2", Gender.Female, Races.Merou, 3);
            aquarium.AddFishs("Tutu1", Gender.Male, Races.PoissonClown, 4);
            aquarium.AddFishs("Tutu2", Gender.Female, Races.PoissonClown, 1);
            aquarium.AddFishs("Tutu5", Gender.Female, Races.Thon, 1);


            for (int i = 0; i < 21; i++)
            {
                aquarium.EndTurn(aquarium.liste_poissons, aquarium.liste_algues);
            }
            
            Console.ReadLine();


        }
    }
}
