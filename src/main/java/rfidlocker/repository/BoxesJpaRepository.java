package rfidlocker.repository;

import org.springframework.data.jpa.repository.JpaRepository;

import rfidlocker.entity.Boxes;

public interface BoxesJpaRepository extends JpaRepository<Boxes,Integer>{

}
