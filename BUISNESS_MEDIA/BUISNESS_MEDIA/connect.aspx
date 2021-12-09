<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="connect.aspx.cs" Inherits="BUISNESS_MEDIA.connect" %>

<html>
<head id="Head1" runat="server">
    <title>userprofile</title>
    <link href="StyleSheet1.css" rel="stylesheet" type="text/css" />
    <link href="datatable/jquery.dataTables.min.css" rel="stylesheet" type="text/css" />
  
 

    
       
</head>

<body class="home">
    <form id="form1" runat="server">
 <div class="header">
 <center>
  <a class="logo">Business Media</a>
  </center>
  </div>
  
    <div class="container-fluid display-table " style="background-color:White;">
        <div class="row display-table-row">
            <div class="col-md-1 col-sm-1 hidden-xs display-table1-cell v-align box" id="navigation">
               <!--image-->
                <div class="logo" >
                    
                        <img src="11.jpg" alt="Business_media_logo" class="hidden-xs hidden-sm" />
                   
                </div>
                <!--navbar-->
                <div class="navi">
                    <ul>
                        <li><a href="userprofile.aspx"><i class="fa fa-home" aria-hidden="true"></i><span class="hidden-xs hidden-sm">Home</span></a></li>
                        <li><a href="office.aspx"><i class="fa fa-tasks" aria-hidden="true"></i><span class="hidden-xs hidden-sm">Office</span></a></li>
                        <li class="active"><a href="connect.aspx"><i class="fa fa-user" aria-hidden="true"></i><span class="hidden-xs hidden-sm">Connect</span></a></li>
                        <li ><a href="Room.aspx"><i class="fa fa-calendar" aria-hidden="true"></i><span class="hidden-xs hidden-sm">Room</span></a></li>
                        <li><a href="userlogin.aspx"><i class="fa fa-cog" aria-hidden="true"></i><span class="hidden-xs hidden-sm">Logout</span></a></li>
                    </ul>
                </div>
                <!--navbar-->
            </div>
            <div class="col-md-10 col-sm-11 display-table-cell v-align">
                <!--<button type="button" class="slide-toggle">Slide Toggle</button> -->
                <div class="row">
                    <header>
                      <div style="width: 100%;">
                        
                           <div style="width: 95%; height: 100px; float: left; ">
                           <h1>Genral Search</h1>
                           <asp:TextBox ID="contact" runat="server" placeholder="enter id to follow" 
                                 AutoPostBack="true"   OnTextChanged="contact_TextChanged" AutoComplete="off" ></asp:TextBox>
                           <div class="form-group form-button">
                            </div>
                            <div style="overflow:scroll; height: 188px; width: 779px;">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns=False 
                                    onrowcommand="GridView1_RowCommand" Width="774px"  class="table table-striped table-bordered" 
                                     >
                            <Columns>
                            
                           <asp:TemplateField HeaderText="profile pic">
                                <ItemTemplate>
                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem,"profile_pic") %>' Height="50px" Width="50px"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:BoundField DataField ="user_name" HeaderText="user_name" />
                           


                                <asp:ButtonField DataTextField="button_name" HeaderText="request" ButtonType="Button" CommandName="request" />
                           


                        </Columns>
                           </asp:GridView>
                           </div>
                             </div>
                             
                        <br />

                           

                        </div>

                            <br/>
                            <br/>                
                  </div>
                  </div>
                   <div class="col-md-10 col-sm-11 display-table-cell v-align">
                <!--<button type="button" class="slide-toggle">Slide Toggle</button> -->
                <div class="row">
                    <header>
                      <div style="width: 100%; height: 2307px;">
                        <br/>
                            
                           <div style="width: 47%; height: 100px; float: left; ">
                            <br/>
                            <br/>
                            <br/>
                            <br/>
                            <br/>
                            

                            <%-- dksd --%>
                            <h1>Followers</h1>
                            <asp:TextBox ID="TextBox1" runat="server" placeholder="enter id to follow" 
                                 AutoPostBack="true"   OnTextChanged="TextBox1_TextChanged" AutoComplete="off" ></asp:TextBox>
                           <div class="form-group form-button">
                            </div>
                            <div style="overflow:scroll; height: 188px; width: 779px;">
                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns=False 
                                    onrowcommand="GridView2_RowCommand" Width="774px"  class="table table-striped table-bordered" 
                                     >
                            <Columns>
                            
                           <asp:TemplateField HeaderText="profile pic">
                                <ItemTemplate>
                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem,"profile_pic") %>' Height="50px" Width="50px"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:BoundField DataField ="user_name" HeaderText="user_name" />
                           


                                <asp:ButtonField DataTextField="button_name" HeaderText="request" ButtonType="Button" CommandName="request" />
                           


                        </Columns>
                           </asp:GridView>
                           </div>
                        <%-- dksd --%>
                        <%-- dksd2 --%>
                         <div class="row">
                   
                      <div style="width: 100%;">
                        <br />
                     
                            <h1>Following</h1>
                            <asp:TextBox ID="TextBox2" runat="server" placeholder="enter id to follow" 
                                 AutoPostBack="true"   OnTextChanged="TextBox2_TextChanged" AutoComplete="off" ></asp:TextBox>
                           <div class="form-group form-button">
                            </div>
                            <div style="overflow:scroll; height: 188px; width: 779px;">
                            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns=False 
                                    onrowcommand="GridView3_RowCommand" Width="774px"  class="table table-striped table-bordered" 
                                     >
                            <Columns>
                            
                           <asp:TemplateField HeaderText="profile pic">
                                <ItemTemplate>
                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem,"profile_pic") %>' Height="50px" Width="50px"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:BoundField DataField ="user_name" HeaderText="user_name" />
                           


                                <asp:ButtonField DataTextField="button_name" HeaderText="request" ButtonType="Button" CommandName="request" />
                           


                        </Columns>
                           </asp:GridView>

                        <%-- dksd2 --%>
                           </div>
                             
                             
                        <%-- dksd3 --%>
                        
                   
                      <div style="width: 100%;">
                        <br />
                     
                            <h1>Request</h1>
                            <asp:TextBox ID="TextBox3" runat="server" placeholder="enter id to follow" 
                                 AutoPostBack="true"   OnTextChanged="TextBox3_TextChanged" AutoComplete="off" ></asp:TextBox>
                           <div class="form-group form-button">
                            </div>
                            <div style="overflow:scroll; height: 188px; width: 779px;">
                            <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns=False 
                                    onrowcommand="GridView4_RowCommand" Width="774px"  class="table table-striped table-bordered" 
                                     >
                            <Columns>
                            
                           <asp:TemplateField HeaderText="profile pic">
                                <ItemTemplate>
                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem,"profile_pic") %>' Height="50px" Width="50px"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:BoundField DataField ="user_name" HeaderText="user_name" />
                           


                                <asp:ButtonField Text="accept" HeaderText="request" ButtonType="Button" CommandName="accept" />
                           

                                <asp:ButtonField Text="decline" HeaderText="request" ButtonType="Button" CommandName="decline" />
                           
                        </Columns>
                           </asp:GridView>

                        <%-- dksd3 --%>
                             
                             
                             
                        </div>

                                            
                  </div>
               </div>
  </div>
    </div>

   

    </form>



   

</body>
</html>
