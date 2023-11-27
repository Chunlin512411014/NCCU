package rfidlocker.repository;

import org.springframework.data.jpa.repository.JpaRepository;

import rfidlocker.entity.Appointment;

public interface AppointmentJpaRepository extends JpaRepository<Appointment,Integer>{

}
