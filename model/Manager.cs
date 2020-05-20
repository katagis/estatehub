using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Converters;

namespace EstateHub.model
{
    public class Manager : User
    {
        public List<Offer> Offers { get; } = new List<Offer>();
        public HashSet<Estate> ViewHistory { get; } = new HashSet<Estate>();
        public List<Review> Reviews { get; } = new List<Review>();

        public List<Deal> CurrentDeals { get; private set; } = new List<Deal>();

        public Manager(string name) : base(name) {
            Estatehub.RegisterManager(this);
        }

        public void PromoteToDeal(Offer offerToRemove, Deal dealToAdd) {
            Offers.Remove(offerToRemove);
            CurrentDeals.Add(dealToAdd);
            // TODO: Add notification to manager

        }

        public Review GetReviewFrom(Owner owner) {
            foreach (var rev in Reviews) {
                if (rev.FromOwner == owner) {
                    return rev;
                }
            }
            return null;
        }

        public void AddToHistory(Estate estate) {
            ViewHistory.Add(estate);
        }
    }

}
