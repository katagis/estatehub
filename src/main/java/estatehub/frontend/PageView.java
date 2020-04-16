package estatehub.frontend;


// Temporary object that constructs an html page from code.
public class PageView {

    private String buf;
    private String htmlEnd;

    private boolean hasBeenGenerated = false;

    public PageView(String htmlBegin, String htmlEnd_) {
        buf = htmlBegin;
        htmlEnd = htmlEnd_;
    }

    // Finalizes the page and returns the html string.
    // You CAN NOT add any more elements to the page after calling this function.
    public String getHtml()
    {
        if (hasBeenGenerated){
            return buf;
        }
        
        hasBeenGenerated = true;
        buf += htmlEnd;
        return buf;
    }

    public void addHeader(String headerText, int level) {
        buf += "<h" + level + ">" + headerText + "</h" + level + ">";
    }

    public void addHeader(String headerText) {
        addHeader(headerText, 1);
    }

}