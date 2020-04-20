package estatehub.frontend.controllers;

import javax.servlet.http.HttpSession;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;

import estatehub.model.Database;
import estatehub.model.ManagerUser;

@Controller
public class SearchController {

    @GetMapping("/search")
    public String searchHome(HttpSession session, Model model) {
        ManagerUser manager = Database.getManagerUser(session);

        model.addAttribute("user", manager);
        return "index";
    }
}