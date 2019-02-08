<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
    pageEncoding="ISO-8859-1"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="ISO-8859-1">
<title>Login Page</title>
</head>
<body>

<form action="login" method="post">
<h1>User Login</h1>
<pre>
User name : <input type="text" name="email" />
Password : <input type="password" name="password" />
<input type="submit" value="login"/>

</pre>
<h3> ${msg} </h3>
</form>
</body>
</html>