using System;
using System.Windows.Documents;

namespace EstateHub.model
{
    public class Location
    {
        public string Address { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }

        public Location() {}

        public string SubscriptText { 
            get {
                return Region + ", " + Address + ", " + PostalCode;
            } 
        }

        public Location(int randomSeed) {
            string[] addrs = {
                "University",
                "Center",
                "Agia Sofia",
                "Ovria",
                "Psila Alonia",
            };


            Region = "Patra";
            Address = addrs [randomSeed % addrs.Length] + " " + randomSeed % 119;
            PostalCode = ((randomSeed % 19) * 100 + 320).ToString();
        }


        public bool IsSameLocation(Location rhs) {
            return Address.Equals(rhs.Address, System.StringComparison.OrdinalIgnoreCase)
                && Region.Equals(rhs.Region, System.StringComparison.OrdinalIgnoreCase)
                && PostalCode.Equals(rhs.PostalCode, System.StringComparison.OrdinalIgnoreCase);
        }

        public bool MatchesTerms(string terms) {
           return Address.Contains(terms, System.StringComparison.OrdinalIgnoreCase)
                 || Region.Contains(terms, System.StringComparison.OrdinalIgnoreCase)
                 || PostalCode.Contains(terms, System.StringComparison.OrdinalIgnoreCase);
        }
    }
}