<%@ Page Title="Escuela" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Formulario_Asignatura.aspx.cs" Inherits="Escuela_3Capas.Catalogos.Asignatura.Formulario_Asignatura" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <asp:Label ID="Titulo" runat="server" CssClass="text-center modal-title" Text="" Font-Size="30px" Font-Bold="true"></asp:Label>
            <asp:Label ID="SubTitulo" runat="server" CssClass="text-center modal-title" Text="" Font-Size="18px"></asp:Label>
        </div>
        <div class="row">
            <div class="col-md-12">
                <%-- Formulario --%>
                <div class="form-group">
                    <%-- Etiquetado --%>
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
                    <%-- Campo --%>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                    <br />
                    <%-- Campos especiales --%>
                    <asp:Button ID="btnGuardar" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
