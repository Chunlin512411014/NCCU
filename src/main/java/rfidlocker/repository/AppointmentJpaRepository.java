package rfidlocker.repository;

import java.util.List;
import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;

import rfidlocker.entity.Appointment;
/*
 * Spring boot JAP 介面
 * DB table : Appointment
 * */
public interface AppointmentJpaRepository extends JpaRepository<Appointment,Integer>{
	
	List<Appointment> findAllBySellerId(Integer userId);
	List<Appointment> findAllByBuyerId(Integer userId);
	Optional<Appointment> findByBoxIdAndStatusIn(Integer boxId , List<Integer> statusList );
	Optional<Appointment> findById(Integer appointmentId);
	Optional<Appointment> findByBoxIdAndStatus(Integer boxId ,Integer status );
	Optional<Appointment> findByBoxId(Integer boxId  );
}
