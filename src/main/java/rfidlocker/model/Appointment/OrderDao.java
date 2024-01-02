package rfidlocker.model.Appointment;

import java.time.LocalDateTime;

import jakarta.persistence.Entity;
import lombok.Data;
import rfidlocker.entity.Appointment;

/*
 * 自行封裝model 
 * 用於顯示
 * */

@Data
public class OrderDao {
	Integer appointmentId;
	Integer boxId;
	String boxName;
	String location;
	//賣家
	String supplierEmail;
	//買家
	String recipientEmail;
	String status;
}
