package rfidlocker.entity;

import java.time.LocalDateTime;

import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;

public class Appointment {
	
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)	
	Integer id;
	Integer boxId;
	Integer buyerId;
	Integer sellerId;
	String status;
	LocalDateTime buyerStartTime;
	LocalDateTime buyerEndTime;
	LocalDateTime sellerStartTime;
	LocalDateTime sellerEndTime;
	

}
