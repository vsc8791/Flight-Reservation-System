package com.vsc.flightreservation.repos;

import org.springframework.data.jpa.repository.JpaRepository;

import com.vsc.flightreservation.pojos.Passenger;

public interface PassengerRepository extends JpaRepository<Passenger, Long> {

}
