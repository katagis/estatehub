package estatehub.model;

public class Review {
    private ManagerUser manager;
    private OwnerUser owner;
    private int stars;
    private String comment;

    public ManagerUser getManager() {
        return manager;
    }

    public OwnerUser getOwner() {
        return owner;
    }

    public int getStars() {
        return stars;
    }

    public String getComment() {
        return comment;
    }
}