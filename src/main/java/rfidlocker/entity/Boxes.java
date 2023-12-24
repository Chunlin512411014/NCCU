package rfidlocker.entity;

import java.time.LocalDateTime;

import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import lombok.Data;

@Entity
@Data
public class Boxes {
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)	
	Integer id;
	Integer boxNo;
	String name;
	String location;
	String status;
	LocalDateTime useTime;
	LocalDateTime createdTime;
	String longitude;
	String latitude;
	Boolean isLock;
	//預約時間
	LocalDateTime reservationTime;
	//到期時間
	LocalDateTime expiryTime;
} 
