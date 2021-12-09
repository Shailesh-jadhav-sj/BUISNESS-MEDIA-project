<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="upload_img.aspx.cs" Inherits="BUISNESS_MEDIA.upload_img" %>

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
                        <h2 class="form-title">Upload Image</h2>
                        <form id="form2" runat="server" class="register-form">
                        
                            <div class="form-group">
                                <label for="name"><i class="zmdi zmdi-account material-icons-name"></i></label>
                                <asp:TextBox ID="name" runat="server" class="input" placeholder="Your caption"></asp:TextBox>
                            </div>
                           
                              <div class="form-group"> 
                              <asp:FileUpload ID="imgUpload" runat="server" onchange="ShowPreview(this)" />
                                <asp:Label ID="lblResult" runat="server" ForeColor="#0066FF"></asp:Label>
                               
                              </div>

                           

                            <div class="form-group">
                                <asp:TextBox ID="username" runat="server" class="input" ReadOnly="true" placeholder="Your username(should be unique)"></asp:TextBox>
                            </div>
                            
                                                        <div class="form-group form-button">
                                <asp:Button ID="Register" runat="server"  class="form-submit" Text="upload" 
                                                                OnClientClick="return check()" onclick="Register_Click" />
                            </div>
                        </form>
                    </div>
                    <div class="signup-image">
                        
                        <img src="./signup-image.jpg" alt="sing up image"/>
                       
                                            </div>
                    
                    
                </div>
              </div>
            </div>
        </div>

        
                 
                   
   

    
 <i class="wave"></i>
</body >
</html>




