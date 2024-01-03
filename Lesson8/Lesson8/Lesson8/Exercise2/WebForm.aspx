<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm.aspx.cs" Inherits="Exercise2.WebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="labelId" runat="server">Please give me number:</asp:Label>  
            <asp:TextBox ID="Num1" runat="server" ToolTip="Number 1" Width="20px"></asp:TextBox> 
            <asp:TextBox ID="Num2" runat="server" ToolTip="Number 2" Width="20px"></asp:TextBox>  
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" style="height: 26px" />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
            <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
