<%@ Page Title="Escuela" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Listado_Grado.aspx.cs" Inherits="Escuela_3Capas.Catalogos.Grado.Listado_Grado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <h2>Listado de Grados</h2>
            <p>
                <asp:Button ID="Insertar" runat="server" Text="Agregar" CssClass="btn btn-primary" Width="300px" OnClick="Insertar_Click" />
            </p>
        </div>
        <div class="row">
            <asp:GridView ID="GVGrados" runat="server"
                CssClass="table table-bordered table-striped table-condensed"
                AutoGenerateColumns="false"
                DataKeyNames="ID_Grado"
                OnRowDeleting="GVGrados_RowDeleting"
                OnRowCommand="GVGrados_RowCommand"
                OnRowEditing="GVGrados_RowEditing"
                OnRowUpdating="GVGrados_RowUpdating"
                OnRowCancelingEdit="GVGrados_RowCancelingEdit">
                <%-- Arriba se generan los eventos "onrow" --%>
                <Columns>
                    <asp:BoundField DataField="ID_Grado" HeaderText="No. de Grado" ItemStyle-Width="50px" ReadOnly="true" />
                    <asp:BoundField DataField="Grado" HeaderText="Grado" ItemStyle-Width="85px" />
                    <asp:BoundField DataField="Grupo" HeaderText="Grupo" ItemStyle-Width="85px" />
                    <asp:BoundField DataField="ID_Profesor" HeaderText="ID Profesor" ItemStyle-Width="50px" ReadOnly="true"/>

                    <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Editar" Text="Ver Detalles" ControlStyle-CssClass="btn btn-primary btn-xs" ItemStyle-Width="50px" />

                    <asp:CommandField ButtonType="Button" HeaderText="Eliminar" ShowDeleteButton="true" ShowHeader="true" ControlStyle-CssClass="btn btn-danger btn-xs" ItemStyle-Width="50px" CausesValidation="false" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>