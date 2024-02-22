package com.vsc.flightreservation.pojos;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.OneToOne;
import javax.persistence.Table;

@Entity
@Table(name="Reservation")
public class Reservation extends AbstractEntity {

	
	@Column(name="CheckedIn")
	private boolean checkedIn;
	
	@Column(name="NumberOfBags")
	private int numberOfBags;
	

	@OneToOne
	private Flight flight;
	
	
	@OneToOne
	private Passenger passenger;
	
	
	public Reservation() {
	}


	public boolean isCheckedIn() {
		return checkedIn;
	}


	public void setCheckedIn(boolean checkedIn) {
		this.checkedIn = checkedIn;
	}


	public int getNumberOfBags() {
		return numberOfBags;
	}


	public void setNumberOfBags(int numberOfBags) {
		this.numberOfBags = numberOfBags;
	}


	public Flight getFlight() {
		return flight;
	}


	public void setFlight(Flight flight) {
		this.flight = flight;
	}


	public Passenger getPassenger() {
		return passenger;
	}


	public void setPassenger(Passenger passenger) {
		this.passenger = passenger;
	}


	@Override
	public String toString() {
		return "Reservation [checkedIn=" + checkedIn + ", numberOfBags=" + numberOfBags + ", flight=" + flight
				+ ", passenger=" + passenger + "]";
	}

}
