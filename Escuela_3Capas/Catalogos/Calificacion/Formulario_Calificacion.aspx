<%@ Page Title="Escuela" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Formulario_Calificacion.aspx.cs" Inherits="Escuela_3Capas.Catalogos.Calificacion.Formulario_Calificacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <asp:Label ID="Titulo" runat="server" CssClass="text-center modal-title" Text="" Font-Size="30px" Font-Bold="true"></asp:Label>
            <asp:Label ID="SubTitulo" runat="server" CssClass="text-center modal-title" Text="" Font-Size="18px"></asp:Label>
        </div>
        <div class="row col-md-5">
            <div class="form-group">
                <asp:Label ID="lblCalificacion" runat="server" Text="Calificación"></asp:Label>
                <asp:TextBox ID="txtCalificacion" runat="server" Placeholder="(Por ejemplo, 7 a 10)" CssClass="form-control" TextMode="Number" required></asp:TextBox>
                <%-- DLL - Drop Down List --%>
                <asp:Label ID="lblEstudiante" runat="server" Text="Estudiante"></asp:Label>
                <asp:DropDownList ID="ddlEstudiante" runat="server" CssClass="form-control" required></asp:DropDownList>
                <asp:Label ID="lblAsignatura" runat="server" Text="Asignatura"></asp:Label>
                <asp:DropDownList ID="ddlAsignatura" runat="server" CssClass="form-control" required></asp:DropDownList>
            </div>
        </div>
        <br />
        <br />
        <asp:Button ID="btnGuardar" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
        <asp:Button ID="btnCancelar" CssClass="btn btn-secondary" runat="server" Text="Cancelar" BackColor="DarkRed" OnClick="btnCancelar_Click" />
    </div>
</asp:Content>
