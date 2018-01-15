<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentPageProDec.aspx.cs" Inherits="Etap3_WebPage_Dziennik.StudentPageProDec" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .auto-style5 {
            text-align: center;
            font-size: large;
        }
        .auto-style11 {
            font-size: x-large;
        }
        .auto-style10 {
           

        }
        .auto-style1 {
            width: 100%;
            border-style: solid;
            border-width: 1px;
        }
        .auto-style3 {
            width: 100%;
        }
        .auto-style6 {
            width: 194px;
            text-align: center;
        }
        .auto-style4 {
            width: 194px;
        }
        .auto-style13 {
            width: 200px;
        }
        .auto-style14 {
            
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="auto-style5">
    
        <span class="auto-style11">
    
        <strong>Student page </strong>[Projects and declarations]</span><strong><br />
        </strong></div>
        <div class="auto-style10">
            <br />
        <table align="left" class="auto-style1">
            <tr>
                <td class="auto-style13">
                    <table align="left" class="auto-style3">
                         <tr>
                            <td class="auto-style6">
                                MENU
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style4">
                                <asp:Button ID="ButtonYourData" runat="server" Text="Your data" Width="200px" OnClick="ButtonYourData_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style4">
                                <asp:Button ID="ButtonSubjects" runat="server" Text="Subjects" Width="200px" OnClick="ButtonSubjects_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style4">
                                <asp:Button ID="ButtonProjDec" runat="server" Text="Projects and declarations" Width="200px" OnClick="ButtonProjDec_Click" BackColor="#99FF99" />
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
                <td style="border-left-style: solid; border-left-width: 3px; border-left-color: #00FF00" class="auto-style14">
                    <table class="auto-style3">
                        <tr>
                            <td>
                                <asp:GridView ID="GridView1" runat="server">
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Load data" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                </asp:DropDownList>
                                <asp:CheckBox ID="CheckBox1" runat="server" />
                                <asp:Button ID="Button2" runat="server" Text="Button" />
                                
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
