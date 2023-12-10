package rfidlocker.entity;

import java.time.LocalDateTime;

import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import lombok.Data;

@Entity
@Data
public class Users {

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)	
	Integer id;
	String name;
	String email;
	String password;
	String rfidToken;
	LocalDateTime createdAt;
	LocalDateTime updateAt;
		
}
