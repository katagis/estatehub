package estatehub.model;

import java.util.Random;

public class Offer {
    private int money = 3000;
    private int seasons = 1;
    private ManagerUser manager;
    
    Offer() {
        manager = Database.getManagerUser(null);
        Random r = new Random();
        money = r.nextInt(1000) + 1000;
    }

    public int getMoney() {
        return money;
    }

    public int getSeasons() {
        return seasons;
    }

    public ManagerUser getManager() {
        return manager;
    }
}