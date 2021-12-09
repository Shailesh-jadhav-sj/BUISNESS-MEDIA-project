<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userlogin.aspx.cs" Inherits="BUISNESS_MEDIA.WebForm2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Buisness Media Login</title>
	<link rel="stylesheet" type="text/css" href="./style.css"/>
  
	
</head>
<body>
  <div class="header"><center>
  <a class="logo">Business Media</a>
  </center>
  <div class="header-right">
    
  </div>
</div> 
    <img class="wave" src=".\wave.png" alt="wave">
	<div class="container">
		<div class="img">
			<img src="./11.jpg"/>
		</div>
        <div class="login-content">
	
    <form id="form1" runat="server">
    <img src= "./profile pic.bmp" />
				<h2 class="title">Welcome</h2>
           		<div class="input-div one">
           		   <div class="i">
           		   		<i class="fas fa-user"></i>
           		   </div>
           		   <div class="div">
           		   		<h5>Username</h5>
                        
           		        <asp:TextBox ID="username1" runat="server"  />
           		   </div>
           		</div>
           		<div class="input-div pass">
           		   <div class="i"> 
           		    	<i class="fas fa-lock"></i>
           		   </div>
           		   <div class="div">
           		    	<h5>Password</h5>
                        <asp:TextBox ID="password2" type="password"  runat="server" class="input"  />
           		    	
            	   </div>
            	</div>
                <a href="Registration.aspx">Create an account?</a>
            	<a href="#">Forgot Password?</a>
    <div>
    
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" class="btn" Text="login" />
    
    </div>
    </form>
    </div>
    <script type="text/javascript" src="./main.js"></script>
</body>
</html>
