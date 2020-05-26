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

        public string ReviewScore {
            get {
                if (Reviews.Count > 0) {
                    return ((float)sumReviews / Reviews.Count).ToString("0.0") + "/5";
                }
                return "~";
            }
        }

        public Manager(string name) : base(name) {
            Estatehub.RegisterManager(this);
        }

        public void PromoteToDeal(Offer offerToRemove, Deal dealToAdd) {
            Offers.Remove(offerToRemove);
            CurrentDeals.Add(dealToAdd);
            dealToAdd.Offerer.Notifications.Add(new Notification(dealToAdd.Offerer, "Your offer for " + dealToAdd.Estate.Title + " has been accepted."));
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
            var prevReview = GetReviewFrom(review.FromOwner);

            if (!(prevReview is null)) {
                sumReviews -= prevReview.Stars;
                Reviews.Remove(prevReview);
            }
            Reviews.Add(review);
            sumReviews += review.Stars;
        }
    }

}
