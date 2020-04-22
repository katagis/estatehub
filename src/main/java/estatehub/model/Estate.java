package estatehub.model;

import java.util.Vector;

public class Estate {
    private String name;
    private String location;
    private Vector<Offer> offers;

    private int id = 1;

    public String getName() {
        return name;
    }

    public String getLocation() {
        return location;
    }

    public int getId() {
        return id;
    }

    public Vector<Offer> getOffers() {
        return offers;
    }
    
    Estate(String name) {
        this.name = name;
        location = "Patras, Center";
        offers = new Vector<Offer>();
        offers.add(new Offer());
        offers.add(new Offer());
        offers.add(new Offer());
    }
}