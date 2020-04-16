package estatehub.frontend;

import estatehub.model.ManagerUser;
import estatehub.model.User;

// Singleton that loads and provides html for a single pageview.
// Use from controllers together with PageView to construct a page to return from your controller.
public class HtmlBuilder {

    // This class acts like an oversimplified template engine that should be just enough for our simple demo purposes.
    // We decided against using a third-party because we would have to spend more time learning it than rolling a simple version ourselves.
    private static final HtmlBuilder instance = new HtmlBuilder();

    private String baseHeaderOpen;
    private String baseHeaderClose;
    private String baseFooter;

    private String ownerHeader;
    private String managerHeader;

    private static HtmlBuilder getInstance() {
        return instance;
    }

    private HtmlBuilder() {
        // TODO: Add support for custom titles
        // TODO: Load resources from files...

        baseHeaderOpen = "<html><header><title>EstateHub</title></header><body><h1>Welcome To EstateHub</h1>"
                + "<div><p>";

        baseHeaderClose = "</p></div><div>";
        ownerHeader = "Welcome Corona Smith";

        managerHeader = "Welcome Icefox & Co.";
        baseFooter = "</div></body>";
    }

    private PageView generatePageImpl(User forUser) {
        String buffer = baseHeaderOpen;

        // TODO: Inject username

        // CHECK:
        // This should probably be done in an oop-like way but I want to avoid cluttering the model with front-end stuff
        if (forUser instanceof ManagerUser){
            buffer += managerHeader;
        }
        else{
            buffer += ownerHeader;
        }

        buffer += baseHeaderClose;
        return new PageView(buffer, baseFooter);
    }

    // Generates a PageView object with headers for the specified user. See PageView class.
    public static PageView generatePage(User forUser) {
        return getInstance().generatePageImpl(forUser);
    }

}