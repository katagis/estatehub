using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace EstateHub.model
{
    public class Estate {
        public Owner Owner { get; }
        public Deal CurrentDeal { get; }
        public Location Location { get; }
        public List<Offer> ActiveOffers { get; } = new List<Offer>();
        public int ViewCount { get; }
        public Advertisement Advertisement{ get; }

        public string Title { get; set; } = "Ceid Estate";


        public bool MatchesTerms(string terms) {
            return true; // TODO:
        }

        public void IncrementViewCount() {
            // TODO:
        }

        public Offer GetCurrentOfferFrom(Manager manager) {
            return null; // TODO:
        }

        public bool IsBeingAdvertised() {
            return !(Advertisement is null);
        }

        public void AddAdvertisement(Advertisement newadvertisement) {
            // TODO:
        }
    }
}
