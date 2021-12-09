<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addcubic.aspx.cs" Inherits="BUISNESS_MEDIA.addcubic" %>

<html>
<head id="Head1" runat="server">
    <title>Cubic</title>
    <link href="StyleSheet1.css" rel="stylesheet" type="text/css" />
            <script type="text/javascript">
                $(document).ready(function () {
                    $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
                });
        </script>
</head>
<body class="home">
    <form id="form1" runat="server">
 <div class="header">
 <center>
  <a class="logo">Business Media-OFFICE</a>
  </center>
  </div>
  
    <div class="container-fluid display-table">
    <header>
        <div class="row display-table-row">
            <div class="col-md-1 col-sm-1 hidden-xs display-table1-cell v-align box" id="navigation">
               <!--image-->
               <div class="navi">
                    <ul>
                        <li><a href="office.aspx"><i class="fa fa-cog" aria-hidden="true"></i><span class="hidden-xs hidden-sm"> <- BACK TO OFFICE</span></a></li>
                 </ul>
                </div>
                <div class="logo" >
                    
                        <img src="11.jpg" alt="Business_media_logo" class="hidden-xs hidden-sm" />
                   
                </div>
                <!--navbar-->
                <div class="navi">
                    <ul>
                        <li><a href="cubic.aspx"><i class="fa fa-home" aria-hidden="true"></i><span class="hidden-xs hidden-sm">office-Home</span></a></li>
                        <li class="active" ><a href="addcubic.aspx"><i class="fa fa-tasks" aria-hidden="true"></i><span class="hidden-xs hidden-sm">ADD CUBICS</span></a></li>
                        <li><a href="assign.aspx"><i class="fa fa-user" aria-hidden="true"></i><span class="hidden-xs hidden-sm">Assign Work</span></a></li>
                        <li><a href="#"><i class="fa fa-calendar" aria-hidden="true"></i><span class="hidden-xs hidden-sm">Users</span></a></li>
                    </ul>
                </div>
                <!--navbar-->
            </div>
             
                <div class="row">
                  
                      <div style="width: 100%;">
                        
                           <div style="width: 95%; height: 100px; float: left; ">
                           <h1>Genral Search</h1>
                           <asp:TextBox ID="contact" runat="server" placeholder="enter id to follow" 
                                 AutoPostBack="true"  AutoComplete="off" ></asp:TextBox>
                           
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
                        <br/>               
                 <br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/>
            <div class="row">
                  
                      <div style="width: 100%;">
                        
                           <div style="width: 95%; height: 100px; float: left; ">
                           <h1>cubic members</h1>
                           <asp:TextBox ID="TextBox1" runat="server" placeholder="enter id to follow" 
                                 AutoPostBack="true"  AutoComplete="off" ></asp:TextBox>
                           
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
                             </div>
                             
                        <br />

                           

                        </div>

                            <br/>
                            <br/>   
                                       
                  </div>
                  </div>
            

    </header> 

    </form>



   

</body>
</html>

