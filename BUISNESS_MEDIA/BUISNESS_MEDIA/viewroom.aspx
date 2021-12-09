<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewroom.aspx.cs" Inherits="BUISNESS_MEDIA.viewroom" %>
<html>
<head id="Head1" runat="server">
    <title>userprofile</title>
    <link href="StyleSheet1.css" rel="stylesheet" type="text/css" />
    <link href="datatable/jquery.dataTables.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css"/>    
       <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script> 
 

    
       
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
                    
                        <div class="sales">
                            
                           <h1>Room Name : <asp:Label ID="room_name" runat="server"/></h1>

            <div class="row">  
                <div class="col-md-6">  
                    <asp:TextBox ID="textComment" runat="server" CssClass="input-group" TextMode="MultiLine" Width="300px"  Height="60px" Rows="15" ></asp:TextBox>  
    <%--        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/h.jpg"  Width="30px" Height="30px"  style="border:1px solid #4800ff;" />--%>  
    <br/>        <asp:Button ID="btnCommentpublilsh" CssClass="btn-sm btn-default"   Text="Comment" runat="server"  OnClick="btnCommentPublish_Click" />  
                </div>  
                <div class="col-md-6"></div>  
            </div>  
          
      
        </div>  
      
         <%--Comment Session--%>  
            <asp:GridView ID="GridView1" BorderStyle="None" CssClass="table-responsive" Width="100%"  GridLines="None" runat="server" AutoGenerateColumns="False" ShowHeader="False">  
                <Columns>  
                       
                    <asp:BoundField DataField="ParentCommentID"  Visible="false" HeaderText="ParentCommentID" />  
      
                    <asp:TemplateField HeaderText="ParentMessage">  
                        <ItemTemplate>  
                            <div class="container">  
                                <div class="row">  
                                    <div class="col-lg-12">  
                                         <table>  
                                             <tr>  
                                        <td style="width:55px;vertical-align:top;padding-top:10px">  
                                        <asp:Label ID="lblParentDate" runat="server" Text='<%#Bind("ParanetCommentDate") %>'></asp:Label>  
                                            <br />   
                                                <asp:Image ID="ImageParent" runat="server" style="width:25px;height:25px;" ImageUrl="~/Image/student-512.png" />  
                                        <asp:Label ID="Label4" Font-Bold="true" ForeColor="#cc0066" runat="server" Text='<%# Bind("ParentUserName") %>'></asp:Label>   
                                               
                                        </td>  
                                              </tr>  
                                                     
                                             <tr>  
                                             <td><asp:Label ID="Label1" runat="server" Text='<%# Bind("ParentCommentMessage") %>'></asp:Label></td>       
                                             </tr>  
                                             <tr >  
                                                 <td><asp:Label ID="lb1COmmenId" runat="server" Visible="false" Text='<%#Eval("ParentCommentID") %>'></asp:Label>  
                                               
                                                             <a class="link" id='lnkReplyParent<%#Eval("ParentCommentID") %>' href="javascript:void(0)" onclick="showReply(<%#Eval("ParentCommentID") %>);return false;">Reply</a>   
                                            <a class="link" id="lnkCancle" href="javascript:void(0)" onclick="closeReply(<%#Eval("ParentCommentID") %>);return false;">Cancle</a>  
                                            <div id='divReply<%#Eval("ParentCommentID") %>' style="display:none;margin-top:5px;">  
                                                <asp:TextBox ID="textCommentReplyParent" CssClass="input-group" runat="server" Width="300px" TextMode="MultiLine" ></asp:TextBox>  
                                                <br />  
                                                <asp:Button ID="btnReplyParent" runat="server" Text="Reply" CssClass="input-group btn"  OnClick="btnReplyParent_Click" /></div>  
                                                 </td>  
                                             </tr>  
                                                
                                             <tr >  
                                                  <td style="padding-left:100px;border-bottom:1px solid #4cff00; ">  
                                                     <br />  
                                                        
                                         <asp:GridView ID="GridView2" BorderStyle="None" GridLines="None" runat="server" AutoGenerateColumns="False" DataSource='<%# Bind("Empl") %>' ShowHeader="False">  
                                <Columns>  
                                    <asp:TemplateField HeaderText="UserName">  
                                        <ItemTemplate>  
                                            <asp:Label ID="lblChildDate" runat="server" Text='<%#Bind("ChilCommentDate") %>'></asp:Label>  
                                            <br />  
                                            <asp:Image ID="ImageParent" runat="server" style="width:25px;height:25px;" ImageUrl="~/Image/student-512.png" />  
                                            <asp:Label ID="Label2" runat="server" Font-Bold="true" ForeColor="#ff0066" Text='<%#Bind("UserName") %>'></asp:Label>  
                                            <br />  
                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("ChildcommentMessage") %>'></asp:Label>  
                                            <hr />  
                                              
                                        </ItemTemplate>  
                                    </asp:TemplateField>  
                                       
                                </Columns>  
                            </asp:GridView>   
                             
                                                             <br />  
                                                                
                                                   
                                               
                                                            
                                                       
                                                 </td>  
                                             </tr>  
                                         </table>  
                                    </div>  
                                       
                                </div>  
                            </div>  
                              
                               
                              
                           
                             
                              
                        </ItemTemplate>  
                    </asp:TemplateField>  
                </Columns>  
            </asp:GridView>  
            <br />  
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAllDepartmentsandEmployee" TypeName="ParentCommentIDAcess"></asp:ObjectDataSource>  
            <br />  
          
        </div>  
               
        <script type="text/javascript">
            //GridView Comment  
            function showReply(n) {
                $("#divReply" + n).show();
                return false;
            }
            function closeReply(n) {
                $("#divReply" + n).hide();
                return false;
            }  
               
               
           </script>  
  
















                           <br/>
                        </div>
           
    </div>
    

   

    </form>



   

</body>
</html>


