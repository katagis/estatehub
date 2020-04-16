package estatehub.frontend;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ResponseBody;

import estatehub.model.ManagerUser;
import estatehub.model.OwnerUser;
import estatehub.model.User;

@Controller
public class HtmlController {
    
    @GetMapping(value = "/")
    @ResponseBody
    public String Example() {
        User user = new ManagerUser();

        PageView page = HtmlBuilder.generatePage(user);

        page.addHeader("Content goes here.");
        
        return page.getHtml();
    }
} 