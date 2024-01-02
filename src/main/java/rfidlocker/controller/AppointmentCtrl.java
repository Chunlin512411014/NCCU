package rfidlocker.controller;

import java.time.LocalDateTime;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.format.annotation.DateTimeFormat;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.servlet.ModelAndView;

import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpSession;
import lombok.extern.slf4j.Slf4j;
import rfidlocker.model.Appointment.AppointmentDao;
import rfidlocker.service.AppointmentService;
import rfidlocker.service.impl.BoxesServiceImpl;

@CrossOrigin
@Controller
@Slf4j
/*
 * 訂單controller
 */
public class AppointmentCtrl {
	// 注入 AppointmentService 介面
	@Autowired
	AppointmentService appointmentService;

	// 新增約會
	@PostMapping(value = "/api/appointment")
	public ModelAndView addAppointment(HttpServletRequest request,
			@RequestParam(name = "boxId", required = true) Integer boxId,
			@RequestParam("reservationTime") @DateTimeFormat(iso = DateTimeFormat.ISO.DATE_TIME) LocalDateTime reservationTime,
			@RequestParam("expiryTime") @DateTimeFormat(iso = DateTimeFormat.ISO.DATE_TIME) LocalDateTime expiryTime,
			@RequestParam("receiverEmail") String receiverEmail) {
		ModelAndView mv = null;
		HttpSession session = request.getSession();
		try {
			System.out.println("boxId = " + boxId);
			System.out.println(request.getSession().getAttribute("userId"));
			System.out.println("reservationTime = " + reservationTime);
			System.out.println(
					appointmentService.addAppointment(request, boxId, reservationTime, expiryTime, receiverEmail));
			System.out.println("新增約會成功 !");

			Integer userId = (Integer) session.getAttribute("userId");
			System.out.println("buyer list");
			System.out.println(appointmentService.findAllByBuyerId(userId));
			System.out.println("seller list");
			System.out.println(appointmentService.findAllBySellerId(userId));
			mv = new ModelAndView("order-list");
			mv.addObject("status", "success");
			mv.addObject("buyerList", appointmentService.findAllByBuyerId(userId));
			mv.addObject("sellerList", appointmentService.findAllBySellerId(userId));
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
		mv = new ModelAndView("order-list");
		mv.addObject("status", "success");
		mv.addObject("buyerList", appointmentService.findAllByBuyerId(userId));
		mv.addObject("sellerList", appointmentService.findAllBySellerId(userId));
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

	// 完成取貨
	@GetMapping(value = "/api/appointment/{appointmentId}/complete")
	public ModelAndView afterOpenByAppointmentId(HttpServletRequest request, @PathVariable Integer appointmentId) {
		ModelAndView mv = null;
		HttpSession session = request.getSession();
		try {
			System.out.println("appointmentId = "+appointmentId);
//			Integer appointmentIdInt = Integer.parseInt(appointmentId);
			appointmentService.modifyAppointmentStatusByAppointment(appointmentId, request);
		} catch (Exception e) {
			log.info(e.getMessage());
			e.printStackTrace();
		}
		Integer userId = (Integer)session.getAttribute("userId");
		System.out.println("buyer list");
		System.out.println(appointmentService.findAllByBuyerId(userId));
		System.out.println("seller list");
		System.out.println(appointmentService.findAllBySellerId(userId));
		mv = new ModelAndView("order-list");
		mv.addObject("status", "success");
		mv.addObject("buyerList", appointmentService.findAllByBuyerId(userId));
		mv.addObject("sellerList", appointmentService.findAllBySellerId(userId));
		return mv;
	}

}
