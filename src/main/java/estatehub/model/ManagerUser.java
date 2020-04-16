package estatehub.model;

public class ManagerUser extends User{

    public ManagerUser(String name){
        super(name);
    }

    // Default manager
    public ManagerUser(){
        super("Icefox & Co.");
    }
}