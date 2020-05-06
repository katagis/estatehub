using System;
using System.Collections.Generic;
using System.Text;

namespace EstateHub.model
{
    class Manager : User
    {
        public List<Offer> Offers { get; }
        public List<Estate> ViewHistory { get; }
        public List<Review> Reviews { get; }        
    }

}
