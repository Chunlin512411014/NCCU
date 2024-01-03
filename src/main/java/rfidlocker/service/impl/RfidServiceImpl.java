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

/*
 * RFID Service interface 實作
 * 撰寫商業邏輯
 * */
@Service
public class RfidServiceImpl implements RfidService {
	// 注入需要用的class
	@Autowired
	AppointmentJpaRepository appointmentJpaRepository;
	@Autowired
	UsersJpaRepository usersJpaRepository;
	/*
	 * 判斷此rfid 卡片是否有權限可以開啟箱子
	 */
	@Override
	public String checkCardNOAndBoxId(String cardNo, Integer boxId) {
        //透過 spring boot orm jpa 查詢user 
		Users user = usersJpaRepository.findByRfidToken(cardNo).orElseThrow(() -> new IllegalStateException("此辨識卡不存在"));
		/*
		 * status code 1 :未到貨 2 : 已到貨 
		 * 
		 */
		Integer[] statusArrsy = { 1, 2 };
		List<Integer> statusList = Arrays.asList(statusArrsy);
		
		//透過 spring boot orm jpa 查詢Appointment(order) 
		Appointment appointment = appointmentJpaRepository.findByBoxIdAndStatusIn(boxId, statusList)
				.orElseThrow(() -> new IllegalStateException("no appointment"));
		
		/*
		 * 訂單狀態為 1 : 未到貨 （賣方可以開啟locker)
		 * 訂單狀態為 2 : 已到貨  (買方可以開啟locker)
		 * */
		switch (appointment.getStatus()) {
		case 1:
			if (appointment.getSellerId() == user.getId()) {
				return "Y";
			} else {
				throw new IllegalStateException("N");
			}
		case 2:
			if (appointment.getBuyerId() == user.getId()) {
				return "Y";
			} else {
				throw new IllegalStateException("N");
			}
		}

		return null;
	}

}
