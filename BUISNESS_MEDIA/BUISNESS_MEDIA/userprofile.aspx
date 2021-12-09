<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userprofile.aspx.cs" Inherits="BUISNESS_MEDIA.userprofile" %>
<html>
<head id="Head1" runat="server">
    <title>userprofile</title>
    <link href="StyleSheet1.css" rel="stylesheet" type="text/css" />
</head>

<body class="home">
    <form id="form1" runat="server">
 <div class="header">
 <center>
  <a class="logo">Business Media</a>
  </center>
  </div>
  
    <div class="container-fluid display-table">
        <div class="row display-table-row">
            <div class="col-md-1 col-sm-1 hidden-xs display-table1-cell v-align box" id="navigation">
               <!--image-->
                <div class="logo" >
                    
                        <img src="11.jpg" alt="Business_media_logo" class="hidden-xs hidden-sm" />
                   
                </div>
                <!--navbar-->
                <div class="navi">
                    <ul>
                        <li class="active"><a href="userprofile.aspx"><i class="fa fa-home" aria-hidden="true"></i><span class="hidden-xs hidden-sm">Home</span></a></li>
                        <li><a href="office.aspx"><i class="fa fa-tasks" aria-hidden="true"></i><span class="hidden-xs hidden-sm">office</span></a></li>
                        <li><a href="#"><i class="fa fa-bar-chart" aria-hidden="true"></i><span class="hidden-xs hidden-sm">Statistics</span></a></li>
                        <li><a href="connect.aspx"><i class="fa fa-user" aria-hidden="true"></i><span class="hidden-xs hidden-sm">Connect</span></a></li>
                        <li><a href="Room.aspx"><i class="fa fa-calendar" aria-hidden="true"></i><span class="hidden-xs hidden-sm">Room</span></a></li>
                        <li><a href="userlogin.aspx"><i class="fa fa-cog" aria-hidden="true"></i><span class="hidden-xs hidden-sm">Logout</span></a></li>
                    </ul>
                </div>
                <!--navbar-->
            </div>
            <div class="col-md-10 col-sm-11 display-table-cell v-align">
                <!--<button type="button" class="slide-toggle">Slide Toggle</button> -->
                <div class="row">
                    <header>
                        <div class="col-md-7">
                        
                            <div class="search hidden-xs hidden-sm">
                                <input type="text" placeholder="Search" id="search">
                            </div>
                        </div>

                        <div class="row">
                          
                            <div style="width: 100%;">
                                <div style="width: 25%; height: 100px; float: left; "> 
                                     <asp:Image ID="profilepic" runat="server" hieght="250px" Width="200px" />
                                </div>

                                <div style="float:left; width: 35%; height: 100px;"> 
                                    
                                    
                                    Name&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp: <asp:TextBox runat="server" ID="TextBox1" ReadOnly="true"></asp:TextBox>
                                    
                                    <br/>
                                    Category : <asp:TextBox runat="server" ID="TextBox2" ReadOnly="true"></asp:TextBox>
                                    
                                    <br/>
                                    Email id &nbsp: <asp:TextBox runat="server" ID="TextBox3" ReadOnly="true"></asp:TextBox>
                                    
                                    <br/>
                                    Contact  &nbsp&nbsp: <asp:TextBox runat="server" ID="TextBox4" ReadOnly="true"></asp:TextBox>
                                    <br/>
                                     Address  &nbsp&nbsp: <asp:TextBox runat="server" ID="TextBox10" ReadOnly="true"></asp:TextBox>
                                    <br/>
                                    <br/>
                                    BIO &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp: <asp:TextBox runat="server" ID="TextBox12" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>
                                    <br/>
                                    
                                </div>

                                <div style="float:left; width: 35%; height: 100px; "> 
                                    Privacy type&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp: <asp:TextBox runat="server" ID="TextBox5" ReadOnly="true"></asp:TextBox>
                                    
                                    <br/>
                                    DOB &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp:<asp:TextBox runat="server" ID="TextBox6" ReadOnly="true" ></asp:TextBox>
                                    
                                    <br/>
                                    Gender &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp: <asp:TextBox runat="server" ID="TextBox7" ReadOnly="true"></asp:TextBox>
                                    
                                    <br/>
                                    Occupation&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp: <asp:TextBox runat="server" ID="TextBox8" ReadOnly="true"></asp:TextBox>
                                    <br/>
                                    Skill  &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp: <asp:TextBox runat="server" ID="TextBox9" ReadOnly="true"></asp:TextBox>
                                    <br/>
                                    TAG  &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp: <asp:TextBox runat="server" ID="TextBox13" ReadOnly="true"></asp:TextBox>
                                    <br/>
                                    Account creation date  &nbsp&nbsp: <asp:TextBox runat="server" ID="TextBox14" ReadOnly="true"></asp:TextBox>
                                    <br/>
                               </div>
                               <div style="float:right; width: 25%; height: 100px; "> 
                                   

                                </div>
                            </div>
                                                   
                        </div>
                        <asp:Button ID="update" runat="server" class="btn-group" Text="Update" OnClick="update_Click"/>
                       
                        <asp:Button ID="Button1" runat="server" class="btn-group" Text="delete" OnClick="delete_Click"/>
                        <br/>
                        <br />
                        <br />
                        <br />
                        <asp:Button ID="Button2" runat="server" class="btn-group" Text="change privacy" OnClick="pc" />
                        
                        
                        </header>
                                
                        </div>

                </div>

                <div class="user-dashboard" style="color:Green;">
                    <h1>Hello,<asp:Label runat="server" ID="namebox"  ForeColor="Blue"></asp:Label>&emsp;&emsp;Followers:<asp:Label runat="server" ID="Label1"  ForeColor="Blue"></asp:Label>&emsp;&emsp;Following:<asp:Label runat="server" ID="Label2"  ForeColor="Blue"></asp:Label>&emsp;&emsp;STAR COUNT : <asp:Label runat="server" ID="star3" ForeColor="Blue"></asp:Label>&emsp;&emsp;Requests : <asp:Label runat="server" ID="Label3" ForeColor="Blue"></asp:Label>
                                    <br/></h1>
                    <div class="row">
                        <div class="col-md-5 col-sm-5 col-xs-12 gutter">

                            <div class="sales">
                                <h2>Your Photo&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="Button3" runat="server" onclick="Button3_Click" 
                                        Text="upload_image" Width="119px" />
                                </h2>
                                <asp:DataList ID="DataList2" runat="server" RepeatColumns="2" BorderColor="#00CC00" BorderWidth="5px" 
                                        GridLines="Both" Width="1078px"  >
        <ItemTemplate>
                <table>
                    <tr>
                        <td style="padding-left:10px"><asp:Image ID="imgProduct" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Profilepic") %>' style="width:400px; height:400px;" /></td>
                        <td style="padding-left:20px"> 
                            <asp:Label ID="lblProduct" Text='<%# DataBinder.Eval(Container.DataItem, "officename") %>' runat="server" />
                            <br />
                            
                            <asp:Label ID="Label1" Text='<%# DataBinder.Eval(Container.DataItem, "id") %>' runat="server" />
                            <br />
                            
                        </td>
                       </tr>
                </table>
        </ItemTemplate>
</asp:DataList>

                                
                            </div>
                        </div>
                        <div class="col-md-7 col-sm-7 col-xs-12 gutter">

                            <div class="sales report">
                                <h2>Report</h2>
                                
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>



   

    </form>



   

</body>
</html>