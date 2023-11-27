package rfidlocker.repository;

import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;

import rfidlocker.entity.Users;

public interface UsersJpaRepository extends JpaRepository<Users,Integer> {
	
	Optional<Users> findByEmailAndPassword(String email ,String password);
	

}
