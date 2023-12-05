package rfidlocker.repository;

import java.util.List;
import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;

import rfidlocker.entity.Boxes;

public interface BoxesJpaRepository extends JpaRepository<Boxes,Integer>{
	
	List<Boxes> findAll();
	Optional<Boxes> findByName(String name);

}
