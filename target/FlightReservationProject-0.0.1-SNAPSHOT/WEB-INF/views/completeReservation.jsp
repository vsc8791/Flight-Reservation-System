<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
	pageEncoding="ISO-8859-1"%>

<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="ISO-8859-1">
<title>Complete Reservation Page</title>
</head>
<body>

	<h1>Complete Reservation</h1>
	<br /> Airline : ${flight.operatingAirlines}
	<br /> Origin : ${flight.departureCity}
	<br /> Destination : ${flight.arrivalCity}
	<br /> Journey Date : ${flight.dateOfDeparture}
	<br /> Timings : ${flight.estimatedDepartureTime}
	<br />

	<form action="completeReservation" method="post">
	
	<h2>Passenger Details</h2>
	<pre>
	First Name : <input type="text" name="passengerfirstName">
	Middle Name : <input type="text" name="passengermiddleName">
	Last Name : <input type="text" name="passengerlastName">
	Email ID : <input type="email" name="passengerEmail">
	Phone Number : <input type="number" name="passengerPhoneNumber"/>
	</pre>
	<h2>Card Details</h2>
	<pre>
	Name on the Card : <input type="text" name="nameOnTheCard">
	Card Number : <input type="number" name="cardNumber">
	Expire Date : <input type="date" name="expirationDate">
	<!-- CVV Security : <input type="email" name="passengerEmail">-->
	Card PIN : <input type="number" name="securityDate">
	<input type="hidden" name="flightId" value="${flight.id}"/>
	<input type="submit" value="confirm" />
	</pre>
	
	
	
	</form>
</body>
</html>