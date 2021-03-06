﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPageGroups.aspx.cs" Inherits="Etap3_WebPage_Dziennik.AdminPageGroups" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .auto-style4 {
            text-align: center;
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
        .auto-style11 {
            font-size: x-large;
        }
        .auto-style13 {
            width: 670px;
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
    
        &nbsp;</span></strong><span class="auto-style11">[Manage groups]</span><strong><br />
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
                                    <asp:Button ID="Button4" runat="server" Text="Manage groups" Width="200px" BackColor="#99FF99" OnClick="Button4_Click" Visible="False" />
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
                    <td style="border-left-style: solid; border-left-width: 3px; border-left-color: #00FF00;">
                    <table class="auto-style13">
                        <tr>
                            <td class="auto-style12">
                                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="GRUPA">
                                    <Columns>
                                        <asp:CommandField ShowEditButton="True" />
                                        <asp:CommandField ShowDeleteButton="True" />
                                        <asp:BoundField DataField="Nazwa_grupy" HeaderText="Nazwa_grupy" SortExpression="Nazwa_grupy" />
                                        <asp:BoundField DataField="Nazwa_kierunku" HeaderText="Nazwa_kierunku" SortExpression="Nazwa_kierunku" />
                                        <asp:BoundField DataField="Nazwa_wydzialu" HeaderText="Nazwa_wydzialu" SortExpression="Nazwa_wydzialu" />
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="GRUPA" runat="server" ConnectionString="<%$ ConnectionStrings:DziennikConnectionString %>" SelectCommand="SELECT GRUPA.Nazwa_grupy, KIERUNEK.Nazwa_kierunku, WYDZIAL.Nazwa_wydzialu FROM GRUPA INNER JOIN KIERUNEK ON GRUPA.ID_kierunku = KIERUNEK.ID_kierunku INNER JOIN WYDZIAL ON KIERUNEK.ID_wydzialu = WYDZIAL.ID_wydzialu"></asp:SqlDataSource>
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
