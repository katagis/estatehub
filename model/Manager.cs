using System;
using System.Collections.Generic;
using System.Text;

namespace EstateHub.model
{
    public class Manager : User
    {
        public List<Offer> Offers { get; } = new List<Offer>();
        public List<Estate> ViewHistory { get; } = new List<Estate>();
        public List<Review> Reviews { get; } = new List<Review>();

        public Manager(string name) : base(name) {
            Estatehub.RegisterManager(this);
        }

        Review GetReviewFrom(Owner owner) {
            foreach (var rev in Reviews) {
                if (rev.FromOwner == owner) {
                    return rev;
                }
            }
            return null;
        }
    }

}
