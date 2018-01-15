<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPageStudents.aspx.cs" Inherits="Etap3_WebPage_Dziennik.AdminPageStudents" %>

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
        .auto-style13 {
            width: 671px;
            height: 236px;
        }
        .auto-style12 {
            width: 330px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style4">
            <strong>Admin page
    
        <span class="auto-style11">
    
        &nbsp;</span></strong><span class="auto-style11">[Manage students]</span><strong><br />
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
                                    <asp:Button ID="Button4" runat="server" Text="Manage groups" Width="200px" OnClick="Button4_Click" />
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
                                    <asp:Button ID="Button7" runat="server" Text="Manage teachers" Width="200px" OnClick="Button7_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="Button9" runat="server" Text="Manage students" Width="200px" BackColor="#99FF99" OnClick="Button9_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="ButtonBackLP" runat="server" Text="Back to Login Page" Width="200px" OnClick="ButtonBackLP_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="border-left-style: solid; border-left-width: 3px; border-left-color: #00FF00;">
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
                                
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                </asp:DropDownList>
                                <asp:CheckBox ID="CheckBox1" runat="server" />
                                <asp:Button ID="Button2" runat="server" Text="Save changes" />
                                
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
