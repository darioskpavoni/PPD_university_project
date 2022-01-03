<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Proiect.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Intra</title>
    <link href="reset.css" rel="stylesheet" />
    <link href="style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="element">
                <p class="element-text">Adresa email</p>
                <asp:TextBox class="element-txtBox" ID="txtEmail" runat="server" OnTextChanged="emailTxtBox_TextChanged"></asp:TextBox>
            </div>
            <div class="element">
                <p class="element-text">Parola</p>
                <asp:TextBox class="element-txtBox" ID="txtPsw" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div class="element">
                <asp:Button ID="btnLogin" CssClass="signup-btn-primary" runat="server" Text="Intra" OnClick="signupBtn_Click" />
            </div>
        </div>
        <div class="bottom-bar">
            <asp:Label ID="bottomBarText" CssClass="transitionSmooth" runat="server" Text="">Daca nu ai un cont, <a class="switch-page-link" href="signup.aspx">inregistreaza-te aici</a></asp:Label>
        </div>
    </form>
</body>
</html>
