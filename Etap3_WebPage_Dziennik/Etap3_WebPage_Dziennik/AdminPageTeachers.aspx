<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPageTeachers.aspx.cs" Inherits="Etap3_WebPage_Dziennik.AdminPageTeachers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .auto-style4 {
            text-align: center;
            font-size: x-large;
        }
        .auto-style11 {
            font-size: x-large;
        }
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            width: 200px;
        }
        .auto-style1 {
            text-align: center;
        }
        .auto-style12 {
            width: 330px;
        }
        .auto-style13 {
            width: 669px;
            height: 236px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style4">
            <strong>Admin page
    
        <span class="auto-style11">
    
        &nbsp;</span></strong><span class="auto-style11">[Manage teachers]</span><strong><br />
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
                                    <asp:Button ID="Button3" runat="server" Text="Your data" Width="200px" OnClick="Button3_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="Button4" runat="server" Text="Manage groups" Width="200px" OnClick="Button4_Click" Visible="False" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="Button5" runat="server" Text="Manage subjects" Width="200px" OnClick="Button5_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="Button6" runat="server" Text="Manage projects" Width="200px" OnClick="Button6_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="Button7" runat="server" Text="Manage teachers" Width="200px" BackColor="#99FF99" OnClick="Button7_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="Button9" runat="server" Text="Manage students" Width="200px" OnClick="Button9_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="ButtonBackLP" runat="server" Text="Back to Login Page" Width="200px" OnClick="ButtonBackLP_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                <td style="border-left-style: solid; border-left-width: 3px; border-left-color: #00FF00" class="auto-style14">
                    <table class="auto-style13">
                        <tr>
                            <td class="auto-style12">
                                <asp:GridView ID="GridView1" runat="server">
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style12">
                                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Load data" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style12">
                                <strong>Edit</strong>:
                                <br />
                                Select teacher:
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                </asp:DropDownList>
                                <asp:Button ID="ButtonReadData1" runat="server" OnClick="ButtonReadData1_Click" Text="Read data" />
                                <br />
                                Name: <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                <br />
                                Surname:
                                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                <br />
                                Title:
                                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                <br />
                                Katedra:
                                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                                <br />
                                Login:
                                <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                                <br />
                                Password:
                                <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                                <br />
                                <br />
&nbsp;<asp:Button ID="ButtonEdit" runat="server" Text="Edit" OnClick="ButtonEdit_Click" />
                                
                            &nbsp;
                                <asp:Button ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" Text="Delete" />
&nbsp;
                                <asp:Button ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" Text="Add" />
                                </td>
                        </tr>
                        <tr>
                            <td class="auto-style12">
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style12">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style12">
                                Status: <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
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
