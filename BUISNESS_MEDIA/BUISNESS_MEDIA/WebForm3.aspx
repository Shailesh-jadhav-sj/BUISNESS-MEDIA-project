<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="BUISNESS_MEDIA.WebForm3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    
    <form id="form1" runat="server">  
        <div>  
            <table>  
                <tr>  
                    <td> Select File </td>  
                    <td>  
                        <asp:FileUpload ID="FileUpload1" runat="server" ToolTip="Select Only Excel File" /> </td>  
                    <td>  
                        <asp:Button ID="Button1" runat="server" Text="Upload" onclick="Button1_Click" /> </td>  
                    <td>  
                        <asp:Button ID="Button2" runat="server" Text="View Files" onclick="Button2_Click" /> </td>  
                </tr>  
            </table>  
            <table>  
                <tr>  
                    <td>  
                        <p>  
                            <asp:Label ID="Label2" runat="server" Text="label"></asp:Label>  
                        </p>  
                    </td>  
                </tr>  
            </table>  
            <asp:GridView ID="GridView1" runat="server" Caption="Excel Files " CaptionAlign="Top" HorizontalAlign="Justify" DataKeyNames="id" onselectedindexchanged="GridView1_SelectedIndexChanged" ToolTip="Excel FIle DownLoad Tool" CellPadding="4" ForeColor="#333333" GridLines="None">  
                <RowStyle BackColor="#E3EAEB" />  
                <Columns>  
                    <asp:CommandField ShowSelectButton="True" SelectText="Download" ControlStyle-ForeColor="Blue" /> </Columns>  
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />  
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />  
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />  
                <HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="White" />  
                <EditRowStyle BackColor="#7C6F57" />  
                <AlternatingRowStyle BackColor="White" /> </asp:GridView>  
        </div>  
    </form>  
</body>
</html>
