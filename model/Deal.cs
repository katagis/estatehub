using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace EstateHub.model
{
    public class Deal : Offer
    {
        public int ExpirationYear { get; private set; }

        public void UpdateExpiration() {
            ExpirationYear = EndingSeason;
        }
        public bool HasExpired() {
            return ExpirationYear > DateTime.Now.Year;
        }
    }
}
