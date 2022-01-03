<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="Proiect.signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Inregistreaza-te</title>
    <link href="reset.css" rel="stylesheet" />
    <link href="style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="element">
                <p class="element-text">Prenume</p>
                <asp:TextBox class="element-txtBox" ID="txtName" runat="server"></asp:TextBox>
            </div>
            <div class="element">
                <p class="element-text">Nume</p>
                <asp:TextBox class="element-txtBox" ID="txtSurname" runat="server"></asp:TextBox>
            </div>
            <div class="element">
                <p class="element-text">Adresa email</p>
                <asp:TextBox class="element-txtBox" ID="txtEmail" runat="server"></asp:TextBox>
            </div>
            <div class="element">
                <p class="element-text">Parola</p>
                <asp:TextBox class="element-txtBox" ID="txtPsw" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div class="element">
                <asp:Button ID="btnSignup" CssClass="signup-btn-primary" runat="server" Text="Inregistreaza-te" OnClick="signupBtn_Click" />
            </div>
        </div>
        <div class="bottom-bar">
            <asp:Label ID="bottomBarText" CssClass="transitionSmooth" runat="server" Text="">Daca ai un cont, <a class="switch-page-link" href="login.aspx">intra aici</a></asp:Label>
            
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:WebAppConnectionString %>" SelectCommand="SELECT * FROM [tblUsers]"></asp:SqlDataSource>
    </form>
</body>
</html>
