package rfidlocker.repository;

import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;

import rfidlocker.entity.Users;
/*
 * Spring boot JAP 介面
 * DB table : Users
 * */
public interface UsersJpaRepository extends JpaRepository<Users,Integer> {
	
	Optional<Users> findByEmailAndPassword(String email ,String password);
	Optional<Users> findByEmail(String email);
	Optional<Users> findByRfidToken(String rfidToken);

}
