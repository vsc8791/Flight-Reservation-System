package com.vsc.flightreservation.pojos;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.validation.constraints.NotNull;

@Entity
@Table(name="USER")
public class User extends AbstractEntity{
	
	@NotNull
	@Column(name="First_Name")
	private String firstName;
	
	@NotNull
	@Column(name="Last_Name")
	private String lastName;
	
	@NotNull
	@Column(name="Email",unique=true)
	private String email;
	
	@NotNull
	@Column(name="Password")
	private String password;
	
	public User() {}
	
	public String getFirstName() {
		return firstName;
	}
	public void setFirstName(String firstName) {
		this.firstName = firstName;
	}
	public String getLastName() {
		return lastName;
	}
	public void setLastName(String lastName) {
		this.lastName = lastName;
	}
	public String getEmail() {
		return email;
	}
	public void setEmail(String email) {
		this.email = email;
	}
	public String getPassword() {
		return password;
	}
	public void setPassword(String password) {
		this.password = password;
	}
	
	

}
