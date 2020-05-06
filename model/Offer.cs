using System;
using System.Collections.Generic;
using System.Text;

namespace EstateHub.model
{
    public class Offer 
    {
        public Manager Offerer { get; }
        public Estate estate { get; }
        public int EndingSeason;
        public int Money;

             
    }
}
