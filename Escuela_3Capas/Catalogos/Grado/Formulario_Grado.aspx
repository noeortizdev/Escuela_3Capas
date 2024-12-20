<%@ Page Title="Escuela" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Formulario_Grado.aspx.cs" Inherits="Escuela_3Capas.Catalogos.Grado.Formulario_Grado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <asp:Label ID="Titulo" runat="server" CssClass="text-center modal-title" Text="" Font-Size="30px" Font-Bold="true"></asp:Label>
            <asp:Label ID="Subtitulo" runat="server" CssClass="text-center modal-title" Text="" Font-Size="18px"></asp:Label>
        </div>
        <div class="row col-md-5">
            <asp:Label ID="lblGrado" runat="server" Text="Grado"></asp:Label>
            <asp:TextBox ID="txtGrado" runat="server" Placeholder="(Por ejemplo, Primero o Segundo)" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="lblGrupo" runat="server" Text="Grupo"></asp:Label>
            <asp:TextBox ID="txtGrupo" runat="server" Placeholder="(Por ejemplo, A o B)" CssClass="form-control"></asp:TextBox>
            <%-- DLL - Drop Down List --%>
            <asp:Label ID="lblProfesor" runat="server" Text="Profesor"></asp:Label>
            <asp:DropDownList ID="ddlProfesor" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <br />
        <br />
        <asp:Button ID="btnGuardar" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
        <asp:Button ID="btnCancelar" CssClass="btn btn-secondary" runat="server" Text="Cancelar" BackColor="DarkRed" OnClick="btnCancelar_Click" />
    </div>
</asp:Content>