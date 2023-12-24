package rfidlocker.controller;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.view.RedirectView;

import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpSession;
import rfidlocker.entity.Boxes;
import rfidlocker.entity.Users;
import rfidlocker.repository.UsersJpaRepository;
import rfidlocker.service.BoxesService;

@CrossOrigin
@Controller
public class LoginCtrl {
	
	@Autowired 
	UsersJpaRepository usersJpaRepository;
	@Autowired
	BoxesService boxesService;
	
	@GetMapping(value ="/login-test" )
	public ModelAndView getHelloWorld(HttpServletRequest request) {
		ModelAndView mv = null;
		Users user = usersJpaRepository.findById(1).get();
		mv = new ModelAndView("thymeleaf_hello_world");
		mv.addObject("message","hello world");
		mv.addObject("user",user);
		
		return mv;		
		
	}
	
//	 @PostMapping("/api/user/login")
	//登入頁面
	 @GetMapping(value = "/api/login")
	    public ModelAndView login(HttpServletRequest request) {
	    	ModelAndView mv = null;
	    	HttpSession session = request.getSession();
	    	if (session.getAttribute("userId") != null) {
	    		System.out.println("有觸發？");
	    		mv = new ModelAndView(new RedirectView("index"));
				return mv;		

	    	}
	    	System.out.println("開始轉導");
	    	mv = new ModelAndView("login");
	    	return mv;
	    }
	    


	    @RequestMapping(value = "/api/user-login", method = {RequestMethod.GET, RequestMethod.POST})
	    public ModelAndView userLogin(HttpServletRequest request) {
	    	ModelAndView mv ;
	    	System.out.println(request.getParameter("userEmail"));
	    	System.out.println(request.getParameter("password"));
	    	
	    	HttpSession session = request.getSession();
//	    	SessionUtil.setSessionId(session);
//	    	SessionUtil.setSessionMap(session);
	    	Users users = usersJpaRepository.findByEmailAndPassword(request.getParameter("userEmail"), request.getParameter("password")).orElse(null);
	    	List<Boxes> boxes = boxesService.getAllBoxes();
	    	if(users == null) {
					mv = new ModelAndView(new RedirectView("login"));
		    		mv.addObject("status","error");
		    		mv.addObject("desc","帳號密碼錯誤");
		    		return mv;
	    	}else {
	    		session.setAttribute("userName", users.getName());    	
	    		session.setAttribute("userId", users.getId());    	
	    		session.setAttribute("email", users.getEmail());    	
//	    		session.setAttribute("remoteAddr", request.getRemoteAddr());
//    			mv = new ModelAndView("box-list");
    			mv = new ModelAndView("index");
    			
	    		mv.addObject("status","success");
	    		mv.addObject("boxes",boxes);
	    		mv.addObject("user",users);
	    		
	    		
	    		return mv;
    		}

	    }

}
