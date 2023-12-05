package rfidlocker.entity;

import java.time.LocalDateTime;

import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import lombok.Data;
@Entity
@Data
public class Appointment {
	
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)	
	Integer id;
	Integer boxId;
	Integer buyerId;
	Integer sellerId;
	/*
	 * status code 1:Booking ; 2:Booking open; 3:waiting ;4 buyer open; 5: complete or return; 99 cancel
	 * 
	 * */
	Integer status;
	LocalDateTime buyerStartTime;
	LocalDateTime buyerEndTime;
	LocalDateTime sellerStartTime;
	LocalDateTime sellerEndTime;
	

}
