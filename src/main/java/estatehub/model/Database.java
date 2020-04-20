package estatehub.model;

import javax.servlet.http.HttpSession;
import java.util.Vector;

// Simple singleton class in memory for a database.
// Provides an easy to use interface for controllers and aggregates all our model classes.
// Most functions handle errors or misses by providing a "valid" default object to reduce error handling in controllers.
// This may not be a good programming practice but works good enough for this demo project
public class Database {

    private static Database instance;

    private static Database getInstance() {
        if (instance == null) {
            instance = new Database();
        }
        return instance;
    }

    private Vector<User> users;
    private Vector<Estate> estates;

    Database() {
        users = new Vector<User>();
        users.add(new OwnerUser());
        users.add(new ManagerUser());
    }

    // Grabs the user with this session, returns null on errors
    public static User getUser(HttpSession session) {
        // This actual implementation does not include password checking or anything
        // security related. We just use a single id to identify the user.
        User user = null;

        try {
            Integer id = (Integer) session.getAttribute("id");
            user = getInstance().users.get(id);
        } catch (Exception e) {
        }
        return user;
    }

    // Grabs the user with this session, logs in a default OwnerUser on errors
    public static User getUserOrLogin(HttpSession session) {
        User user = null;
        user = getUser(session);
        if (user == null) {
            user = getInstance().users.get(0);
            session.setAttribute("id", 0);
        }
        return user;
    }

    // Grabs the owner user with this session, returns a default OwnerUser on errors
    public static OwnerUser getOwnerUser(HttpSession session) {
        OwnerUser user = null;
        try {
            user = (OwnerUser) getUser(session);
        } catch (Exception e) {
        }

        if (user == null) {
            user = (OwnerUser) getInstance().users.get(0);
            session.setAttribute("id", 0);
        }

        return user;
    }

    // Grabs the manager user with this session, returns a default manager user on
    // errors
    public static ManagerUser getManagerUser(HttpSession session) {
        if (session == null) {
            return (ManagerUser) getInstance().users.get(1);
        }
        
        ManagerUser user = null;
        try {
            user = (ManagerUser) getUser(session);
        } catch (Exception e) {
        }

        if (user == null) {
            user = (ManagerUser) getInstance().users.get(1);
            session.setAttribute("id", 1);
        }

        return user;
    }

    public static Estate getEstate(int estateId) {
        return new Estate();
    }
}