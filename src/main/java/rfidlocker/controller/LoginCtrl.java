package rfidlocker.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.view.RedirectView;

import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import jakarta.servlet.http.HttpSession;
import rfidlocker.entity.Users;
import rfidlocker.repository.UsersJpaRepository;
import rfidlocker.utils.SessionUtil;

@CrossOrigin
@Controller
public class LoginCtrl {
	
	@Autowired 
	UsersJpaRepository usersJpaRepository;
	
	@GetMapping(value ="/login-test" )
	public ModelAndView getHelloWorld(HttpServletRequest request) {
		ModelAndView mv = null;
		mv = new ModelAndView("thymeleaf_hello_world");
		mv.addObject("message","我來拉世界");
		return mv;		
		
	}
	
	 @GetMapping("/login")
	    public ModelAndView login(HttpServletRequest request, HttpServletResponse response) {
	    	ModelAndView mv = null;
	    	HttpSession session = request.getSession();
	    	if (session.getAttribute("accountId") != null) {
	    		
	    		mv = new ModelAndView(new RedirectView("user-login"));
				return mv;		

	    	}
	  
	    	mv = new ModelAndView("login");
	    	return mv;
	    }
	    


	    @RequestMapping(value = "/user-login", method = {RequestMethod.GET, RequestMethod.POST})
	    public ModelAndView userLogin(HttpServletRequest request) {
	    	ModelAndView mv ;
	    	System.out.println(request.getParameter("username"));
	    	System.out.println(request.getParameter("password"));
	    	
	    	HttpSession session = request.getSession();
	    	SessionUtil.setSessionId(session);
	    	SessionUtil.setSessionMap(session);
	    	Users users = usersJpaRepository.findByEmailAndPassword(request.getParameter("email"), request.getParameter("password")).orElse(null);
	    	
	    	if(users == null) {
	    		
		    	if (session.getAttribute("id") == null) {
					mv = new ModelAndView(new RedirectView("login"));
		    		mv.addObject("errorMessage","帳號密碼錯誤");
		    		return mv;
	    		}
	    	} 


	    	return null;
	    }

}
