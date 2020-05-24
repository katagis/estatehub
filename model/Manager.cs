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

        private int sumReviews;

        public float ReviewScore {
            get {
                return sumReviews / Reviews.Count;
            }
        }


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

        public void RegisterOffer(Offer offer) {
            Offers.Add(offer);
        }

        public void AddReview(Review review) {
            Reviews.Add(review);
            sumReviews += review.Stars;
        }
    }

}
