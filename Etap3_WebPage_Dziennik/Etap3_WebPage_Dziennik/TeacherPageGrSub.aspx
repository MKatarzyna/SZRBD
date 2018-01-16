<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherPageGrSub.aspx.cs" Inherits="Etap3_WebPage_Dziennik.TeacherPageGrSub" %>

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
        .auto-style14 {
            height: 275px;
        }
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
        .auto-style6 {
            width: 194px;
            text-align: center;
        }
        .auto-style15 {
            text-align: center;
            font-size: x-large;
            height: 30px;
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
            <strong>Teacher page
    
        <span class="auto-style11">
    
        &nbsp;</span></strong><span class="auto-style11">[Grades from subjects]</span><strong><br />
            </strong>
        </div>
        <div class="auto-style14">
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
                                <asp:Button ID="ButtonYourData" runat="server" Text="Your data" Width="200px" OnClick="ButtonYourData_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style4">
                                <asp:Button ID="ButtonSubjects" runat="server" Text="Subjects" Width="200px" OnClick="ButtonSubjects_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style15">
                                <asp:Button ID="ButtonProjects" runat="server" Text="Projects" Width="200px" OnClick="ButtonProjects_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style4">
                                <asp:Button ID="ButtonGrSub" runat="server" Text="Grades from subjects" Width="200px" OnClick="ButtonGrSub_Click" BackColor="#99FF99" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style4">
                                <asp:Button ID="ButtonGrProj" runat="server" OnClick="ButtonGrProj_Click" Text="Grades from projects" Width="200px" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style4">
                                <asp:Button ID="ButtonProjDec" runat="server" OnClick="ButtonProjDec_Click1" Text="Projects declaration" Width="200px" />
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
                                
                                <br />
                                <strong>Add</strong>:<br />
                                Selecte student:<asp:DropDownList ID="DropDownList1" runat="server">
                                </asp:DropDownList>
                                <asp:DropDownList ID="DropDownList2" runat="server" Visible="False">
                                </asp:DropDownList>
                                <br />
                                Select project: <asp:DropDownList ID="DropDownList4" runat="server">
                                </asp:DropDownList>
                                <br />
                                Select grade:<asp:DropDownList ID="DropDownList3" runat="server">
                                </asp:DropDownList>
                                <br />
                                Select comment:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                <br />
                                <asp:Button ID="ButtonAdd" runat="server" Text="Save changes" OnClick="ButtonAdd_Click" />
                                
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style12">
                                <br />
                                <strong>Edit grades:</strong><br />
                                Select row:
                                <asp:DropDownList ID="DropDownList6" runat="server">
                                </asp:DropDownList>
                                <br />
                                Select grade:
                                <asp:DropDownList ID="DropDownList7" runat="server">
                                </asp:DropDownList>
                                <br />
                                Select comment:
                                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                <br />
                                <asp:Button ID="ButtonEdit" runat="server" OnClick="ButtonEdit_Click" Text="Edit" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style12">
                                <br />
                                <strong>Delete</strong>:<br />
                                Select row: <asp:DropDownList ID="DropDownList5" runat="server">
                                </asp:DropDownList>
                                <br />
                                <asp:Button ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" Text="Delete" />
                            </td>
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
