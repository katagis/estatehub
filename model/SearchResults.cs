using System;
using System.Collections.Generic;
using System.Text;

namespace EstateHub.model
{
    public class SearchResults
    {
        public List<Estate> Estates { get; private set; }
        public List<Advertisement> Advertisements { get; private set; }
        
        public List<Estate> AdvertisedEstatesToShow { get; private set; }
        public string Terms { get; private set; }
        public SearchResults(List<Estate> estates, List<Advertisement> advertisements, string terms) {
            Estates = estates;
            Advertisements = advertisements;
            Terms = terms;
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
