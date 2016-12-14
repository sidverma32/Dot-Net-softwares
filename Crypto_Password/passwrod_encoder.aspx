<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="passwrod_encoder.aspx.cs" Inherits="AngularJSwithNET.passwrod_encoder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
	<link rel="stylesheet" type="text/css" href="style.css">
    </head>
    <body>
        <h1>Password Encoder</h1>
 <div class="box">
     <center><asp:Label ID="Label1" runat="server" Text=""></asp:Label></center>
   <form id="form1" runat="server">
   <center> <h4> Select type of password converter:</h4><asp:RadioButtonList ID="RadioButtonList1" runat="server" Height="35px" ValidationGroup="r1" >
       <asp:ListItem>Basic</asp:ListItem>
       <asp:ListItem>Medium</asp:ListItem>
       <asp:ListItem>Classic</asp:ListItem>
       </asp:RadioButtonList></center><br>
      <center>  Enter your real passoword:   <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br /><br />
        Your encoded password: <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></center>
    <div>
    
    </div>
      <center>  <p>
            <asp:Button ID="Button1" runat="server" CssClass="button" Text="Button" OnClick="Button1_Click" />
        </p></center>
    </form>
</div>

    
</body>
</html>
