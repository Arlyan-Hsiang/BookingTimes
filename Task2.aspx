<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Task2.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Please input a number here:<br />
        <asp:TextBox ID="txtNum" runat="server" Width="191px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnTransfer" runat="server" Text="Transfer" />
        <br />
        <br />
        <asp:Label ID="lblResult" runat="server" Text="output here" BackColor="#CC99FF" Font-Bold="True" Font-Names="Bahnschrift SemiBold SemiConden" Font-Size="Large" Visible="False"></asp:Label>
    
        <br />
        <asp:Label ID="lblResult2" runat="server" Text="output here" BackColor="#CC99FF" Font-Bold="True" Font-Names="Bahnschrift SemiBold SemiConden" Font-Size="Large" Visible="False"></asp:Label>
    
    </div>
    </form>
</body>
</html>
