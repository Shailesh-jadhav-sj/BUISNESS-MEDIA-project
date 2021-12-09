<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Room.aspx.cs" Inherits="BUISNESS_MEDIA.Room" %>

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
                        <li ><a href="connect.aspx"><i class="fa fa-user" aria-hidden="true"></i><span class="hidden-xs hidden-sm">Connect</span></a></li>
                        <li class="active"><a href="Room.aspx"><i class="fa fa-calendar" aria-hidden="true"></i><span class="hidden-xs hidden-sm">Room</span></a></li>
                        <li><a href="userlogin.aspx"><i class="fa fa-cog" aria-hidden="true"></i><span class="hidden-xs hidden-sm">Logout</span></a></li>
                    </ul>
                </div>
                <!--navbar-->
            </div>
         
                <!--<button type="button" class="slide-toggle">Slide Toggle</button> -->
                    
                    <header>
                      <div style="width: 100%;">
                        <div class="sales">
                            
                           <h1>Room</h1>
                           <br/>
                           Room Name : 
                            <asp:TextBox ID="Room_name" runat="server" Width="235px"></asp:TextBox>
                            <br />
                            <br />
                           <br/>
                           <asp:Button ID="add_room" runat="server" Text="Add" onclick="add_room_Click" 
                                Width="77px" />

                            <br />
                            <br />
                            <br />

                           <asp:TextBox ID="contact" runat="server" placeholder="enter id to follow" 
                                 AutoPostBack="true" AutoComplete="off" ></asp:TextBox>
                           <div class="form-group form-button">
                            </div>
                            <div style="overflow:scroll; height: 188px; width: 779px;">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns=False 
                                   Width="774px"  class="table table-striped table-bordered" 
                                    AllowPaging="True" AllowSorting="True" DataKeyNames="room_id" 
                                    DataSourceID="SqlDataSource1" 
                                    onselectedindexchanged="GridView1_SelectedIndexChanged" 
                                    onrowcommand="GridView1_RowCommand" >
                                <Columns>
                                    <asp:BoundField DataField="room_id" HeaderText="room_id" InsertVisible="False" 
                                        ReadOnly="True" SortExpression="room_id" />
                                    <asp:BoundField DataField="room_name" HeaderText="room_name" 
                                        SortExpression="room_name" />
                                    <asp:BoundField DataField="user_name" HeaderText="user_name" 
                                        SortExpression="user_name" />
                                    <asp:BoundField DataField="room_creation_date" HeaderText="room_creation_date" 
                                        SortExpression="room_creation_date" />
                                    <asp:BoundField DataField="privacy_type" HeaderText="privacy_type" 
                                        SortExpression="privacy_type" />
                                    <asp:ButtonField Text="View" ButtonType="Button" CommandName="view" />
                                    <asp:ButtonField  Text="remove" ButtonType="Button" CommandName="remove"/>
                                </Columns>
                            
                           </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                                    SelectCommand="SELECT [room_id], [room_name], [user_name], [room_creation_date], [privacy_type] FROM [room_table]">
                                </asp:SqlDataSource>
                           </div>
                             </div>
                             
                        <br />

                     
                     </div>
                     </header>
                     </div>
                     

    </div>

   

    </form>



   

</body>
</html>

