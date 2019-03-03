<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkerDashboard.aspx.cs" Inherits="HackWithPSIT.WorkerDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Necessity Portal</title>
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<style>
*{
	box-sizing:border-box;
}
.navbar {
  overflow: hidden;
  background-color: green;
  top: 0;
  width: 100%;
  z-index: 150;
  /*/z-shadow:15px;*/
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

    .imgdiv {
        margin-top:6%;
        background-color:yellow;
        height:50vh;
        margin-left:6%;
        margin-right:6%;
        
    }
.left {
  float:left;
  width:30%;
  /*text-align:center;*/
  height: 100vh;
  background-color: blue;
}
.centre{
    float:right;
  width:70%;
  /*text-align:center;*/
  height: 100vh;
  background-color: red;
}
    @media only screen and (max-width:700px) {
        .imgdiv {
        margin-top:6%;
        background-color:yellow;
        height:30vh;
        margin-left:6%;
        margin-right:6%;
    }
    }
@media only screen and (max-width:1100px) 
{
  .left {
  float:left;
  width:40%;
  /*text-align:center;*/
  height: 100vh;
  background-color: blue;
}
.centre{
    float:right;
  width:60%;
  text-align:center;
  height: 100vh;
  background-color: red;
}
}
@media all and (max-width: 768px) {
    .responsive-width {
        font-size: 1.75vw;
    }
}  
 
@media all and (max-width: 600px) {
    .responsive-width {
        font-size: 2vw;
        font-weight:bold;
    }
}  
 
@media all and (max-width: 480px) {
    .responsive-width {
        font-size: 2.25vw;
        font-weight:bold;
    }
}
@media only screen and (max-width:500px) 
{
  .left
  {
    display:none;
  }
    .centre {
        width:100%;
    }
}
</style>
</head>
<body>
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
 <div class="left">
     <div class="imgdiv"style="border-radius:10px" >
         <asp:Image style="border-radius:10px;" width="100%" height="100%" ID="Image1" runat="server" />
     </div>
     <br />
     <br />
     <div style="margin-left:6%">
         <asp:Label ID="NameLabel" runat="server" Text="Label" CssClass="responsive-width"></asp:Label>
     <br />
     <br />
     <asp:Label ID="PhoneNoLabel" runat="server" Text="Label" CssClass="responsive-width"></asp:Label>
     <br />
     <br />
     <asp:Label ID="EmailLabel" runat="server" Text="Label" CssClass="responsive-width"></asp:Label>
     <br />
     <br />
     <asp:Label ID="DOBLabel" runat="server" Text="Label" CssClass="responsive-width"></asp:Label>
     <br />
     <br />
     <asp:Label ID="GenderLabel" runat="server" Text="Label" CssClass="responsive-width"></asp:Label>
     </div>
     </div>

<div class="centre">
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
</div>

<div style="background-color:green;text-align:center;padding:10px;margin-top:7px;">© copyright prakhar.agnihotri55@gmail.com</div>


    </form>
</body>
</html>
