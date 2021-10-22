using ConsoleAppCsharpquarium.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ConsoleAppCsharpquarium
{
    class Program
    {
        static void Main(string[] args)
        {
            //string ConnectionString = @"Data Source=Sonic-9;Initial Catalog=CsharpQuarium;Uid=sa;pwd=formation;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            string ConnectionString = @"Data Source=DESKTOP-JGTVP0O;Initial Catalog=CsharpQuarium;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (SqlConnection oConn = new SqlConnection(ConnectionString))
            {
                int NbBaby = 0;
                Aquarium aquarium = new Aquarium();

                FishsServices Fservice = new FishsServices(oConn, aquarium);
                //aquarium.liste_poissons = Fservice.GetFishs();

                SeaweedsServices Sservice = new SeaweedsServices(oConn, aquarium);

                for (int i = 0; i < 7; i++)
                {
                    aquarium.liste_poissons.Clear();
                    aquarium.liste_algues.Clear();
                    Fservice.GetFishs();
                    Sservice.GetSeaweeds();

                    int count1 = 0;
                    foreach (Seaweeds s in aquarium.liste_algues)
                    {
                        if (s.IsAlive) count1++;
                    }
                    Console.WriteLine($"\nLe nombre d'algues en vie est de :{count1} sur {aquarium.liste_algues.Count}");
                    for (int j = 0; j < aquarium.liste_poissons.Count; j++)
                    {
                        Console.WriteLine($"Le sexe du poisson {aquarium.liste_poissons[j].Race}, nommé {aquarium.liste_poissons[j].Name}, est : {aquarium.liste_poissons[j].Sex}.");
                        /*Est-il tj en vie , {aquarium.liste_poissons[j].IsAlive}*/
                    }

                    foreach (Fishs item in aquarium.liste_poissons)
                    {
                        item.ChangementEtat += (valeur =>
                        {
                            if (valeur == "Changement")
                            {
                                Fservice.UpdateFishs(item);
                            }
                            if (valeur == "Mort")
                            {
                                Fservice.DeleteFishs(item);
                            }          
                            if (valeur == "Naissance")
                            {
                                NbBaby++;
                                Fservice.AddFishs(new Fishs(0, 6, 1, "Baby" + (NbBaby).ToString(), (item.dice.Next(2) == 0) ? Gender.Male : Gender.Female, item.Race, item.Habitat));
                            }
                        });
                    }

                    foreach (Seaweeds item in aquarium.liste_algues)
                    {
                        item.ChangementEtat += (valeur =>
                        {
                            if (valeur == "Changement")
                            {
                                Sservice.UpdateSeaweeds(item);

                            }
                            if (valeur == "Mort")
                            {
                                Sservice.DeleteSeaweeds(item);

                            }
                            if (valeur == "Naissance")
                            {
                                Sservice.AddSeaweeds(new Seaweeds(0, 5, 1, aquarium));
                            }  
                        });
                    }
            
                    aquarium.EndTurn(aquarium.liste_poissons, aquarium.liste_algues);

                    foreach (Fishs item in aquarium.liste_poissons)
                    {
                        item.ChangementEtat -= (valeur =>
                        {
                            if (valeur == "Changement")
                            {
                                Fservice.UpdateFishs(item);
                            }
                            if (valeur == "Mort")
                            {
                                Fservice.DeleteFishs(item);
                            }
                            if (valeur == "Naissance")
                            {
                                NbBaby++;
                                Fservice.AddFishs(new Fishs(0, 10, 1, "Baby" + (NbBaby).ToString(), (item.dice.Next(2) == 0) ? Gender.Male : Gender.Female, item.Race, item.Habitat));
                            }
                        });
                    }

                    foreach (Seaweeds item in aquarium.liste_algues)
                    {
                        item.ChangementEtat -= (valeur =>
                        {
                            if (valeur == "Changement")
                            {
                                Sservice.UpdateSeaweeds(item);

                            }
                            if (valeur == "Mort")
                            {
                                Sservice.DeleteSeaweeds(item);

                            }
                            if (valeur == "Naissance")
                            {
                                Sservice.AddSeaweeds(new Seaweeds(0, 5, 1, aquarium));
                            }
                        });
                    }
                    //int count2 = 0;
                    //foreach (Seaweeds s in aquarium.liste_algues)
                    //{
                    //    if (s.IsAlive) count2++;
                    //}
                    //Console.WriteLine($"\nLe nombre d'algues en vie est de :{count2} sur {aquarium.liste_algues.Count}");
                    //for (int j = 0; j < aquarium.liste_poissons.Count; j++)
                    //{
                    //    Console.WriteLine($"Le sexe du poisson {aquarium.liste_poissons[j].Race}, nommé {aquarium.liste_poissons[j].Name}, est : {aquarium.liste_poissons[j].Sex}.");
                    //    /*Est-il tj en vie , {aquarium.liste_poissons[j].IsAlive}*/
                    //}
                    Console.WriteLine($"Le tour {aquarium.Turns} prend fin.");
                    Console.WriteLine($"-----------------------------------");
                }
                Console.ReadLine();
            }
        }
    }
}
