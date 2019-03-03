<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="HackWithPSIT.Registration" %>

<!DOCTYPE html>
<html lang="en">
<head>
  <title></title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="Style.css" rel="stylesheet" />
    
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <script src="JQuery/jquery-1.4.1.js"></script>
    <script src="JQuery/jquery.keynavigation.js"></script>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script type="text/javascript">
        function ShowPopup() {
            $("#btnShowPopup").click();
        }
    </script>
    <style>
        .navbar {
  overflow: hidden;
  background-color: green;
  top: 0;
  width: 100%;
  z-index: 150;
  z-shadow:15px;
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
       a.al:link {
    color: red;
    background-color: transparent;
    text-decoration: none;
}
a.al:visited {
    color: rgb(163,0,99);
    background-color: transparent;
    text-decoration: none;
}
a.al:hover {
    color: blue;
    background-color: transparent;
    text-decoration: underline;
}
a.al:active {
    color: red;
    background-color: transparent;
    text-decoration: underline;
}
       .bo {
           background-color:white ;
       }
        .di {
            margin-top:4%;
            margin-left:10%;
            margin-right:8%;
        }
        .al {
            text-align:right;
        }
    .fo{
	margin-left:3%;
	font-size:1.2vw;
}
        @media (max-width:767px) {
            .fo {
                margin-left: 3%;
                font-size: 1.8vw;
            }
            .al {
                text-align:left;

            }
            .di {
                margin-top: 4%;
                margin-left: 15%;
            }
        }
       @media (max-width:400px) {
           .fo{
	margin-left:3%;
	font-size:2.5vw;
}
           .al {
                text-align:left;

            }
           .di {
            margin-top:4%;
            margin-left:10%;
        }
       }
    </style>
</head>
<body class="bo">
    <div class="logo" style="background-color:black;padding:1px;text-align:center;">
<a href="Website1.html"><img src="logo.png" width="175" height="165"></a>
  <h1 style="color:#f2f2f2;">Workers On The Go</h1>
</div>
<div class="navbar">
  <a href="Website1.html">Home</a>
  <a href="Contact.html">Contact</a>
  <a href="Aboutus.html">About Us</a>
</div>
    <form id="form1" runat="server">
       
        <div id="CalDiv" runat="server" style="margin-left:7%;margin-top:5%">
            <div style="font-family:Arial">
    Year :
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
        onselectedindexchanged="DropDownList1_SelectedIndexChanged">
    </asp:DropDownList>&nbsp;
    Month:
    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
        onselectedindexchanged="DropDownList2_SelectedIndexChanged">
    </asp:DropDownList>
    <br />
    <asp:Calendar  ID="Calendar1" runat="server" AutoPostBack="true" OnDayRender="Calendar1_DayRender1" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" Width="220px">
            <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
            <OtherMonthDayStyle ForeColor="#CC9966" />
            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
            <SelectorStyle BackColor="#FFCC66" />
            <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
            <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
        </asp:Calendar>
    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
        Text="Get Selected Date" />
                </div></div>

        <div id="MainDiv" runat="server">
        <div style="margin-top:2%">
            <h2 style="text-align:center;font-family:'Times New Roman';">Registration Form</h2>
        </div>
<div class="di">
  <div class="row">
              <div class="col-sm-4 col-md-4 col-lg-4"><p style="font-family:Times New Roman;"><b>Please Select :</b></p></div>
              <div class="col-sm-4 col-md-4 col-lg-4">
                  <asp:RadioButton ID="Type1" runat="server" Text="Worker" GroupName="Type" AutoPostBack="True" /></div>
                  <div class="col-sm-4 col-md-4 col-lg-4">
                      <asp:RadioButton ID="Type2" runat="server" GroupName="Type" Text="Customer" AutoPostBack="True" /></div>
            </div>
     <div class="row">
              <div class="col-sm-4 col-md-4"><p style="font-family:Times New Roman;"><b>First Name :</b></p></div>
              <div class="col-sm-3 col-md-3">
                  <asp:TextBox ID="TextBox_FirstName" runat="server" Width="80%"></asp:TextBox>
              </div>
                  <div class="col-sm-3 col-md-3">
                      
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Mandatory to fill First Name" ControlToValidate="TextBox_FirstName" ForeColor="#FF3300"></asp:RequiredFieldValidator>
              </div>
         <div class="col-sm-2 col-md-2">
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter a valid First Name" ControlToValidate="TextBox_FirstName" ForeColor="#FF3300" ValidationExpression="^[a-zA-Z''-'\s]{1,40}$"></asp:RegularExpressionValidator>
                      
              </div>
            </div>
    <div class="row">
              <div class="col-sm-4 col-md-4"><p style="font-family:Times New Roman;"><b>Last Name :</b></p></div>     
                  <div class="col-sm-3 col-md-3">
                  <asp:TextBox ID="TextBox_LastName" runat="server" Width="80%"></asp:TextBox></div>
                  <div class="col-sm-3 col-md-3">
                      
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*Mandatory to fill Last Name" ControlToValidate="TextBox_LastName" ForeColor="#FF3300"></asp:RequiredFieldValidator>
              </div>
         <div class="col-sm-2 col-md-2">
                      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter a valid Last Name" ControlToValidate="TextBox_LastName" ForeColor="#FF3300" ValidationExpression="^[a-zA-Z''-'\s]{1,40}$"></asp:RegularExpressionValidator>
                      
              </div>
            </div>
     <div class="row">
              <div class="col-sm-4 col-md-4"><p style="font-family:Times New Roman;"><b>Address :</b></p></div>     
                  <div class="col-sm-3 col-md-3">
                  <asp:TextBox ID="TextBox_Address" runat="server" Width="80%"></asp:TextBox></div>
                  <div class="col-sm-3 col-md-3">
                      
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Mandatory to fill Address" ForeColor="#FF3300" ControlToValidate="TextBox_Address"></asp:RequiredFieldValidator>
              </div></div>
    <div class="row">
              <div class="col-sm-4 col-md-4"><p style="font-family:Times New Roman;"><b>City :</b></p></div>     
                  <div class="col-sm-3 col-md-3">
                  <asp:TextBox ID="TextBox_City" runat="server" Width="80%"></asp:TextBox></div>
                  <div class="col-sm-3 col-md-3">
                      
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Mandatory to fill Address" ControlToValidate="TextBox_City" ForeColor="#FF3300"></asp:RequiredFieldValidator>
              </div></div>
    <div class="row">
              <div class="col-sm-4 col-md-4"><p style="font-family:Times New Roman;"><b>Date of birth :</b></p></div>
              <div class="col-sm-2 col-md-2">
                  <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                  


                  <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" ImageUrl="~/calendar.jpg" OnClick="ImageButton1_Click" />
                  


              </div>
        </div>
    
    <div class="row">
              <div class="col-sm-4 col-md-4"><p style="font-family:Times New Roman;"><b>Gender</b></p></div>
              <div class="col-sm-2 col-md-2">
                  <asp:RadioButton ID="Male_RadioButton" runat="server" GroupName="Gender" Text="Male" /></div>
                  <div class="col-sm-2 col-md-2">
                  <asp:RadioButton ID="Female_RadioButton" runat="server" GroupName="Gender" Text="Female" /></div>
                  <div class="col-sm-2 col-md-2">
                  <asp:RadioButton ID="Other_RadioButton" runat="server" GroupName="Gender" Text="Other" /></div>
                  <div class="col-sm-3 col-md-3">
                      <asp:Label ID="Gender_Label" runat="server" Text="*Please Choose Gender" ForeColor="#FF3300"></asp:Label>
                  </div>
            </div>
    <div class="row">
              <div class="col-sm-4 col-md-4"><p style="font-family:Times New Roman;"><b>Email ID :</b></p></div>
              <div class="col-sm-5 col-md-5">
                  <asp:TextBox ID="TextBox_EmailId" runat="server" Width="70%"  AutoPostBack="true"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="TextBox_EmailId" ErrorMessage="*Mandatory" ForeColor="#FF3300"></asp:RequiredFieldValidator>
              </div>
        <div class="col-sm-3 col-md-3">
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Enter a Valid Email" ControlToValidate="TextBox_EmailId" ForeColor="#FF3300" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></div>
        </div>
    <div class="row">
              <div class="col-sm-4 col-md-4"><p style="font-family:Times New Roman;"><b>Mobile Number :</b></p></div>
              <div class="col-sm-4 col-md-4">
                  <asp:TextBox ID="TextBox_MobileNumber" runat="server" Width="60%" ></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TextBox_MobileNumber" ErrorMessage="*Mandatory" ForeColor="#FF3300"></asp:RequiredFieldValidator></div>
              <div class="col-sm-4 col-md-4">
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Enter a Valid Mobile Number" ControlToValidate="TextBox_MobileNumber" ForeColor="#FF3300" ValidationExpression="^\d+$"></asp:RegularExpressionValidator></div>
        </div>
        <div class="row">
              <div class="col-sm-4 col-md-4"><p style="font-family:Times New Roman;"><b>Upload Profile Picture :</b></p></div>
              <div class="col-sm-4 col-md-4">
                  <asp:FileUpload ID="FileUpload1" runat="server" /></div>
              <div class="col-sm-4 col-md-4">
                  <asp:Label ID="Label_ImgInfo" runat="server" Text="Only jpg , jpeg , gif and png" ForeColor="#FF3300"></asp:Label></div>
              </div>
    <div runat="server" class="row" id="IDNO">
              <div class="col-sm-4 col-md-4"><p style="font-family:Times New Roman;"><b>IdProof Number :</b></p></div>
              <div class="col-sm-4 col-md-4">
                  <asp:TextBox ID="TextBox2" runat="server" Width="60%" ></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox_MobileNumber" ErrorMessage="*Mandatory" ForeColor="#FF3300"></asp:RequiredFieldValidator></div>
              <div class="col-sm-4 col-md-4">
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="Enter a Valid Mobile Number" ControlToValidate="TextBox_MobileNumber" ForeColor="#FF3300" ValidationExpression="^\d+$"></asp:RegularExpressionValidator></div>
        </div>
        <div runat="server" class="row" id="IDIM">
              <div class="col-sm-4 col-md-4"><p style="font-family:Times New Roman;"><b>Upload IdProof Picture :</b></p></div>
              <div class="col-sm-4 col-md-4">
                  <asp:FileUpload ID="FileUpload2" runat="server" /></div>
              <div class="col-sm-4 col-md-4">
                  <asp:Label ID="Label1" runat="server" Text="Only jpg , jpeg , gif and png" ForeColor="#FF3300"></asp:Label></div>
              </div>
    <div runat="server" class="row" id="DivType">
              <div class="col-sm-4 col-md-4"><p style="font-family:Times New Roman;"><b>Worker Type :</b></p></div>
              <div class="col-sm-4 col-md-4">
                  <asp:TextBox ID="TextBox_WType" runat="server" Width="60%" ></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox_WType" ErrorMessage="*Mandatory" ForeColor="#FF3300"></asp:RequiredFieldValidator></div>
        </div>
<div class="row">
              <div class="col-sm-4 col-md-4"><p style="font-family:Times New Roman;"><b>Password :</b></p></div>
              <div class="col-sm-4 col-md-4">
                  <asp:TextBox ID="TextBox_Password" runat="server" Width="60%" TextMode="Password"></asp:TextBox>
              </div>
              <div class="col-sm-4 col-md-4">
            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="*Alphanumeric password with minimum length 6 " ForeColor="#FF3300" ControlToValidate="TextBox_Password" ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9@!#%&amp;/'&quot;;:,&gt;&lt;]{6,10})$"></asp:RegularExpressionValidator></div>
        </div>
    <div class="row">
              <div class="col-sm-4 col-md-4"><p style="font-family:Times New Roman;"><b>Confirm Password :</b></p></div>
              <div class="col-sm-4 col-md-4">
                  <asp:TextBox ID="TextBox_ConfirmPassword" runat="server" Width="60%" TextMode="Password"></asp:TextBox></div>
              <div class="col-sm-4 col-md-4">
                  <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Both password must be same" ControlToCompare="TextBox_Password" ControlToValidate="TextBox_ConfirmPassword" ForeColor="#FF3300"></asp:CompareValidator></div>
        </div>
          </div>
        <div style="margin-left:46%;margin-top:1.5%;margin-bottom:2%;">
            <asp:Button ID="Button1" runat="server" title="Register" Text="Submit" Height="36px" Width="72px" AutoPostBack="true" OnClick="Button1_Click" /> <a title="Sign in" href="Login.aspx" class="fo al">Already a user?</a>
            
        </div>

        </div>
        
        </form>
    <div style="background-color:green;text-align:center;padding:10px;margin-top:7px;">© copyright prakhar.agnihotri55@gmail.com</div>
</body>
</html>
