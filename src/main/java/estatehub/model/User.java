package estatehub.model;

public abstract class User {
    private String readableName;

    User(String Name){
        readableName = Name;
    }

    public String getName(){
        return readableName;
    }
}