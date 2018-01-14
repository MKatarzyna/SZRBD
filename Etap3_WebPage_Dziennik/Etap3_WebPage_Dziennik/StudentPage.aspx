<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentPage.aspx.cs" Inherits="Etap3_WebPage_Dziennik.StudentPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            border-style: solid;
            border-width: 1px;
        }
        .auto-style2 {
            width: 200px;
        }
        .auto-style3 {
            width: 100%;
        }
        .auto-style4 {
            width: 194px;
        }
        .auto-style5 {
            text-align: center;
            font-size: large;
        }
        .auto-style6 {
            width: 194px;
            text-align: center;
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
            width: 200px;
        }
        .auto-style10 {
            height: 310px;
        }
        .auto-style11 {
            font-size: x-large;
        }
        .auto-style12 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="auto-style5">
    
        <strong><span class="auto-style11">Student page</span><br />
        </strong></div>
        <div class="auto-style10">
            <br />
        <table align="left" class="auto-style1">
            <tr>
                <td class="auto-style2">
                    <table align="left" class="auto-style3">
                         <tr>
                            <td class="auto-style6">
                                MENU
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style4">
                                <asp:Button ID="ButtonYourData" runat="server" Text="Your data" Width="200px" BackColor="#99FF99" OnClick="ButtonYourData_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style4">
                                <asp:Button ID="ButtonSubjects" runat="server" Text="Subjects" Width="200px" OnClick="ButtonSubjects_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style4">
                                <asp:Button ID="ButtonProjDec" runat="server" Text="Projects and declarations" Width="200px" OnClick="ButtonProjDec_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style4">
                                <asp:Button ID="ButtonProjGrades" runat="server" Text="Projects grades" Width="200px" OnClick="ButtonProjGrades_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style4">
                                <asp:Button ID="ButtonBackLP" runat="server" Text="Back to Login Page" Width="200px" OnClick="ButtonBackLP_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="border-left-style: solid; border-left-width: 3px; border-left-color: #00FF00">
                    <table class="auto-style3">
                        <tr>
                            <td class="auto-style7">
                                <asp:Label ID="Label1" runat="server" Text="Name:"></asp:Label>
                            </td>
                            <td class="auto-style2">
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
                            <td class="auto-style8">
                                <asp:Label ID="Label3" runat="server" Text="Index number:"></asp:Label>
                            </td>
                            <td class="auto-style9">
                                <asp:TextBox ID="TextBox3" runat="server" Enabled="False"></asp:TextBox>
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td class="auto-style7">
                                <asp:Label ID="Label4" runat="server" Text="Direction:"></asp:Label>
                            </td>
                            <td class="auto-style2">
                                <asp:TextBox ID="TextBox4" runat="server" Enabled="False"></asp:TextBox>
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td class="auto-style7">
                                <asp:Label ID="Label5" runat="server" Text="Department:"></asp:Label>
                            </td>
                            <td class="auto-style2">
                                <asp:TextBox ID="TextBox5" runat="server" Enabled="False"></asp:TextBox>
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td class="auto-style7">
                                <asp:Label ID="Label6" runat="server" Text="Group:"></asp:Label>
                            </td>
                            <td class="auto-style2">
                                <asp:TextBox ID="TextBox6" runat="server" Enabled="False"></asp:TextBox>
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td class="auto-style7">
                                <asp:Label ID="Label7" runat="server" Text="Login:"></asp:Label>
                            </td>
                            <td class="auto-style2">
                                <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td class="auto-style7">
                                <asp:Label ID="Label8" runat="server" Text="Password:"></asp:Label>
                            </td>
                            <td class="auto-style2">
                                <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td class="auto-style7">
                               
                            </td>
                            <td class="auto-style2">
                               
                            </td>
                            <td>
                                <asp:Button ID="Button2" runat="server" Text="Load data" OnClick="Button2_Click" Width="120px" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style7">
                               
                            </td>
                            <td class="auto-style2">
                               
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
