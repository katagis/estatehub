package estatehub.frontend.controllers.owner;

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

    @GetMapping("/owner/offersfor")
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


        return "owner/offersfor";
    }

}