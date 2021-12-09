<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="BUISNESS_MEDIA.WebForm1" %>
<!DOCTYPE html>
<html lang="en">
<head>
<script type="text/javascript">
     
    function check() {
        var name = document.getElementById("name").value;
        var contact = document.getElementById("contact").value;
        var emailReg = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        var digitReg = /^\d{10}$/;
        var genders = document.getElementsByName("gender");
        var email = document.getElementById("email").value;
        var occupation = document.getElementById("occupation").value;
        var category = document.getElementById("category").value;
        var skills = document.getElementById("skills").value;
        var adress = document.getElementById("adress").value;
        var bio = document.getElementById("bio").value;
        var username = document.getElementById("username").value;
        var password = document.getElementById("password").value;
        var repeatpassword = document.getElementById("repeatpassword").value;
        
        if (name == "") 
        {
            alert("name is required");
            return false;
        }
        if (contact == "") {

            alert("You didn't enter a phone number.");
            fld.value = "";
            fld.focus();
            return false;
        }
        else if (isNaN(contact)) {
            alert("The phone number contains illegal characters.");
            fld.value = "";
            fld.focus();
            return false;
        }
        else if (!(contact.length == 10)) {
            alert("The phone number is the wrong length. \nPlease enter 10 digit mobile no.");
            fld.value = "";
            fld.focus();
            return false;
        }

        var idate = document.getElementById("date").value;
        var today = new Date();
        var dd = today.getDate();

        var mm = today.getMonth() + 1;
        var yyyy = today.getFullYear();
        
        
        if (dd < 10) {
            dd = '0' + dd;
        }

        if (mm < 10) {
            mm = '0' + mm;
        }
        today = yyyy + '-' + mm + '-' + dd

        if (today < idate) {
            alert("dob should be less then current date");
        }

        

        if (genders[0].checked == false && genders[1].checked == false) {
            alert("select your gender");
            return false;
        }

        if (!(email.match(emailReg)))
        {
            alert("enter valid email");
        }
        if (occupation == "") {
            alert("occupation is required");
            return false;
        }
        if (category == "") {
            alert("category is required");
            return false;
        }
        if (skills == "") {
            alert("skills is required");
            return false;
        }
        if (adress == "") {
            alert("adress is required");
            return false;
        }
        if (bio == "") {
            alert("bio is required");
            return false;
        }
        if (username == "") {
            alert("username is required");
            return false;
        }
        if (password == "") {
            alert("password is required");
            return false;
        }
        if (repeatpassword == "") {
            alert("repeatpassword is required");
            return false;
        }
        if (password != repeatpassword) {

            alert("repeatpassword and password not matched");
            return false;

        }
       
        


       
        
        

        
      
        
    }
    </script>   
    <title>Buisness Media Registration</title>
    <link rel="stylesheet" href="./Registration.css"/>
</head>
<body>
 <div class="header"><center>
  <a href="#default" class="logo">Business Media</a>
  </center>
  <div class="header-right">
    
  </div>
</div> 
    <div class="main">

        <!-- Sign up form -->
        <div class="signup">
            <div class="container">
                <div class="signup-content">
                    <div class="signup-form">
                        <h2 class="form-title">Sign up</h2>
                        <form id="form2" runat="server" class="register-form">
                        
                            <div class="form-group">
                                <label for="name"><i class="zmdi zmdi-account material-icons-name"></i></label>
                                <asp:TextBox ID="name" runat="server" class="input" placeholder="Your full name"></asp:TextBox>
                            </div>
                           
                            <div class="form-group">
                                <asp:TextBox ID="contact" runat="server" class="input" placeholder="Your contact number"></asp:TextBox>
                            </div>
                            <div class="form-group">
                            
                            <asp:TextBox ID="date" runat="server" Text='<%# Bind("DateofBirth") %>' TextMode="Date"  ></asp:TextBox>
                            </div>
                            <div class="form-group">  
                                <asp:RadioButton ID="male" runat="server" Text="Male" GroupName="gender" />  
                             </div>
                             <div class="form-group">  
                               <asp:RadioButton ID="female" runat="server" Text="Female" GroupName="gender" />  
                              </div> 
                              <div class="form-group"> 
                              <asp:FileUpload ID="imgUpload" runat="server" onchange="ShowPreview(this)" />
                                <asp:Label ID="lblResult" runat="server" ForeColor="#0066FF"></asp:Label>
                                <asp:Image ID="impPrev" style="width:200px" Runat="server" />
</div>

                            <div class="form-group">
                                <asp:TextBox ID="email" runat="server" class="input" placeholder="Your email"></asp:TextBox>
                            </div>
                             <br />
                             <asp:Button ID="BtnSendOTP" runat="server" Text="Send OTP" OnClick="BtnSendOTP_Click"
                CssClass="BtnCss" /><asp:Label ID="LblMsg" runat="server" Text="Label"></asp:Label>
            OTP
            <asp:TextBox ID="TbOTP" runat="server"></asp:TextBox>
            &nbsp;
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TbOTP"
                ErrorMessage="OTP Must Be Of 6 Digit" ValidationExpression="\d{6}"></asp:RegularExpressionValidator>
            <br />
                            <div class="form-group">
                                <asp:TextBox ID="occupation" runat="server" class="input" placeholder="Your occupation"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="category" runat="server" class="input" placeholder="account category"></asp:TextBox>
                            </div>
                             <div class="form-group">
                                <asp:TextBox ID="skills" runat="server" class="input" placeholder="Your skills"></asp:TextBox>
                            </div>
                             <div class="form-group">
                                <asp:TextBox ID="adress" runat="server" class="input" placeholder="Your adresss"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <asp:TextBox ID="bio" runat="server" class="input" placeholder="Your bio"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <asp:TextBox ID="username" runat="server" class="input" placeholder="Your username(should be unique)"></asp:TextBox>
                            </div>
                            
                            <div class="form-group">
                                <asp:TextBox ID="password" runat="server" class="input" type="password" placeholder="Password"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="repeatpassword" runat="server" class="input" type="password" placeholder="Repeat your password"></asp:TextBox>
                            </div>
                            <div class="form-group form-button">
                                <asp:Button ID="Register" runat="server"  class="form-submit" Text="Register" OnClientClick="return check()" OnClick="input_Click"/>
                            </div>
                        </form>
                    </div>
                    <div class="signup-image">
                        
                        <a href="userlogin.aspx" class="signup-image-link">I am already member</a>
                        <img src="./signup-image.jpg" alt="sing up image"/>
                        <img src="./signin-image.jpg" alt="sing up image"/>
                        
                                            </div>
                    
                    
                </div>
              </div>
            </div>
        </div>

        
                 
                   
   

    
 <i class="wave"></i>
</body >
</html>


