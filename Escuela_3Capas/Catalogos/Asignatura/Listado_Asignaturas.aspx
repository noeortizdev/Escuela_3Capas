<%@ Page Title="Escuela" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Listado_Asignaturas.aspx.cs" Inherits="Escuela_3Capas.Catalogos.Asignatura.Listado_Asignaturas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Listado de Asignaturas</h2>
        <p>
            <%--<asp:Button ID="Insertar" runat="server" Text="Agregar" CssClass="btn btn-primary" Width="85px" OnClick="Insertar_Click" /></p>--%>
            <asp:Button ID="Insertar" runat="server" Text="Agregar" CssClass="btn btn-primary" Width="300px" OnClick="Insertar_Click" /></p>
    </div>

    <div class="row">
        <asp:GridView ID="GVAsignaturas" runat="server"
            CssClass="table table-bordered table-striped table-condensed"
            AutoGenerateColumns="false"
            DataKeyNames="ID_Asignatura"
            OnRowDeleting="GVAsignaturas_RowDeleting"
            OnRowCommand="GVAsignaturas_RowCommand"
            OnRowEditing="GVAsignaturas_RowEditing"
            OnRowUpdating="GVAsignaturas_RowUpdating"
            OnRowCancelingEdit="GVAsignaturas_RowCancelingEdit">
            <%-- Arriba se generan los eventos "onrow" --%>
            <Columns>
                <asp:BoundField DataField="ID_Asignatura" HeaderText="No. de Asignatura" ItemStyle-Width="50px" ReadOnly="true" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" ItemStyle-Width="85px" />

                <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Editar" Text="Ver Detalles" ControlStyle-CssClass="btn btn-primary btn-xs" ItemStyle-Width="50px" />

                <%--<asp:CommandField ButtonType="Button" HeaderText="2" ShowEditButton="true" ShowHeader="true" ControlStyle-CssClass="btn btn-warning btn-xs" ItemStyle-Width="50px" />--%>

                <asp:CommandField ButtonType="Button" HeaderText="Eliminar" ShowDeleteButton="true" ShowHeader="true" ControlStyle-CssClass="btn btn-danger btn-xs" ItemStyle-Width="50px" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
