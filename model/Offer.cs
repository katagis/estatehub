using System;
using System.Collections.Generic;
using System.Text;

namespace EstateHub.model
{
    public class Offer 
    {
        public Manager Offerer { get; set; }
        public Estate Estate { get; set; }
        public int EndingSeason;
        public int Money;


        public void AcceptOffer() {
            Deal d = new Deal(this);
            Estate.CurrentDeal = d;
            Estate.ActiveOffers.Remove(this);
            Offerer.PromoteToDeal(this, d);
        }
             
    }
}
