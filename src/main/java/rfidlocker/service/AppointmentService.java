package rfidlocker.service;

import java.time.LocalDateTime;
import java.util.List;

import jakarta.servlet.http.HttpServletRequest;
import rfidlocker.entity.Appointment;
import rfidlocker.model.Appointment.AppointmentDao;
import rfidlocker.model.Appointment.OrderDao;

public interface AppointmentService {
//	Appointment addAppointment(Integer boxId, String buyerEmail, Integer sellerId, LocalDateTime buyerStartTime,
//			LocalDateTime buyerEndTime, LocalDateTime sellerStartTime, LocalDateTime sellerEndTime);
	Appointment addAppointment(AppointmentDao body);
	Appointment addAppointment(HttpServletRequest request, Integer boxId , LocalDateTime reservationTime , LocalDateTime expiryTime , String receiverEmail);
	List<OrderDao> findAllBySellerId(Integer userId);
	List<OrderDao> findAllByBuyerId(Integer userId);
	Appointment findById(Integer appointmentId);
	Appointment delByAppointmentId(Integer appointmentId , HttpServletRequest request);
	Appointment afterOpenByAppointmentId(Integer appointmentId , HttpServletRequest request , Integer operationCode);
}
