using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace EstateHub.model
{
    public class Estate {
        public Owner Owner { get; private set; }
        public Deal CurrentDeal { get; set; }
        public Location Location { get; private set; }
        public List<Offer> ActiveOffers { get; private set; } = new List<Offer>();
        public int ViewCount { get; private set; } = 0;
        public Advertisement Advertisement{ get; private set; }

        public string Title { get; set; } = "Ceid Estate";
        public string Description { get; set; }

        public Estate(Owner owner, Location location, string title, string description = "") {
            Owner = owner;
            Location = location;
            Title  = title;
            Description = description;
        }

        public bool MatchesTerms(string terms) {
            return Location.MatchesTerms(terms)
                || Title.Contains(terms, StringComparison.OrdinalIgnoreCase);
        }

        public void IncrementViewCount() {
            ViewCount++;
            if (ViewCount % 5 == 0) {
                var notif = new Notification(Owner, "Estate " + Title + " has reached " + ViewCount + " views!");
                Owner.Notifications.Add(notif);
            }
        }

        public Offer GetCurrentOfferFrom(Manager manager) {
            foreach (var offer in ActiveOffers) {
                if (offer.Offerer == manager) {
                    return offer;
                }
            }
            return null;
        }

        public bool IsBeingAdvertised() {
            return !(Advertisement is null);
        }

        public void AddAdvertisement(Advertisement newadvertisement) {
            Advertisement = newadvertisement;
        }

        public bool IsCurrentlyAvailable() {
            return CurrentDeal == null || CurrentDeal.HasExpired();
        }
    }
}
