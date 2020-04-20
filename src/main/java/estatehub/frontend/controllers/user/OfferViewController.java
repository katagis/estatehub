package estatehub.frontend.controllers.user;

import java.util.Optional;
import java.util.Vector;

import javax.servlet.http.HttpSession;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;

import estatehub.model.Database;
import estatehub.model.Estate;
import estatehub.model.Offer;
import estatehub.model.OwnerUser;

@Controller
public class OfferViewController {

    @GetMapping("/user/offers")
    public String allOffers(HttpSession session, Model model) {
        OwnerUser manager = Database.getOwnerUser(session);

        model.addAttribute("user", manager);
        return "index";
    }


    @GetMapping("/user/offersfor")
    public String offersFor(HttpSession session, Model model, Optional<Integer> eid) {
        if (!eid.isPresent()) {
            return "redirect:/user/offers";
        }

        OwnerUser user = Database.getOwnerUser(session);
        Estate estate = Database.getEstate(eid.get());
        Vector<Offer> offers = estate.getOffers();

        model.addAttribute("user", user);
        model.addAttribute("estate", estate);
        model.addAttribute("offers", offers);

        return "offersfor";
    }

}