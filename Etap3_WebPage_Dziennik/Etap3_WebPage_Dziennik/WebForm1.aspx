<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Etap3_WebPage_Dziennik.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            border-style: solid;
            border-width: 1px;
            background-color: #FFFFFF;
        }
        .auto-style2 {
            width: 224px;
        }
        .auto-style3 {
            width: 224px;
            text-align: right;
        }
        .auto-style4 {
            text-align: center;
            font-size: x-large;
        }
        .auto-style5 {
            width: 22%;
        }
        .auto-style6 {
            width: 224px;
            height: 30px;
        }
        .auto-style7 {
            width: 22%;
            height: 30px;
            text-align: center;
        }
        .auto-style8 {
            height: 30px;
        }
        .auto-style9 {
            text-align: left;
        }
        .auto-style10 {
            width: 22%;
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="auto-style4"><strong>Login Page</strong></div>
        
    </div>
    <table class="auto-style1">
        <tr>
            <td class="auto-style3">Username:&nbsp; </td>
            <td class="auto-style5">
                <asp:TextBox ID="TextBoxUsername" runat="server" Width="180px">prowadzacy1@dziennk.com</asp:TextBox>
            </td>
            <td class="auto-style9">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxUsername" ErrorMessage="The username is required." ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Password:</td>
            <td class="auto-style5">
                <asp:TextBox ID="TextBoxPassword" runat="server" Width="180px">haslo1</asp:TextBox>
            </td>
            <td class="auto-style9">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxPassword" ErrorMessage="The password is required." ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Type of user:</td>
            <td class="auto-style10">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                    <asp:ListItem>Student</asp:ListItem>
                    <asp:ListItem>Teacher</asp:ListItem>
                    <asp:ListItem>Admin</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td class="auto-style9">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="RadioButtonList1" ErrorMessage="Choose the right user." ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style6"></td>
            <td class="auto-style7">
                <asp:Button ID="ButtonLogin" runat="server" OnClick="ButtonLogin_Click" Text="Login" Width="100px" />
            </td>
            <td class="auto-style8"></td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    </form>
    </body>
</html>
