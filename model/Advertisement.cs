using System;
using System.Collections.Generic;
using System.Text;

namespace EstateHub.model
{
    public class Advertisement
    {
        public Estate ForEstate { get; }
        public int EndingSeason { get; }

        public Advertisement(Estate est, int endingSeason) {
            ForEstate = est;
            EndingSeason = endingSeason;
        }
    }
}
