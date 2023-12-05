package rfidlocker.service.impl;

import java.util.Arrays;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import rfidlocker.entity.Appointment;
import rfidlocker.entity.Users;
import rfidlocker.repository.AppointmentJpaRepository;
import rfidlocker.repository.UsersJpaRepository;
import rfidlocker.service.RfidService;

@Service
public class RfidServiceImpl implements RfidService{
	@Autowired
	AppointmentJpaRepository appointmentJpaRepository;
	
	@Autowired
	UsersJpaRepository usersJpaRepository;
	@Override
	public String checkCardNOAndBoxId(String cardNo, Integer boxId) {
		
		Users user = usersJpaRepository.findByRfidToken(cardNo).orElseThrow(() -> new IllegalStateException("此辨識卡不存在"));
		/*
		 * status code 1:Booking ; 2:Booking open; 3:waiting ;4 buyer open; 5: complete 6:return; 7:return open ; 8:finish ; 99 cancel
		 * 
		 * */
		Integer[] statusArrsy = {1,2,3,4,6,7};
		List<Integer> statusList = Arrays.asList(statusArrsy);
		
		Appointment appointment = appointmentJpaRepository.findByBoxIdAndStatusIn(boxId, statusList).orElseThrow(() -> new IllegalStateException("no appointment"));
		switch(appointment.getStatus()) {
		case 1 :
			if(appointment.getSellerId()==user.getId()) {
				appointment.setStatus(2);
				appointmentJpaRepository.save(appointment);
				return "Y";
			}else{
				throw  new IllegalStateException("N");
//				return "N";
			}
		case 2 :
			if(appointment.getSellerId()==user.getId()) {
				appointment.setStatus(3);
				appointmentJpaRepository.save(appointment);
				return "Y";
			}else{
				throw  new IllegalStateException("N");
			}
		case 3 :
			if(appointment.getBuyerId()==user.getId()) {
				appointment.setStatus(4);
				appointmentJpaRepository.save(appointment);
				return "Y";
			}else{
				throw  new IllegalStateException("N");
			}
		case 4 :
			if(appointment.getBuyerId()==user.getId()) {
				appointment.setStatus(5);
				appointmentJpaRepository.save(appointment);
				return "Y";
			}else{
				throw  new IllegalStateException("N");
			}
			
		case 6 :
			if(appointment.getSellerId()==user.getId()) {
				appointment.setStatus(7);
				appointmentJpaRepository.save(appointment);
				return "Y";
			}else{
				throw  new IllegalStateException("N");
			}
			
		case 7 :
			if(appointment.getSellerId()==user.getId()) {
				appointment.setStatus(8);
				appointmentJpaRepository.save(appointment);
				return "Y";
			}else{
				throw  new IllegalStateException("N");
			}
		
		}
		
		return null;
	}
	
	

}
