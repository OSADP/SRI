<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
    pageEncoding="ISO-8859-1"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ taglib prefix="fn" uri="http://java.sun.com/jsp/jstl/functions" %>
    
<!DOCTYPE html>
<html lang="en">
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
		<meta http-equiv="X-UA-Compatible" content="IE=Edge">
		<meta name="viewport" content="width=device-width, initial-scale=1.0">
	
	    <c:set var="url">${pageContext.request.requestURL}</c:set>
	    <base href="${fn:substring(url, 0, fn:length(url) - fn:length(pageContext.request.requestURI))}${pageContext.request.contextPath}/" />
			
		<title>SRI Admin - Login</title>

		<link rel="stylesheet" href="styles/login.css">
		
		<link rel="icon" type="image/png" href="images/favicon.png" />
		
		<!-- LOAD ANGULAR EARLY, NOT ADVISED BUT THIS AVOIDS EXPOSURE OF EXPRESSIONS -->
		<script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.2.27/angular.js" type="text/javascript"></script>
		<script type="text/javascript">
		//<![CDATA[
		(window.angular)||document.write('<script type="text/javascript" src="/DashCon/vendor/angular/angular.js"><\/script>');//]]>
		</script>
		<!-- // -->
	</head>
	<body style="background: #2c3e50" ng-app>
	
		<div id="stage" class="container">
			
			<div class="row">
				<img src="images/sri-logo.png" class="col-xs-4 col-xs-offset-4 col-md-2 col-md-offset-5" style="margin-top: 45px;">
			</div>
			
			<div class="row">
				<div id="loginBlock" class="col-md-4 col-md-offset-4" style="margin-top: 25px;">
					<div id="" class="panel panel-default">
						<div class="panel-heading">
							SRI Moble App
						</div>
						<div class="panel-body">
								<div class="form-group">
									The SRI Mobile App will be available at the following link:
									
								</div>
								<div class="form-group">
								Available 7/17/2015 <br/>
								<a href='https://play.google.com/store/apps/details?id=srimobile.aspen.leidos.com.sri'>SRI Mobile</a>
								</div>
								
						</div>
					</div>
				</div>
			</div>
			
		</div>
		
		<!-- FOOTER -->
		<div ng-include="'includes/login-footer.html'"></div>
		<!-- // -->
	
		<!-- JS DEPENDENCIES -->
		<script src="js/jquery-1.11.0.js"></script>
		<script src="vendor/angular-ui-router/angular-ui-router.js"></script>
		<script src="vendor/bootstrap/custom/js/bootstrap.js"></script>
		<!-- // -->
	</body>
</html>