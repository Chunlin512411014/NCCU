package rfidlocker.entity;

import java.time.LocalDateTime;

import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import lombok.Data;
@Entity
@Data
/*
 * 訂單Model 
 * 對應db欄位
 * 
 * */
public class Appointment {
	
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)	
	Integer id;
	Integer boxId;
	Integer buyerId;
	Integer sellerId;
	/*
	 * status code 1:未到貨 2:已送達 3:已取貨 4:完成 or return; 99 cancel
	 * 
	 * */
	Integer status;
	LocalDateTime buyerStartTime;
	LocalDateTime buyerEndTime;
	LocalDateTime sellerStartTime;
	LocalDateTime sellerEndTime;
	LocalDateTime expiryTime;
	
	

}
