<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="office.aspx.cs" Inherits="BUISNESS_MEDIA.office" %>

<html>
<head id="Head1" runat="server">
    <title>userprofile</title>
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
                        <li><a href="userprofile.aspx"><i class="fa fa-home" aria-hidden="true"></i><span class="hidden-xs hidden-sm">Home</span></a></li>
                        <li class="active"><a href="office.aspx"><i class="fa fa-tasks" aria-hidden="true"></i><span class="hidden-xs hidden-sm">Office</span></a></li>
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
                   
                        <div class="col-md-7">
                            <asp:Button ID="office_add" runat="server" onclick="office_add_Click" 
                                Text="ADD OFFICE" />
                            <div class="search hidden-xs hidden-sm">
                                <input type="text" placeholder="Search" id="search">
                            </div>
                        </div>

                        <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                        
                        <div class="user-dashboard" style="color:Green;">
                    <div class="row">
                        <div class="col-md-5 col-sm-5 col-xs-12 gutter">
                        <br/>
                            <asp:Button ID="office_add0" runat="server" onclick="del_click" 
                                Text="DEL OFFICE" />
<br/>
                        <br/>
                            <div class="sales" style="overflow:scroll;">
                                <h2>Your offices</h2>
                                <p>&nbsp;</p>
                                <p>&nbsp;</p>
                                <div class="row">

<asp:DataList ID="DataList1" runat="server" RepeatColumns="2" BorderColor="Green" BorderWidth="5px" 
                                        GridLines="Both" onitemcommand="DataList1_ItemCommand" Width="1069px" >
        <ItemTemplate>
                <table>
                    <tr>
                        <td style="padding-left:10px"><asp:Image ID="imgProduct" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "ProductImage") %>' style="width:100px; height:100px;" /></td>
                        <td style="padding-left:20px"> 
                            <asp:Label ID="lblProduct" Text='<%# DataBinder.Eval(Container.DataItem, "ProductName") %>' runat="server" />
                            <br />
                            <asp:Label ID="lblPrice" Text='<%# DataBinder.Eval(Container.DataItem, "Price") %>' runat="server" />
                            <br />
                            <asp:Label ID="Label1" Text='<%# DataBinder.Eval(Container.DataItem, "id") %>' runat="server" />
                            <br />
                            
                        </td>
                        <td style="padding-left:30px"><asp:LinkButton ID="view" Text="ADD Cubicles" runat="server"  CommandName="Select" /></td>
                    </tr>
                </table>
        </ItemTemplate>
</asp:DataList>
                                                                          </div>
                                
                            </div>
                            </div>
                        </div>
                        <div class="col-md-7 col-sm-7 col-xs-12 gutter">

                            <div class="sales report">
                                <h2>joined as a cubic</h2>
                                <p>&nbsp;</p>
                                <p>&nbsp;</p>
                                <div class="row">

<asp:DataList ID="DataList2" runat="server" RepeatColumns="2" BorderColor="#00CC00" BorderWidth="5px" 
                                        GridLines="Both" Width="1078px"  onitemcommand="DataList2_ItemCommand">
        <ItemTemplate>
                <table>
                    <tr>
                        <td style="padding-left:10px"><asp:Image ID="imgProduct" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Profilepic") %>' style="width:100px; height:100px;" /></td>
                        <td style="padding-left:20px"> 
                            <asp:Label ID="lblProduct" Text='<%# DataBinder.Eval(Container.DataItem, "officename") %>' runat="server" />
                            <br />
                            
                            <asp:Label ID="Label1" Text='<%# DataBinder.Eval(Container.DataItem, "id") %>' runat="server" />
                            <br />
                            
                        </td>
                        <td style="padding-left:30px"><asp:LinkButton ID="view" Text="View Cubicles" runat="server"  CommandName="View" /></td>
                    </tr>
                </table>
        </ItemTemplate>
</asp:DataList>
                                                                          </div>
                               
                    
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