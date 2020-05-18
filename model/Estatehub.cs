using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace EstateHub.model
{
    class Estatehub
    {
        public static List<User> Users { get; private set; } = new List<User>();
        public static List<Owner> Owners { get; private set; } = new List<Owner>();
        public static List<Manager> Managers { get; private set; } = new List<Manager>();
        public static List<Location> Locations { get; private set; } = new List<Location>();

        // Called automatically from the constructors of these classes.
        public static void RegisterUser(User user) {
            Users.Add(user);
        }

        public static void RegisterOwner(Owner owner) {
            Owners.Add(owner);
        }

        public static void RegisterManager(Manager manager) {
            Managers.Add(manager);
        }

        public static void RegisterLocation(Location location) {
            Locations.Add(location);
        }

        public static SearchResults Search(string terms) {
            List<Estate> matchedEstates = new List<Estate>();
            List<Advertisement> advertisements = new List<Advertisement>();

            foreach (var owner in Owners) {
                foreach (var estate in owner.Estates) {
                    if (estate.IsBeingAdvertised()) {
                        advertisements.Add(estate.Advertisement);
                    }
                    else if (estate.MatchesTerms(terms)) {
                        matchedEstates.Add(estate);
                    }
                }
            }
            return new SearchResults(matchedEstates, advertisements, terms);
        }

    }
}
