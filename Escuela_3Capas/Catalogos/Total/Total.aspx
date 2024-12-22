<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Total.aspx.cs" Inherits="Escuela_3Capas.Catalogos.Total.Total" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <h2>Listado de Calificaciones</h2>
            <p>
                <%--<asp:Button ID="Insertar" runat="server" Text="Agregar" CssClass="btn btn-primary" Width="300px" OnClick="Insertar_Click" />--%>
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
                    <asp:BoundField DataField="ID_Calificacion" HeaderText="Nombre" ItemStyle-Width="85px" />
                    <asp:BoundField DataField="Calificacion" HeaderText="Nombre" ItemStyle-Width="85px" />
                    <asp:BoundField DataField="NombreEstudiante" HeaderText="Nombre" ItemStyle-Width="85px" />
                    <asp:BoundField DataField="ApellidoPaterno" HeaderText="Nombre" ItemStyle-Width="85px" />
                    <asp:BoundField DataField="ApellidoMaterno" HeaderText="Nombre" ItemStyle-Width="85px" />
                    <asp:BoundField DataField="Grado" HeaderText="Nombre" ItemStyle-Width="85px" />
                    <asp:BoundField DataField="Grupo" HeaderText="Nombre" ItemStyle-Width="85px" />
                    <asp:BoundField DataField="NombreAsignatura" HeaderText="Nombre" ItemStyle-Width="85px" />

<%--                    <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Editar" Text="Ver Detalles" ControlStyle-CssClass="btn btn-primary btn-xs" ItemStyle-Width="50px" />--%>

                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
