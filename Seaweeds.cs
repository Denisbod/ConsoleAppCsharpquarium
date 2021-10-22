using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppCsharpquarium
{
    public class Seaweeds : Alives
    {

        public Seaweeds(int id, int pv, int age, Aquarium habitat)
        {
            this.Id = id;
            this.PV = pv;
            this.Age = age;
            this.Habitat = habitat;
        }
        //public Seaweeds(int age, Aquarium habitat)
        //{
        //    this.Age = age;
        //    this.Habitat = habitat;
        //}
        public void Grow(List<Seaweeds> liste_algues)
        {
            if (this.IsAlive)
            {
                this.PV++;
                this.ChangementEtat?.Invoke("Changement");
            }
            //if (this.PV > 10)
            //{
            //    this.ChangementEtat?.Invoke("Naissance");

            //    //this.Habitat.AddSeaweeds(1);
            //    //liste_algues[liste_algues.Count - 1].PV = 5;
            //    this.PV = 5;
            //}
        }
        public void TooOld()
        {
            this.Age++;
            if (this.Age > 20)
            {
                this.PV = 0;
            }
            this.ChangementEtat?.Invoke("Changement");
        }
    }
}
