package estatehub.frontend;

import java.util.Optional;

import javax.servlet.http.HttpSession;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.servlet.ModelAndView;

import estatehub.model.Database;
import estatehub.model.ManagerUser;
import estatehub.model.OwnerUser;
import estatehub.model.User;

@Controller
public class IndexController {

    @GetMapping("/")
    public String homePage(HttpSession session, Model model) {
        User user = Database.getUserOrLogin(session);

        model.addAttribute("user", user);
        return "index";
    }

    @GetMapping("/login")
    public String loginHandler(HttpSession session, Optional<Integer> id) {
        if (id.isPresent()){
            session.setAttribute("id", id.get());
        }
        else{
            session.setAttribute("id", null);
        }
        return "redirect:/";
    } 


    @GetMapping("/rename")
    public String rename(HttpSession session, Optional<String> name) {
        User user = Database.getUserOrLogin(session);

        user.setName(name.orElse("Nameless"));
        
        return "redirect:/";
    }
} 