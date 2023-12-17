package rfidlocker.service.impl;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpSession;
import rfidlocker.entity.Appointment;
import rfidlocker.entity.Boxes;
import rfidlocker.entity.Users;
import rfidlocker.model.Appointment.AppointmentDao;
import rfidlocker.repository.AppointmentJpaRepository;
import rfidlocker.repository.BoxesJpaRepository;
import rfidlocker.repository.UsersJpaRepository;
import rfidlocker.service.AppointmentService;

@Service
public class AppointmentServiceImpl implements AppointmentService {
	@Autowired
	UsersJpaRepository usersJpaRepository;
	@Autowired
	AppointmentJpaRepository appointmentJpaRepository;
	@Autowired
	BoxesJpaRepository boxesJpaRepository;

	@Override
	public Appointment addAppointment(AppointmentDao body) {
		try {
			Boxes boxes = boxesJpaRepository.findById(body.getBoxId())
					.orElseThrow(() -> new IllegalStateException("box不存在"));
			if (!"A".equals(boxes.getStatus()))
				throw new IllegalStateException("box已經有人使用");
		

			Users buyer = usersJpaRepository.findByEmail(body.getBuyerEmail())
					.orElseThrow(() -> new IllegalStateException("買家不存在"));
			Appointment appointment = new Appointment();
			appointment.setBoxId(body.getBoxId());
			appointment.setBuyerId(buyer.getId());
			appointment.setSellerId(body.getSellerId());
			appointment.setStatus(1);
			appointment.setSellerStartTime(body.getSellerStartTime());
			appointment.setSellerEndTime(body.getSellerEndTime());
			appointment.setBuyerStartTime(body.getBuyerStartTime());
			appointment.setBuyerEndTime(body.getSellerEndTime());
			appointment = appointmentJpaRepository.save(appointment);
			
			boxes.setStatus("UA");
			boxesJpaRepository.save(boxes);
			
			return appointment;
		} catch (IllegalStateException e) {

			throw e;
		}

	}

	@Override
	public List<Appointment> findAllBySellerId(Integer userId) {
		Users user = usersJpaRepository.findById(userId).orElseThrow(() -> new IllegalStateException("買家不存在"));
		List<Appointment> appointmentList = appointmentJpaRepository.findAllBySellerId(userId);

		return appointmentList;
	}

	@Override
	public List<Appointment> findAllByBuyerId(Integer userId) {
		Users user = usersJpaRepository.findById(userId).orElseThrow(() -> new IllegalStateException("買家不存在"));
		List<Appointment> appointmentList = appointmentJpaRepository.findAllByBuyerId(userId);
		return appointmentList;
	}

	@Override
	public Appointment findById(Integer appointmentId) {
//		Users user  = usersJpaRepository.findById(userId).orElseThrow(()->new IllegalStateException("買家不存在"));
		Appointment appointment = appointmentJpaRepository.findById(appointmentId).orElseThrow(() -> new IllegalStateException("此約會不存在"));
		return appointment;
	}

	@Override
	public Appointment delByAppointmentId(Integer appointmentId ,HttpServletRequest request) {
//		HttpSession session = request.getSession();
//		Users user = usersJpaRepository.findById((Integer)session.getAttribute("userId")).orElseThrow(() -> new IllegalStateException("錯誤"));
		Appointment appointment = appointmentJpaRepository.findById(appointmentId).orElseThrow(() -> new IllegalStateException("此約會不存在"));
		Boxes boxes = boxesJpaRepository.findById(appointment.getBoxId())
				.orElseThrow(() -> new IllegalStateException("box不存在"));
		//釋放box
		boxes.setStatus("A");
		boxesJpaRepository.save(boxes);
		//更改回傳值為99 cancel
		appointment.setStatus(99);
		appointment = appointmentJpaRepository.save(appointment);
		
		return appointment;
	}
	
	/*
	 * status code 1:Booking ; 2:Booking open; 3:waiting ;4 buyer open; 5: complete 6:return; 7:return open ; 8:finish ; 99 cancel
	 * 
	 * operationCode 1.complete 2.return
	 * */
	@Override
	public Appointment afterOpenByAppointmentId(Integer appointmentId, HttpServletRequest request ,Integer operationCode) {
//		HttpSession session = request.getSession();
//		Users user = usersJpaRepository.findById((Integer)session.getAttribute("userId")).orElseThrow(() -> new IllegalStateException("錯誤"));
		Appointment appointment = appointmentJpaRepository.findById(appointmentId).orElseThrow(() -> new IllegalStateException("此約會不存在"));
		Boxes boxes = boxesJpaRepository.findById(appointment.getBoxId())
				.orElseThrow(() -> new IllegalStateException("box不存在"));
		if(appointment.getStatus()!=4) {
			throw new IllegalStateException("還沒開啟箱子");
		}
		//釋放box
		boxes.setStatus("A");
		boxesJpaRepository.save(boxes);
		//更改回傳值為99 cancel
		appointment.setStatus(8);
		appointment = appointmentJpaRepository.save(appointment);
		return appointment;
		
		
		
	}

}