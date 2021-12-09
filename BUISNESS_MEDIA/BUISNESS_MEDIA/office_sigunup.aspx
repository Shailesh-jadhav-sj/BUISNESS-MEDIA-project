<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="office_sigunup.aspx.cs" Inherits="BUISNESS_MEDIA.office_sigunup" %>

<!DOCTYPE html>
<html lang="en">
<head>
<script type="text/javascript">

    function check() {
        var name = document.getElementById("name").value;
        var bio = document.getElementById("bio").value;
        var username = document.getElementById("username").value;
        
        if (name == "") {
            alert("name is required");
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
    }
    </script>   
    <title>Office Registration</title>
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
                        <h2 class="form-title">Office Signup</h2>
                        <form id="form2" runat="server" class="register-form">
                        
                            <div class="form-group">
                                <label for="name"><i class="zmdi zmdi-account material-icons-name"></i></label>
                                <asp:TextBox ID="name" runat="server" class="input" placeholder="Your office name"></asp:TextBox>
                            </div>
                           
                              <div class="form-group"> 
                              <asp:FileUpload ID="imgUpload" runat="server" onchange="ShowPreview(this)" />
                                <asp:Label ID="lblResult" runat="server" ForeColor="#0066FF"></asp:Label>
                               
                              </div>

                            <div class="form-group">
                                <asp:TextBox ID="bio" runat="server" class="input" placeholder="Your bio"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <asp:TextBox ID="username" runat="server" class="input" ReadOnly="true" placeholder="Your username(should be unique)"></asp:TextBox>
                            </div>
                            
                                                        <div class="form-group form-button">
                                <asp:Button ID="Register" runat="server"  class="form-submit" Text="Register" 
                                                                OnClientClick="return check()" onclick="Register_Click" />
                            </div>
                        </form>
                    </div>
                    <div class="signup-image">
                        
                        <a href="office.aspx" class="signup-image-link">I already have office</a>
                        <img src="./signup-image.jpg" alt="sing up image"/>
                       
                                            </div>
                    
                    
                </div>
              </div>
            </div>
        </div>

        
                 
                   
   

    
 <i class="wave"></i>
</body >
</html>



