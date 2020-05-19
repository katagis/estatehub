using System;

namespace EstateHub.model
{
    public class Location
    {
        public string Address { get; private set; }
        public string Region { get; private set; }
        public string PostalCode { get; private set; }

        public Location(int randomSeed) {
            Address = "Addr " + randomSeed;
            Region = "Region " + randomSeed * 109 % 19;
            PostalCode = "AT" + (randomSeed % 119) * 100;
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