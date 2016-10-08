<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="rSolicitudesWebForm.aspx.cs" Inherits="ParcialWebApplication.Registros.rSolicitudesWebForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 104px;
        }
        .auto-style3 {
            width: 260px;
        }
        .auto-style4 {
            width: 104px;
            height: 26px;
        }
        .auto-style5 {
            width: 260px;
            height: 26px;
        }
        .auto-style6 {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style2">IdSolicitud</td>
            <td class="auto-style3">
                <asp:TextBox ID="IdTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="IdTextBox" ErrorMessage="Favor ingrese el ID" ForeColor="#CC0000" ValidationGroup="ID">*</asp:RequiredFieldValidator>
                <asp:Button ID="SearchButton" runat="server" OnClick="SearchButton_Click" Text="Buscar" ValidationGroup="ID" />
            </td>
            <td>Fecha&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="FechaTextBox" runat="server" Width="149px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Favor ingrese la Fecha" ForeColor="#CC0000" ValidationGroup="Guardar" ControlToValidate="FechaTextBox">*</asp:RequiredFieldValidator>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">Razon</td>
            <td class="auto-style3">
                <asp:TextBox ID="RazonTextBox" runat="server" Width="236px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="RazonTextBox" ErrorMessage="Por favor ingrese la Razon" ForeColor="#CC0000" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ForeColor="Red" ValidationGroup="ID" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">Material</td>
            <td class="auto-style3">Cantidad</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:DropDownList ID="MaterialDropDownList" runat="server">
                </asp:DropDownList>
            </td>
            <td class="auto-style3">
                <asp:TextBox ID="CantTextBox" runat="server" Width="119px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="CantTextBox" ErrorMessage="Favor ingrese la cantidad" ForeColor="#CC0000" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
            &nbsp;&nbsp;
                <asp:Button ID="AddButton" runat="server" OnClick="AddButton_Click" Text="Agregar" ValidationGroup="Agregar" />
            </td>
            <td>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="Guardar" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" rowspan="3">
                <asp:GridView ID="DataGridView" runat="server">
                </asp:GridView>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4"></td>
            <td class="auto-style5">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Total</td>
            <td class="auto-style6">
                <asp:TextBox ID="TotalTextBox" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style6"></td>
            <td class="auto-style6"></td>
            <td class="auto-style6"></td>
            <td class="auto-style6"></td>
            <td class="auto-style6"></td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:Button ID="NewButton" runat="server" Text="Nuevo" Width="87px" OnClick="NewButton_Click" />
            </td>
            <td class="auto-style5">
                <asp:Button ID="SaveButton" runat="server" OnClick="SaveButton_Click" Text="Guardar" ValidationGroup="Guardar" />
&nbsp;&nbsp;
                <asp:Button ID="DeleteButton" runat="server" OnClick="DeleteButton_Click" Text="Eliminar" ValidationGroup="ID" />
            </td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
