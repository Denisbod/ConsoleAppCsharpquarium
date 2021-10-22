using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppCsharpquarium
{
    public abstract class Alives
    {
        public Action<string> ChangementEtat;
        public Aquarium Habitat { get; protected set; }
        public bool IsAlive { get { return this.PV > 0; } }

        public int Id { get; set; }

        private int _pv = 10;
        public int PV
        {
            get
            {
                return _pv;
            }

            set
            {
                _pv = value;

                if (PV <= 0)
                {
                    ChangementEtat?.Invoke("Mort");
                }
                if (this is Seaweeds && PV > 10)
                {
                    this.ChangementEtat?.Invoke("Naissance");
                    this._pv = 5;
                    //this.Habitat?.AddSeaweeds(1);
                }
            }
        }
        public int Age { get; set; }
    }
}
 