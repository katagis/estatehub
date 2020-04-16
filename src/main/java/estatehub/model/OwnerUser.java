package estatehub.model;

public class OwnerUser extends User{

    public OwnerUser(String name){
        super(name);
    }

    public OwnerUser(){ 
        // Default owner
        super("Corona Smith");
    }
}