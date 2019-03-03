<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HackWithPSIT.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Necessity Portal</title>
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<style>
*{
	box-sizing:border-box;
}
a:link {
    color: red;
    background-color: transparent;
    text-decoration: none;
}
a:visited {
    color: rgb(163,0,99);
    background-color: transparent;
    text-decoration: none;
}
a:hover {
    color: blue;
    background-color: transparent;
    text-decoration: underline;
}
a:active {
    color: red;
    background-color: transparent;
    text-decoration: underline;
}
.navbar {
  overflow: hidden;
  background-color: green;
  top: 0;
  width: 100%;
  z-index: 150;
  z-shadow:15px;
  position:sticky;
}

.navbar a {
  float: left;
  display: block;
  color: #f2f2f2;
  text-align: center;
  padding:16px;
  text-decoration: none;
  font-size: 17px;
}

.navbar a:hover {
  background: black;
  color: #f2f2f2;
}	

.menu {
  float:left;
  width:20%;
  text-align:center;
}
.menu a {
  background-color:green;
  float:left;
  padding:40px;
  margin-top:7px;
  display:block;
  width:100%;
  color:black;
}
.main {
  float:left;
  width:40%;
  padding:0 20px;
}
.right {
  background-color:green;
  float:left;
  width:20%;
  padding:15px;
  margin-top:7px;
  text-align:center;
}

@media only screen and (max-width:620px) 
{
  .menu, .main, .right
  {
    width:100%;
  }
}
</style>
</head>
<body style="font-family:Verdana;color:black;">
    <form id="form1" runat="server">
    <div class="logo" style="background-color:black;padding:1px;text-align:center;">
<a href="Website1.html"><img src="logo.png" width="175" height="165"></a>
  <h1 style="color:#f2f2f2;">Workers On The Go</h1>
</div>
<div class="navbar">
  <a href="Website1.html">Home</a>
  <a href="Contact.html">Contact</a>
  <a href="Aboutus.html">About Us</a>
</div>

<div style="overflow:auto">
 <div class="menu">
    <a href="Login.aspx">Log In</a>
    <a href="Registration.aspx">Sign Up</a>
  </div>

  <div class="main" align="center"> <h2 align="center"><b>Login</h2> 
	<div style="width: 500px;height: 180px;background-color: green; padding-top: 30px">
        <table runat="server" id="Table3" style="width: 90%;height: 50%;margin: 0 0 0 70px;">
			<tr>
				<td style="font-size: 14px;color: white;width: 60px;">Password:</td>
				<td>
                    <asp:TextBox style="width: 300px;height: 25px;border: 1px solid black" ID="TextBox1" runat="server" placeholder="Enter your Password" ></asp:TextBox></td>
			</tr>
			<tr>
				<td style="font-size: 14px;color: white;width: 60px;text-align:center">Confirm Password</td>
				<td><asp:TextBox style="width: 300px;height: 25px;border: 1px solid black" ID="TextBox2" runat="server" placeholder="Enter your Password" TextMode="Password"></asp:TextBox></td></tr>
			<tr>
				<td></td>
				<td>
                    <asp:Button ID="Button3" runat="server" Text="SUBMIT" style="width: 120px;height: 30px;background-color: white;border: 1px solid black" OnClick="Button3_Click" UseSubmitBehavior="False"/></td>
			</tr>
            
		</table>
        <table runat="server" id="Table2" style="width: 90%;height: 50%;margin: 0 0 0 70px;">
            <tr>
                <td></td><td><asp:DropDownList  ID="DropDownList2" runat="server" Height="28px" Width="189px">
                <asp:ListItem>---SELECT---</asp:ListItem>
                <asp:ListItem>Customer</asp:ListItem>
                <asp:ListItem>Worker</asp:ListItem>
                </asp:DropDownList></td>
            </tr>
			<tr>
				<td style="font-size: 14px;color: white;width: 60px;">Email Id:</td>
				<td>
                    <asp:TextBox style="width: 300px;height: 25px;border: 1px solid black" ID="TextBox_EmailId_Fo" runat="server" placeholder="Enter your Email Id" AutoPostBack="true"></asp:TextBox></td>
			</tr>
			<tr>
				<td style="font-size: 14px;color: white;width: 60px;text-align:center">OTP:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
				<td><asp:TextBox style="width: 300px;height: 25px;border: 1px solid black" ID="TextBox_OTP_Fo" runat="server" placeholder="Enter your OTP" TextMode="Password"></asp:TextBox></td></tr>
			<tr>
				<td></td>
				<td>
                    <asp:Button ID="Resend_Button" runat="server" Text="Send OTP" style="width: 120px;height: 30px;background-color: white;border: 1px solid black" OnClick="Resend_Button_Click" UseSubmitBehavior="False" /><asp:Button ID="Button_Submit_Fo" runat="server" Text="SUBMIT" style="width: 120px;height: 30px;background-color: white;border: 1px solid black" OnClick="Button_Submit_Fo_Click" UseSubmitBehavior="False" /></td>
			</tr>
            <tr>
                <td></td><td>
                    <asp:Label ID="Label1" runat="server" Text="Label" ForeColor="Red"></asp:Label></td>
            </tr>	
		</table>
		<table runat="server" id="Table1" style="width: 90%;height: 50%;margin: 0 0 0 70px;">
            <tr>
                <td></td><td><asp:DropDownList  ID="DropDownList1" runat="server" Height="28px" Width="189px">
                <asp:ListItem>---SELECT---</asp:ListItem>
                <asp:ListItem>Customer</asp:ListItem>
                <asp:ListItem>Worker</asp:ListItem>
                </asp:DropDownList></td>
            </tr>
			<tr>
				<td style="font-size: 14px;color: white;width: 60px;">
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    Login id</td>
				<td><asp:TextBox style="width: 300px;height: 25px;border: 1px solid black" ID="log" runat="server" placeholder="Enter your Email id"></asp:TextBox></td>
			</tr>
			<tr>
				<td style="font-size: 14px;color: white;width: 60px;">Password</td>
				<td><asp:TextBox style="width: 300px;height: 25px;border: 1px solid black" ID="pass" runat="server" placeholder="Enter your password" TextMode="Password"></asp:TextBox></td></tr>
			<tr>
				<td></td>
				<td>
                    <asp:Button ID="Button1" runat="server" Text="Login" style="width: 120px;height: 30px;background-color: white;border: 1px solid black" OnClick="Button1_Click" UseSubmitBehavior="False"/>&nbsp;&nbsp;<asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">forgot password?</asp:LinkButton></td>
			</tr>	
		</table>
	</div>
	<a href='Registration.aspx' style="text-decoration: none;">
		<div style="width: 500px; height: 33px; border: 1px solid black; background-color: green;border-radius: 10px;font-size: 15px;color: black;padding-top: 10px;padding-left: 10%;font-weight: bold;margin-top: 10px;margin-left: 1px;">     CREATE NEW ACCOUNT</div></a>
  </div>
</div>

<div style="background-color:green;text-align:center;padding:10px;margin-top:7px;">© copyright prakhar.agnihotri55@gmail.com</div>
    </form>
</body>
</html>
