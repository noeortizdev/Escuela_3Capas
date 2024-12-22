<%@ Page Title="Escuela" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Listado_Calificaciones.aspx.cs" Inherits="Escuela_3Capas.Catalogos.Calificacion.Listado_Calificaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
    <div class="row">
        <h2>Listado de Calificaciones</h2>
        <p>
            <asp:Button ID="Insertar" runat="server" Text="Agregar" CssClass="btn btn-primary" Width="300px" OnClick="Insertar_Click" />
        </p>
    </div>
    <div class="row">
        <asp:GridView ID="GVCalificaciones" runat="server"
            CssClass="table table-bordered table-striped table-condensed"
            AutoGenerateColumns="false"
            DataKeyNames="ID_Calificacion"
            OnRowDeleting="GVCalificaciones_RowDeleting"
            OnRowCommand="GVCalificaciones_RowCommand"
            OnRowEditing="GVCalificaciones_RowEditing"
            OnRowUpdating="GVCalificaciones_RowUpdating"
            OnRowCancelingEdit="GVCalificaciones_RowCancelingEdit">
            <%-- Arriba se generan los eventos "onrow" --%>
            <Columns>
                <asp:BoundField DataField="ID_Calificacion" HeaderText="No. de Calificaciones" ItemStyle-Width="50px" ReadOnly="true" />
                <asp:BoundField DataField="Calificacion" HeaderText="Calificacion" ItemStyle-Width="85px" />
                <asp:BoundField DataField="ID_Estudiante" HeaderText="ID Estudiante" ItemStyle-Width="50px" ReadOnly="true" />
                <asp:BoundField DataField="ID_Asignatura" HeaderText="ID Asignatura" ItemStyle-Width="50px" ReadOnly="true" />

                <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Editar" Text="Ver Detalles" ControlStyle-CssClass="btn btn-primary btn-xs" ItemStyle-Width="50px" />

                <asp:CommandField ButtonType="Button" HeaderText="Eliminar" ShowDeleteButton="true" ShowHeader="true" ControlStyle-CssClass="btn btn-danger btn-xs" ItemStyle-Width="50px" CausesValidation="false" />
            </Columns>
        </asp:GridView>
    </div>
</div>
</asp:Content>