using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppCsharpquarium
{
    public class Seaweeds : Alives
    {
        public Seaweeds(int age)
        {
            //this.IsAlive = true;
            this.PV = 10;
            this.Age = age;
        }

        public void Grow(List<Seaweeds> liste_algues, int i)
        {
            liste_algues[i].PV++;
        }

        //public void CheckAlive(List<Seaweeds> liste_algues, int i)
        //{
        //    if (liste_algues[i].PV > 0) liste_algues[i].IsAlive = true;
        //    else liste_algues[i].IsAlive = false;
        //}

        public void TooOld(List<Seaweeds> liste_algues, int i)
        {
            liste_algues[i].Age++;
            if (liste_algues[i].Age > 20)
            {
                liste_algues[i].PV = 0;
                //liste_algues[i].IsAlive = false;
            }
        }

    }
}
