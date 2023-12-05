package rfidlocker.model.Appointment;

import java.time.LocalDateTime;

import lombok.Data;
@Data
public class AppointmentDao {

	Integer boxId;
	String buyerEmail;
	Integer sellerId;
//	String status;
	LocalDateTime buyerStartTime;
	LocalDateTime buyerEndTime;
	LocalDateTime sellerStartTime;
	LocalDateTime sellerEndTime;
}
