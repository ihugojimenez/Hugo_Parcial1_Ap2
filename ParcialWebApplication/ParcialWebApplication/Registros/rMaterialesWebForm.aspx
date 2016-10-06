<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="rMaterialesWebForm.aspx.cs" Inherits="ParcialWebApplication.Registros.rMaterialesWebForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 129px;
        }
        .auto-style3 {
            width: 254px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style2">IdMaterial</td>
            <td class="auto-style3">
                <asp:TextBox ID="IdTextBox" runat="server" Width="122px"></asp:TextBox>
&nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="IdTextBox" ErrorMessage="Favor digite el Id " ForeColor="#CC0000" ValidationGroup="BuscarId">*</asp:RequiredFieldValidator>
                <asp:Button ID="SearchButton" runat="server" Text="Buscar" ValidationGroup="BuscarId" Width="94px" OnClick="SearchButton_Click" />
            </td>
            <td>
                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ForeColor="#CC0000" ValidationGroup="BuscarId" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">Descripcion</td>
            <td class="auto-style3">
                <asp:TextBox ID="DescTextBox" runat="server" Width="230px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DescTextBox" ErrorMessage="Favor Ingresar la descripcion del material" ForeColor="#CC0000" ValidationGroup="guardarDatos">*</asp:RequiredFieldValidator>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">Precio</td>
            <td class="auto-style3">
                <asp:TextBox ID="PrcTextBox" runat="server" Width="228px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="PrcTextBox" ErrorMessage="Favor ingrese el precio" ForeColor="Red" ValidationGroup="guardarDatos">*</asp:RequiredFieldValidator>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Button ID="NewButton" runat="server" Text="Nuevo" Width="93px" OnClick="NewButton_Click" />
            </td>
            <td class="auto-style3">
                <asp:Button ID="SaveButton" runat="server" OnClick="SaveButton_Click" Text="Guardar" ValidationGroup="guardarDatos" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="DeleteButton" runat="server" Text="Eliminar" OnClick="DeleteButton_Click" ValidationGroup="BuscarId" />
            </td>
            <td>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="#CC0000" ValidationGroup="guardarDatos" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
