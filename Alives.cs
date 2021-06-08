using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppCsharpquarium
{
    public class Alives
    {
        public bool IsAlive { get { return this.PV > 0; } }

        public int PV { get; set; }

        public int Age { get; set; }
        public Alives()
        {
            //this.IsAlive = true;
            //this.PV = 10;
            //this.Age = Age;
        }
    }
}
