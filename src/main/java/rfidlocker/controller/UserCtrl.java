package rfidlocker.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.servlet.ModelAndView;

import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpSession;
import rfidlocker.service.UsersService;

@CrossOrigin
@Controller
public class UserCtrl {
	@Autowired
	UsersService usersService;
	//查詢此使用者是否存在
	@GetMapping(value = "/api/User/{email}")
	public ModelAndView getAllBox(HttpServletRequest request) {
		ModelAndView mv = null;
		HttpSession session = request.getSession();

		System.out.println(usersService.getUserByEmail(request.getParameter("email")));
//	    	mv = new ModelAndView("login");
//	    	mv.addObject("status","success");
//	    	mv.addObject("boxesList",boxesService.getAllBoxes());
		return mv;
	}
}
