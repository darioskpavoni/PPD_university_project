<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Proiect.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Panou de control</title>
    <link href="reset.css" rel="stylesheet" />
    <link href="styleMainContent.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <div class="top-bar">
            <asp:Label ID="lblWelcome" runat="server" Text=""></asp:Label>
            <asp:Button ID="btnExitSession" runat="server" Text="EXIT" OnClick="btnExitSession_Click" />
        </div>



        <div class="element" id="gridView">
            <asp:GridView ID="GridView1" CssClass="gridView" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="surname" HeaderText="Nume" ItemStyle-VerticalAlign="NotSet" ItemStyle-HorizontalAlign="NotSet" />
                    <asp:BoundField DataField="name" HeaderText="Prenume" />
                    <asp:BoundField DataField="email" HeaderText="Email" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:WebAppConnectionString %>"
                SelectCommand="SELECT * FROM tblUsers"></asp:SqlDataSource>
        </div>


        <div class="element searchDB">
            <asp:Label ID="lblResult" CssClass="elChild" runat="server" Text="Text de cautat"></asp:Label>
            <asp:TextBox ID="txtSearch" CssClass="elChild txtBox" runat="server"></asp:TextBox>
            <asp:Button ID="btnSearch" CssClass="elChild btn" runat="server" Text="Cauta" OnClick="btnSearch_Click" />
        </div>



        <div class="element crudOps">

            <div class="elChild selectedID">
                <asp:Label ID="Label1" runat="server" Text="Selected ID: "></asp:Label>
                <asp:Label ID="lblID" runat="server"></asp:Label>
            </div>


            <div class="elChild recordFields">
                <asp:TextBox ID="txtNameUpdate" CssClass="txtBox" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtSurnameUpdate" CssClass="txtBox" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtEmailUpdate" CssClass="txtBox" runat="server"></asp:TextBox>
            </div>


            <div class="elChild crudBtns">
                <asp:Button ID="btnDeleteRecord" CssClass="crudBtn btn" runat="server" Text="STERGE" OnClick="btnDeleteRecord_Click" Enabled="False" />
                <asp:Button ID="btnUpdateRecord" CssClass="crudBtn btn" runat="server" Text="ACTUALIZEAZA" OnClick="btnUpdateRecord_Click" Enabled="False" />
            </div>

        </div>



    </form>
</body>
</html>
