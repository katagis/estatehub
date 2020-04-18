package estatehub.model;

public abstract class User {
    private String displayName;

    User(String Name){
        displayName = Name;
    }

    public String getName(){
        return displayName;
    }

    public void setName(String name) {
        displayName = name;
    }

    public abstract boolean isOwner();
}