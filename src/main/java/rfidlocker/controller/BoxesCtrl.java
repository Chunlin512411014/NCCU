package rfidlocker.controller;

import java.time.LocalDateTime;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.servlet.ModelAndView;

import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpSession;
import rfidlocker.service.BoxesService;

@CrossOrigin
@Controller
public class BoxesCtrl {

	@Autowired
	BoxesService boxesService;

	
	/*
	 * boxesList 回傳所有box 的資料
	 * 
	 * boxes entity
	 * 	Integer id;
	 *  String name;
	 *  String location;
	 *  String status;
	 *  LocalDateTime useTime;
	 *  LocalDateTime createdTime;
	 * 
	 * */
	// 取得所有可選box
	@GetMapping(value = "/api/Boxes")
	public ModelAndView getAllBox(HttpServletRequest request) {
		ModelAndView mv = null;
		HttpSession session = request.getSession();

		System.out.println(boxesService.getAllBoxes());
//	    	mv = new ModelAndView("login");
	    	mv.addObject("status","success");
	    	mv.addObject("boxesList",boxesService.getAllBoxes());
		return mv;
	}

	// 取得特定箱子
	@GetMapping(value = "/api/Boxes/{boxId}")
	public ModelAndView getAllBox(HttpServletRequest request, @PathVariable Integer boxId) {
		ModelAndView mv = null;
		HttpSession session = request.getSession();

		System.out.println(boxesService.getBoxesById(boxId));
		//添加你所想要添加的html
	    	mv = new ModelAndView("login");
	    	mv.addObject("status","success");
	    	mv.addObject("boxes",boxesService.getBoxesById(boxId));
		return mv;
	}

	// 新增箱子
	@PostMapping(value = "/api/Boxes")
	public ModelAndView addBox(HttpServletRequest request) {
		ModelAndView mv = null;
		HttpSession session = request.getSession();
		try {
			System.out.println(boxesService.addBoxes(request.getParameter("name"), request.getParameter("location")));
//	    	mv = new ModelAndView("login");
//	    	mv.addObject("status","success");
//	    	mv.addObject("boxesList",boxesService.getBoxesById(boxId));
		} catch (RuntimeException e) {
			System.out.println(e);
		}

		return mv;
	}
	
	// 修改箱子
		@PutMapping(value = "/api/Boxes")
		public ModelAndView modifyBox(HttpServletRequest request) {
			ModelAndView mv = null;
			HttpSession session = request.getSession();
			try {
				Integer boxId = 0;
				boxId =	Integer.parseInt(request.getParameter("id")) ; 
				System.out.println(boxesService.modifyBoxes(
						boxId,
						request.getParameter("name"),
						request.getParameter("location"),
						request.getParameter("status")
						));
//		    	mv = new ModelAndView("login");
//		    	mv.addObject("status","success");
//		    	mv.addObject("boxesList",boxesService.getBoxesById(boxId));
			} catch (RuntimeException e) {
				System.out.println(e);
			}

			return mv;
		}

}
