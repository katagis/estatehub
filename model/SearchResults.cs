using System;
using System.Collections.Generic;
using System.Text;

namespace EstateHub.model
{
    public class SearchResults
    {
        public List<Estate> Estates { get; private set; } = new List<Estate>();
        public List<Advertisement> Advertisements { get; private set; } = new List<Advertisement>();
        
        public List<Estate> AdvertisedEstatesToShow { get; private set; } = new List<Estate>();
        public string Terms { get; private set; }
        public bool IncludeUnavailable { get; private set; }

        public SearchResults(string terms, bool includeUnavailable) {
            Terms = terms;
            IncludeUnavailable = includeUnavailable;

            foreach (var owner in Estatehub.Owners) {
                foreach (var estate in owner.Estates) {
                    if (includeUnavailable || estate.IsCurrentlyAvailable()) {
                        if (estate.IsBeingAdvertised()) {
                            Advertisements.Add(estate.Advertisement);
                        }
                        else if (estate.MatchesTerms(terms)) {
                            Estates.Add(estate);
                        }
                    }
                }
            }
        }


        public bool IsEmpty() {
            return Estates.Count == 0 && Advertisements.Count == 0;
        }

        // After this call Estates & AdvertisedEstates should be ready for display
        public void Sort() {
            AdvertisedEstatesToShow.Clear();

            foreach (var adv in Advertisements) {
                if (adv.ForEstate.MatchesTerms(Terms)) {
                    AdvertisedEstatesToShow.Add(adv.ForEstate);

                    // Show at max 3 advertisements
                    if (AdvertisedEstatesToShow.Count >= 3) {
                        return;
                    }
                }
            }

            // Fill the rest of the advertisement slots with irrelevant estates untill we have 3 advertisements in total
            foreach (var adv in Advertisements) {
                // We have already added the estates that match, skip them to avoid dupliucates
                if (!adv.ForEstate.MatchesTerms(Terms)) {
                    AdvertisedEstatesToShow.Add(adv.ForEstate);

                    if (AdvertisedEstatesToShow.Count >= 3) {
                        return;
                    }
                }
            }
        }
    }
}
