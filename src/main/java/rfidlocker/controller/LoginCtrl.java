package rfidlocker.controller;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.view.RedirectView;

import jakarta.servlet.http.HttpServletRequest;

@CrossOrigin
@Controller
public class LoginCtrl {
	
	@GetMapping(value ="/login" )
	public ModelAndView getHelloWorld(HttpServletRequest request) {
		ModelAndView mv = null;
		mv = new ModelAndView("thymeleaf_hello_world");
		mv.addObject("message","我來拉世界");
		return mv;		
		
	}

}
