using System;
using System.Collections.Generic;
using System.Text;

namespace EstateHub.model
{
    class Estate {
        public Owner Owner { get; }
        public Deal CurrentDeal { get; }
        public Location Location { get; }
        public List<Offer> ActiveOffers { get; }
        public int ViewCount { get; }
        public Advertisement Advertisement{ get; }
        
    }
}
