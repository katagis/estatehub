using System;
using System.Collections.Generic;
using System.Text;

namespace EstateHub.model
{
    public class Offer 
    {
        public Manager Offerer { get; set; }
        public Estate estate { get; set; }
        public int EndingSeason;
        public int Money;


        public void AcceptOffer() {
            Deal d = (Deal)MemberwiseClone();
            d.UpdateExpiration();
            estate.CurrentDeal = d;
            estate.ActiveOffers.Remove(this);
            Offerer.PromoteToDeal(this, d);
        }
             
    }
}
