﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Markup;
using System.Windows.Media.Animation;

namespace EstateHub.model
{
    public class Owner : User
    {
        public List<Estate> Estates { get; } = new List<Estate>();

        public Owner(string name) : base(name) {
            Estatehub.RegisterOwner(this);
            AddDummyEstates();
        }

        private static readonly string loremIpsum = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.";

        public void AddDummyEstates() {
            Random r = new Random();
            for (int i = 0; i < 4; i++) {
                var e = new Estate(this, new Location(r.Next()), "Estate " + r.Next() + "", loremIpsum);
                Estates.Add(e);
                
                Random random = new Random();

                if (random.Next(0, 3) == 1) {
                    e.AddAdvertisement(new Advertisement(e, 2021));
                }



                int num = random.Next(0, 3);
                for (int j = 0; j < num; j++) {
                    int index = random.Next(0, Estatehub.Managers.Count);
                    var offer = new Offer() { Money = random.Next(5000, 50000), EndingSeason = random.Next(2020, 2021), Estate = e, Offerer = Estatehub.Managers [index] };
                    e.ActiveOffers.Add(offer);
                    offer.Offerer.RegisterOffer(offer);

                    if (e.IsCurrentlyAvailable() && random.Next(0, 3) == 1) {
                        offer.AcceptOffer();
                    }
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

        public void RegisterEstate(Estate newEstate) {
            Estates.Add(newEstate);
        }
    }
}
