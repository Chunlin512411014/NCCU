package rfidlocker.model.Appointment;

import java.time.LocalDateTime;

import lombok.Data;
@Data
public class AppointmentDao {
	//所預約的箱子id
	Integer boxId;
	String buyerEmail;
	//賣方id
	Integer sellerId;
	//買方email
	String receiverEmail;
//	String status;
	LocalDateTime buyerStartTime;
	LocalDateTime buyerEndTime;
	LocalDateTime sellerStartTime;
	LocalDateTime sellerEndTime;
	//預約時間
	LocalDateTime reservationTime;
	//到期時間
	LocalDateTime expiryTime;
}
