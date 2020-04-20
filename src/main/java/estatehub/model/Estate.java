package estatehub.model;

import java.util.Vector;

public class Estate {
    private String name;
    private String location;
    private Vector<Offer> offers;

    public String getName() {
        return name;
    }

    public String getLocation() {
        return location;
    }

    public Vector<Offer> getOffers() {
        return offers;
    }
    
    Estate() {
        name = "Tester Estate";
        location = "Patras, Center";
        offers = new Vector<Offer>();
        offers.add(new Offer());
        offers.add(new Offer());
        offers.add(new Offer());
    }
}