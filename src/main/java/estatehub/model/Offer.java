package estatehub.model;

import java.util.Random;

public class Offer {
    private int money = 3000;
    private int seasons = 1;
    private ManagerUser manager;
    private String comment;
    private int estateId;

    public Offer() {
    }

    public Offer(int estateId) {
        this.estateId = estateId;
        this.seasons = 1;
    }

    public void setEstateId(int estateId) {
        this.estateId = estateId;
    }

    public int getMoney() {
        return money;
    }

    public int getSeasons() {
        return seasons;
    }

    public String getComment() {
        return comment;
    }

    public ManagerUser getManager() {
        return manager;
    }

    public int getEstateId() {
        return estateId;
    }

    public void setMoney(int money){
        this.money = money;
    }

    public void setSeasons(int seasons){
        this.seasons = seasons;
    }

    public void setComment(String comment) {
        this.comment = comment;
    }
}