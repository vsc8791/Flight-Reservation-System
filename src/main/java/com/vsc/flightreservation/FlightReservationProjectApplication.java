package com.vsc.flightreservation;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.ComponentScan;

@SpringBootApplication
@ComponentScan({"com.vsc.flightreservation.controllers"})
public class FlightReservationProjectApplication {

	public static void main(String[] args) {
		SpringApplication.run(FlightReservationProjectApplication.class, args);
	}
}
