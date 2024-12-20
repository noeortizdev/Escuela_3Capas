<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Formulario_Profesor.aspx.cs" Inherits="Escuela_3Capas.Catalogos.Profesor.Formulario_Profesor" %>

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

                    <asp:Label ID="lblAPaterno" runat="server" Text="Apellido Paterno"></asp:Label>
                    <asp:TextBox ID="txtAPaterno" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:Label ID="lblAMaterno" runat="server" Text="Apellido Materno"></asp:Label>
                    <asp:TextBox ID="txtAMaterno" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:Label ID="lblCURP" runat="server" Text="CURP"></asp:Label>
                    <asp:TextBox ID="txtCURP" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:Label ID="lblSexo" runat="server" Text="Sexo"></asp:Label>
                    <asp:TextBox ID="txtSexo" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:Label ID="lblTelefono" runat="server" Text="Telefono"></asp:Label>
                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha de Nacimiento"></asp:Label>
                    <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control" TextMode ="Date"></asp:TextBox>
                    <br />
                    <%-- Renglón para los Calendarios --%>
                    <%--<div class="row">
                        <div class="col-md-4">
                            <h5>
                                <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha Nacimiento"></asp:Label>
                            </h5>
                            <asp:Calendar ID="calFechaNacimiento" runat="server" OnSelectionChanged="calFechaNacimiento_SelectionChanged" ShowTitle="True" ShowGridLines="true" ShowNextPrevMonth="True"></asp:Calendar>
                        </div>
                    </div>--%>
                    <%-- Campos especiales --%>
                    <asp:Button ID="btnGuardar" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                    <asp:Button ID="btnCancelar" CssClass="btn btn-secondary" runat="server" Text="Cancelar" BackColor="DarkRed" OnClick="btnCancelar_Click"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
