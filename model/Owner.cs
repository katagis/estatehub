using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Markup;

namespace EstateHub.model
{
    public class Owner : User
    {
        public List<Estate> Estates { get; } = new List<Estate>();

        public Owner(string name) : base(name) {
            Estatehub.RegisterOwner(this);
            AddDummyEstates();
        }

        public void AddDummyEstates() {
            Random r = new Random();
            for (int i = 0; i < 4; i++) {
                var e = new Estate() { Title = "Estate " + r.Next() + "" };
                Estates.Add(e);

                Random random = new Random();

                int num = random.Next(0, 5);
                for (int j = 0; j < num; j++) {
                    int index = random.Next(0, Estatehub.Managers.Count - 1);
                    e.ActiveOffers.Add(new Offer() { Money = random.Next(5000, 50000), EndingSeason = 2, estate = e, Offerer = Estatehub.Managers [index] });
                }
            }
        }

        public List<Estate> GetUnadvertisedEstates() {
            return Estates.FindAll((Estate est) => !est.IsBeingAdvertised());
        }

        // Estates that are not under a deal
        public List<Estate> FindFreeEstates() {
            return Estates.FindAll((Estate est) => est.CurrentDeal is null || est.CurrentDeal.HasExpired());
        }
    }
}
