<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="HackWithPSIT.WebForm2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">  
    <html xmlns="http://www.w3.org/1999/xhtml">  
  
    <head id="Head1" runat="server">  
        <title>Untitled Page</title>  
        <style type="text/css">  
            .Gridview {  
                font-family: Verdana;  
                font-size: 10pt;  
                font-weight: normal;  
                color: black;  
            }  
        </style>  
        
    </head>  
  
    <body>  
        <form id="form1" runat="server">
                <asp:ScriptManager runat="server"></asp:ScriptManager>
            <div>  
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" CellPadding="4" ForeColor="#333333" GridLines="None">  
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>  
                        <asp:BoundField DataField="id" HeaderText="S.No." />  
                        <asp:BoundField DataField="name" HeaderText="Name" />  
                        <asp:BoundField DataField="address" HeaderText="address" />  
                        <asp:BoundField DataField="email" HeaderText="Email" />  
                        <asp:CommandField ShowEditButton="true" />  
                        <asp:CommandField ShowDeleteButton="true" /> </Columns>  
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>  
                        </ContentTemplate>
                    </asp:UpdatePanel>
            </div>  
            <div>  
                <asp:Label ID="lblresult" runat="server"></asp:Label>  
            </div>  
        </form>  
    </body>  
  
    </html>  
