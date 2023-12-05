package rfidlocker.service;

import java.util.List;
import java.util.Optional;

import jakarta.servlet.http.HttpServletRequest;
import rfidlocker.entity.Appointment;
import rfidlocker.model.Appointment.AppointmentDao;

public interface AppointmentService {
//	Appointment addAppointment(Integer boxId, String buyerEmail, Integer sellerId, LocalDateTime buyerStartTime,
//			LocalDateTime buyerEndTime, LocalDateTime sellerStartTime, LocalDateTime sellerEndTime);
	Appointment addAppointment(AppointmentDao body);
	List<Appointment> findAllBySellerId(Integer userId);
	List<Appointment> findAllByBuyerId(Integer userId);
	Appointment findById(Integer appointmentId);
	Appointment delByAppointmentId(Integer appointmentId , HttpServletRequest request);
	Appointment afterOpenByAppointmentId(Integer appointmentId , HttpServletRequest request , Integer operationCode);
}
