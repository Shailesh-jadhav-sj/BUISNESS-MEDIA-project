<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="work.aspx.cs" Inherits="BUISNESS_MEDIA.work" %>


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
  <a class="logo">Business Media-CUBICLE</a>
  </center>
  </div>
  
    <div class="container-fluid display-table">
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
                        <li><a href="viewcubic.aspx"><i class="fa fa-home" aria-hidden="true"></i><span class="hidden-xs hidden-sm">office-Home</span></a></li>
                        <li  class="active"><a href="work.aspx"><i class="fa fa-tasks" aria-hidden="true"></i><span class="hidden-xs hidden-sm">WORK</span></a></li>
                        <li><a href="connect.aspx"><i class="fa fa-user" aria-hidden="true"></i><span class="hidden-xs hidden-sm">Connect</span></a></li>
                        <li><a href="#"><i class="fa fa-calendar" aria-hidden="true"></i><span class="hidden-xs hidden-sm">Users</span></a></li>
                    </ul>
                </div>
                <!--navbar-->
            </div>
            <div class="col-md-10 col-sm-11 display-table-cell v-align">
                <!--<button type="button" class="slide-toggle">Slide Toggle</button> -->
                <div class="row">
                   
                        

                        
                        
                        <div class="user-dashboard" style="color:Green;">
                    <div class="row">
                        <div class="col-md-5 col-sm-5 col-xs-12 gutter">
                        <br/>
                            
<br/>
                        <br/>
                            <div class="sales" style="overflow:scroll;">
                                <div class="row">
                          
                            <div style="width: 100%;">
                                <div style="width: 25%; height: 100px; float: left; "> 
                                     <asp:Image ID="profilepic" runat="server" hieght="250px" Width="200px" />
                                </div>

                                <div style="float:left; width: 34%; height: 100px;"> 
                                    
                                    
                                    Name&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp: <asp:TextBox runat="server" ID="TextBox1" ReadOnly="true"></asp:TextBox>
                                    Joined Cubicles&nbsp&nbsp&nbsp: <asp:TextBox runat="server" ID="TextBox4" ReadOnly="true"></asp:TextBox>
                                    
                                    
                                    
                                </div>

                                <div style="float:left; width: 38%; height: 100px; "> 
                                    Privacy type&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox runat="server" ID="TextBox2" ReadOnly="true"></asp:TextBox>
                                    
                                    Account creation date  &nbsp&nbsp:&nbsp; <asp:TextBox runat="server" ID="TextBox3" ReadOnly="true"></asp:TextBox>
                                    &nbsp;<br/>
                               </div>
                               <div style="float:right; width: 25%; height: 100px; "> 
                                   

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
                                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                                <asp:GridView ID="GridView1" runat="server" Caption="Excel Files " CaptionAlign="Top" 
                                        HorizontalAlign="Justify" DataKeyNames="work_id"  
                                        onselectedindexchanged="GridView1_SelectedIndexChanged"  onrowcommand="GridView1_RowCommand" 
                                        ToolTip=" DownLoad Tool" CellPadding="20" ForeColor="#333333" 
                                        GridLines="None" Width="781px">  
                <RowStyle BackColor="#E3EAEB" />  
                <Columns>  
                    <asp:CommandField ShowSelectButton="True" SelectText="Download" ControlStyle-ForeColor="Blue"  />
                    <asp:ButtonField Text="uploadedFile" HeaderText="request" ButtonType="Button" CommandName="request" />
                           
                    <asp:TemplateField>
                    <ItemTemplate>
                    <asp:FileUpload ID="FileUpload1" runat="server" />  
                               
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:ButtonField Text="Submit Work"  ControlStyle-ForeColor="Green" CommandName="submit"  /> 
                    
                                     </Columns>  
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />  
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />  
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />  
                <HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="White" />  
                <EditRowStyle BackColor="#7C6F57" />  
                <AlternatingRowStyle BackColor="White" /> </asp:GridView>  
                

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


