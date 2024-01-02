package rfidlocker.service.impl;

import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpSession;
import rfidlocker.entity.Appointment;
import rfidlocker.entity.Boxes;
import rfidlocker.entity.Users;
import rfidlocker.model.Appointment.AppointmentDao;
import rfidlocker.model.Appointment.OrderDao;
import rfidlocker.repository.AppointmentJpaRepository;
import rfidlocker.repository.BoxesJpaRepository;
import rfidlocker.repository.UsersJpaRepository;
import rfidlocker.service.AppointmentService;
/*
 * Appointment Service interface 實作
 * 撰寫商業邏輯
 * */
@Service
public class AppointmentServiceImpl implements AppointmentService {
	@Autowired
	UsersJpaRepository usersJpaRepository;
	@Autowired
	AppointmentJpaRepository appointmentJpaRepository;
	@Autowired
	BoxesJpaRepository boxesJpaRepository;

	//新增約會(訂單
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
	/*
	 * 以賣家id為查詢條件 抓取訂單list
	 * */
	@Override
	public List<OrderDao> findAllBySellerId(Integer userId) {
		//我是賣家
		Users seller = usersJpaRepository.findById(userId).orElseThrow(() -> new IllegalStateException("賣家不存在"));
		List<Appointment> appointmentList = appointmentJpaRepository.findAllBySellerId(userId);
		List<OrderDao> orderDaoList = new ArrayList<>();
		
		appointmentList.forEach(n->{
			OrderDao orderDao = new OrderDao();
			Boxes boxes = boxesJpaRepository.findById(n.getBoxId()).get();
			Users buyer = usersJpaRepository.findById(n.getBuyerId()).orElseThrow(() -> new IllegalStateException("賣家不存在"));
			orderDao.setAppointmentId(n.getId());
			orderDao.setBoxId(n.getBoxId());
			orderDao.setBoxName(boxes.getName());
			orderDao.setLocation(boxes.getLocation());
			orderDao.setSupplierEmail(seller.getEmail());
			orderDao.setRecipientEmail(buyer.getEmail());
			System.out.println("取貨狀態碼 = "+n.getStatus());
			switch(n.getStatus()) {
			case 1 :
				orderDao.setStatus("未到貨");
				break;
			case 2 :
				orderDao.setStatus("已到貨");
				break;
			case 3 :
				orderDao.setStatus("已取貨");
				break;
			case 4 :
				orderDao.setStatus("完成");
				break;
			}
			orderDaoList.add(orderDao);
			
		});
		
		return orderDaoList;
	}
	/*
	 * 以買家id為查詢條件 抓取訂單list
	 * */
	@Override
	public List<OrderDao> findAllByBuyerId(Integer userId) {
		List<OrderDao> orderDaoList = new ArrayList<>();
		//我是買家
		Users buyer = usersJpaRepository.findById(userId).orElseThrow(() -> new IllegalStateException("買家不存在"));
		List<Appointment> appointmentList = appointmentJpaRepository.findAllByBuyerId(userId);
		
		appointmentList.forEach(n->{
			OrderDao orderDao = new OrderDao();
			Boxes boxes = boxesJpaRepository.findById(n.getBoxId()).get();
			Users seller = usersJpaRepository.findById(n.getSellerId()).orElseThrow(() -> new IllegalStateException("賣家不存在"));
			orderDao.setAppointmentId(n.getId());
			orderDao.setBoxId(n.getBoxId());
			orderDao.setBoxName(boxes.getName());
			orderDao.setLocation(boxes.getLocation());
			orderDao.setSupplierEmail(seller.getEmail());
			orderDao.setRecipientEmail(buyer.getEmail());
			
			switch(n.getStatus()) {
			case 1 :
				orderDao.setStatus("未到貨");
				break;
			case 2 :
				orderDao.setStatus("已到貨");
				break;
			case 3 :
				orderDao.setStatus("已取貨");
				break;
			case 4 :
				orderDao.setStatus("完成");
				break;
			}
			orderDaoList.add(orderDao);
			
		});
		
		return orderDaoList;
	}
	//查詢特定訂單
	@Override
	public Appointment findById(Integer appointmentId) {
//		Users user  = usersJpaRepository.findById(userId).orElseThrow(()->new IllegalStateException("買家不存在"));
		Appointment appointment = appointmentJpaRepository.findById(appointmentId).orElseThrow(() -> new IllegalStateException("此約會不存在"));
		return appointment;
	}
	/*
	 * 刪除訂單（更改狀態）為 cancel
	 * */
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

	/*
	 * 新增訂單
	 * */
	@Override
	public Appointment addAppointment(HttpServletRequest request , Integer boxId, LocalDateTime reservationTime, LocalDateTime expiryTime,
			String receiverEmail) {
		try {
			HttpSession session = request.getSession();
			Boxes boxes = boxesJpaRepository.findById(boxId)
					.orElseThrow(() -> new IllegalStateException("box不存在"));
			if (!"A".equals(boxes.getStatus()))
				throw new IllegalStateException("box已經有人使用");
			
			Users seller = usersJpaRepository.findById((Integer)session.getAttribute("userId"))
					.orElseThrow(() -> new IllegalStateException("賣家不存在"));

			Users buyer = usersJpaRepository.findByEmail(receiverEmail)
					.orElseThrow(() -> new IllegalStateException("買家不存在"));
			Appointment appointment = new Appointment();
			appointment.setBoxId(boxId);
			appointment.setBuyerId(buyer.getId());
			appointment.setSellerId(seller.getId());
			appointment.setStatus(1);
//			appointment.setSellerStartTime(body.getSellerStartTime());
//			appointment.setSellerEndTime(body.getSellerEndTime());
//			appointment.setBuyerStartTime(body.getBuyerStartTime());
//			appointment.setBuyerEndTime(body.getSellerEndTime());
			appointment = appointmentJpaRepository.save(appointment);
			boxes.setReservationTime(reservationTime);
			boxes.setExpiryTime(expiryTime);
			boxes.setStatus("UA");
			boxesJpaRepository.save(boxes);
			
			return appointment;
			
		} catch (IllegalStateException e) {
			e.printStackTrace();
			throw e;
		}
	}
	@Override
	public
	Appointment modifyAppointmentStatusByAppointment(Integer appointmentId, HttpServletRequest request) {
		// TODO Auto-generated method stub
		Appointment appointment = appointmentJpaRepository.findById(appointmentId).orElseThrow(() -> new IllegalStateException("此約會不存在"));
		if(appointment.getStatus()!=3) {
			throw  new IllegalStateException("此訂單還未取貨");
		}else {
			appointment.setStatus(4);
			appointmentJpaRepository.save(appointment);
		}
		
		return appointment;
	}

}
