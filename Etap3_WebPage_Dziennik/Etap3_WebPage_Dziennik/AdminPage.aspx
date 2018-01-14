<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="Etap3_WebPage_Dziennik.AdminPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            width: 200px;
        }
        .auto-style4 {
            text-align: center;
            font-size: x-large;
        }
        .auto-style7 {
            width: 200px;
            text-align: right;
        }
        .auto-style8 {
            width: 200px;
            text-align: right;
            height: 26px;
        }
        .auto-style9 {
            height: 26px;
            width: 221px;
        }
        .auto-style12 {
            height: 26px;
        }
        .auto-style13 {
            width: 609px;
        }
        .auto-style14 {
            width: 221px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style4">
            <strong>Admin page<br />
            </strong>
        </div>
        <div>
            <table class="auto-style2">
                <tr>
                    <td class="auto-style3">
                        <table class="auto-style2">
                            <tr>
                                <td class="auto-style1">MENU</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="Button3" runat="server" Text="Your data" Width="200px" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="Button4" runat="server" Text="Manage groups" Width="200px" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="Button5" runat="server" Text="Manage subjects" Width="200px" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="Button6" runat="server" Text="Manage projects" Width="200px" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="Button7" runat="server" Text="Manage teachers" Width="200px" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="Button9" runat="server" Text="Manage students" Width="200px" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="Button8" runat="server" Text="Back to Login Page" Width="200px" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                    <table class="auto-style13">
                        <tr>
                            <td class="auto-style7">
                                <asp:Label ID="Label1" runat="server" Text="Name:"></asp:Label>
                            </td>
                            <td class="auto-style14">
                                <asp:TextBox ID="TextBox1" runat="server" Enabled="False"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style8">
                                <asp:Label ID="Label2" runat="server" Text="Surname:"></asp:Label>
                            </td>
                            <td class="auto-style9">
                                <asp:TextBox ID="TextBox2" runat="server" Enabled="False"></asp:TextBox>
                            </td>
                            <td class="auto-style12">
                                </td>
                        </tr>
                        <tr>
                            <td class="auto-style7">
                                <asp:Label ID="Label7" runat="server" Text="Login:"></asp:Label>
                            </td>
                            <td class="auto-style14">
                                <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td class="auto-style7">
                                <asp:Label ID="Label8" runat="server" Text="Password:"></asp:Label>
                            </td>
                            <td class="auto-style14">
                                <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td class="auto-style7">
                               
                            </td>
                            <td class="auto-style14">
                               
                            </td>
                            <td>
                                <asp:Button ID="Button2" runat="server" Text="Load data" OnClick="Button2_Click" Width="120px" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style7">
                               
                            </td>
                            <td class="auto-style14">
                               
                            </td>
                            <td>
                                <asp:Button ID="Button1" runat="server" Text="Save changes" OnClick="Button1_Click" Width="120px" />
                            </td>
                        </tr>
                    </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
