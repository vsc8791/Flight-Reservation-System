package com.vsc.flightreservation.repos;

import org.springframework.data.jpa.repository.JpaRepository;

import com.vsc.flightreservation.pojos.User;

public interface UserRepository extends JpaRepository<User, Long> {

	User findByEmail(String email);

}
