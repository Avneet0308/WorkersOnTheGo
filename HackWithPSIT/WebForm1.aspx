<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="HackWithPSIT.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:FileUpload ID="FileUpload1" runat="server" />
    <div>
    <asp:Image style="border-radius:10px;" width="100%" height="100%" ID="Image1" runat="server" />
    </div>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />

    </form>
</body>
</html>
