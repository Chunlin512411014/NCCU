package rfidlocker.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.servlet.ModelAndView;

import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpSession;
import rfidlocker.model.Appointment.AppointmentDao;
import rfidlocker.service.AppointmentService;

@CrossOrigin
@Controller
public class AppointmentCtrl {
	@Autowired
	AppointmentService appointmentService;

	// 新增約會
	@PostMapping(value = "/api/appointment")
	public ModelAndView addAppointment(HttpServletRequest request, @RequestBody AppointmentDao body) {
		ModelAndView mv = null;
		HttpSession session = request.getSession();
		try {

			System.out.println(appointmentService.addAppointment(body));
//	    	mv = new ModelAndView("login");
//	    	mv.addObject("status","success");
//	    	mv.addObject("boxesList",boxesService.getBoxesById(boxId));
		} catch (RuntimeException e) {
			System.out.println(e);
		}

		return mv;
	}

	// 查詢所有約會
	@GetMapping(value = "/api/appointment/user/{userId}")
	public ModelAndView getAllAppointment(HttpServletRequest request, @PathVariable Integer userId) {
		ModelAndView mv = null;
		HttpSession session = request.getSession();
		System.out.println("buyer list");
		System.out.println(appointmentService.findAllByBuyerId(userId));
		System.out.println("seller list");
		System.out.println(appointmentService.findAllBySellerId(userId));
//	    	mv = new ModelAndView("login");
//	    	mv.addObject("status","success");
//	    	mv.addObject("buyerList",appointmentService.findAllByBuyerId(userId));
//	    	mv.addObject("sellerList",appointmentService.findAllBySellerId(userId));
		return mv;
	}

	// 查詢特定約會
	@GetMapping(value = "/api/appointment/{appointmentId}")
	public ModelAndView getAppointment(HttpServletRequest request, @PathVariable Integer appointmentId) {
		ModelAndView mv = null;
		HttpSession session = request.getSession();
		System.out.println(appointmentService.findById(appointmentId));
//		    	mv = new ModelAndView("login");
//		    	mv.addObject("status","success");
//		    	mv.addObject("buyerList",appointmentService.findAllByBuyerId(userId));
//		    	mv.addObject("sellerList",appointmentService.findAllBySellerId(userId));
		return mv;
	}

	// 取消約會
	@DeleteMapping(value = "/api/appointment/{appointmentId}")
	public ModelAndView cancelAppointment(HttpServletRequest request, @PathVariable Integer appointmentId) {
		ModelAndView mv = null;
		HttpSession session = request.getSession();
		System.out.println(appointmentService.delByAppointmentId(appointmentId, request));
//		    	mv = new ModelAndView("login");
//		    	mv.addObject("status","success");
//		    	mv.addObject("buyerList",appointmentService.findAllByBuyerId(userId));
//		    	mv.addObject("sellerList",appointmentService.findAllBySellerId(userId));
		return mv;
	}

	// 取貨後動作
	@PutMapping(value = "/api/appointment/{appointmentId}/{operationCode}")
	public ModelAndView afterOpenByAppointmentId(HttpServletRequest request, @PathVariable Integer appointmentId ,@PathVariable Integer operationCode) {
		ModelAndView mv = null;
		HttpSession session = request.getSession();
//		System.out.println(appointmentService.delByAppointmentId(appointmentId, request , operationCode));
//				    	mv = new ModelAndView("login");
//				    	mv.addObject("status","success");
//				    	mv.addObject("buyerList",appointmentService.findAllByBuyerId(userId));
//				    	mv.addObject("sellerList",appointmentService.findAllBySellerId(userId));
		return mv;
	}

}