<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Booking.aspx.cs" Inherits="Netcafe.Booking" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 27%;
            height: 314px;
        }
        .auto-style2 {
            width: 67px;
        }
        .auto-style7 {
            width: 58px;
        }
        .auto-style9 {
            width: 63px;
        }
        .auto-style11 {
            width: 28px;
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="Label1" runat="server" Font-Size="XX-Large" Text="Insert name net cafe"></asp:Label>
        <p>
            Internet cafe booking system Asp.net</p>
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="Button1" runat="server" Height="50px" style="text-align: center" Text="1" Width="58px" OnClick="Button1_Click" />
                </td>
                <td class="auto-style2">
                    <asp:Button ID="Button2" runat="server" Height="50px" Text="2" Width="58px" OnClick="Button2_Click" />
                </td>
                <td class="auto-style2">
                    <asp:Button ID="Button3" runat="server" Height="50px" style="text-align: center" Text="3" Width="58px" OnClick="Button3_Click" />
                </td>
                <td class="auto-style2">
                    <asp:Button ID="Button4" runat="server" Height="50px" style="text-align: center" Text="4" Width="58px" OnClick="Button4_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="Button5" runat="server" Height="50px" style="text-align: center" Text="5" Width="58px" OnClick="Button5_Click" />
                </td>
                <td class="auto-style2">
                    <asp:Button ID="Button6" runat="server" Height="50px" style="text-align: center" Text="6" Width="58px" OnClick="Button6_Click" />
                </td>
                <td class="auto-style2">
                    <asp:Button ID="Button7" runat="server" Height="50px" style="text-align: center" Text="7" Width="58px" OnClick="Button7_Click" />
                </td>
                <td class="auto-style2">
                    <asp:Button ID="Button8" runat="server" Height="50px" style="text-align: center" Text="8" Width="58px" OnClick="Button8_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="Button9" runat="server" Height="50px" style="text-align: center" Text="9" Width="58px" OnClick="Button9_Click" />
                </td>
                <td class="auto-style2">
                    <asp:Button ID="Button10" runat="server" Height="50px"  style="text-align: center" Text="10" Width="58px" OnClick="Button10_Click" />
                </td>
                <td class="auto-style2">
                    <asp:Button ID="Button11" text="11" runat="server" Height="50px"  style="text-align: center" Width="58px" OnClick="Button11_Click" />
                </td>
                <td class="auto-style2">
                    <asp:Button ID="Button12" Text="12" runat="server" Height="50px" style="text-align: center" Width="58px" OnClick="Button12_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="Button13"  runat="server" Height="50px" style="text-align: center" Text="13" Width="58px" OnClick="Button13_Click" />
                </td>
                <td class="auto-style7">
                    <asp:Button ID="Button14"  runat="server" Height="50px" style="text-align: center" Text="14" Width="58px" OnClick="Button14_Click" />
                </td>
                <td class="auto-style9">
                    <asp:Button ID="Button15" runat="server" Height="50px" style="text-align: center" Text="15" Width="58px" OnClick="Button15_Click" />
                </td>
                <td class="auto-style11">
                    <asp:Button ID="Button16"  runat="server" Height="50px" style="text-align: center" Text="16" Width="58px" OnClick="Button16_Click" />
                </td>
            </tr>
        </table>
        <asp:Button ID="Button17" runat="server" BackColor="#66FF33" ForeColor="Black" Height="55px" Text="Book now" Width="227px" OnClick="Button17_Click" />
        <asp:Button ID="Button18" runat="server" OnClick="Button18_Click" Text="Clear bookings" />
        <asp:DropDownList ID="hours" runat="server" Height="23px" >
            <asp:ListItem>0</asp:ListItem>
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
            <asp:ListItem>6</asp:ListItem>
        </asp:DropDownList>
    </form>
    </body>
</html>
