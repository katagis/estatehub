using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace EstateHub.model
{
    public class Deal : Offer
    {
        public int ExpirationYear { get; private set; }

        public Deal(Offer offer) {
            Offerer = offer.Offerer;
            Estate = offer.Estate;
            EndingSeason = offer.EndingSeason;
            ExpirationYear = EndingSeason;
            Money = offer.Money;
        }

        public bool HasExpired() {
            return ExpirationYear < DateTime.Now.Year;
        }
    }
}
