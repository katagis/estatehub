package estatehub.frontend.controllers.manager;

import java.util.Optional;
import java.util.Vector;

import javax.servlet.http.HttpSession;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.servlet.ModelAndView;

import estatehub.model.Database;
import estatehub.model.Estate;
import estatehub.model.ManagerUser;
import estatehub.model.Offer;
import estatehub.model.OwnerUser;

@Controller
public class CreateOfferController {

    @GetMapping("/manager/createoffer")
    public ModelAndView createOfferForm(HttpSession session, Optional<Integer> eid) {
        if (!eid.isPresent()) {
            return new ModelAndView("redirect:/index");
        }

        ManagerUser user = Database.getManagerUser(session);
        Estate estate = Database.getEstate(eid.get());

        ModelAndView mv = new ModelAndView("manager/createoffer_form", "offer", new Offer(eid.get()));
        mv.getModel().put("user", user);
        mv.getModel().put("estate", estate);
        return mv;
    }

    @PostMapping("/manager/createoffer")
    public ModelAndView createOfferPost(HttpSession session, @ModelAttribute("offer") Offer offer) {
        ManagerUser user = Database.getManagerUser(session);
        Estate estate = Database.getEstate(offer.getEstateId());


        ModelAndView mv = new ModelAndView("manager/createoffer_post");
        mv.getModel().put("user", user);
        mv.getModel().put("estate", estate);
        mv.getModel().put("offer", offer);
        return mv;
    }
    
}