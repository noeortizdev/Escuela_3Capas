<%@ Page Title="Escuela" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Listado_Estudiantes.aspx.cs" Inherits="Escuela_3Capas.Catalogos.Estudiante.Listado_Estudiantes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <h2>Listado de Estudiantes</h2>
            <p>
                <asp:Button ID="Insertar" runat="server" Text="Agregar" CssClass="btn btn-primary" Width="300px" OnClick="Insertar_Click" />
            </p>
        </div>
        <div class="row col-md-12">
            <asp:GridView ID="GVEstudiantes" runat="server"
                CssClass="table table-bordered table-striped table-condensed"
                AutoGenerateColumns="false"
                DataKeyNames="ID_Estudiante"
                OnRowDeleting="GVEstudiantes_RowDeleting"
                OnRowCommand="GVEstudiantes_RowCommand"
                OnRowEditing="GVEstudiantes_RowEditing"
                OnRowUpdating="GVEstudiantes_RowUpdating"
                OnRowCancelingEdit="GVEstudiantes_RowCancelingEdit">
                <%-- Arriba se generan los eventos "onrow" --%>
                <Columns>
                    <asp:BoundField DataField="ID_Estudiante" HeaderText="No. de Estudiante" ItemStyle-Width="50px" ReadOnly="true" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" ItemStyle-Width="85px" />
                    <asp:BoundField DataField="APaterno" HeaderText="Apellido Paterno" ItemStyle-Width="85px" />
                    <asp:BoundField DataField="AMaterno" HeaderText="Apellido Materno" ItemStyle-Width="85px" />
                    <asp:BoundField DataField="CURP" HeaderText="CURP" ItemStyle-Width="85px" />
                    <asp:BoundField DataField="Sexo" HeaderText="Sexo" ItemStyle-Width="85px" />
                    <asp:BoundField DataField="Telefono" HeaderText="Telefono" ItemStyle-Width="85px" />
                    <asp:BoundField DataField="Direccion" HeaderText="Direccion" ItemStyle-Width="85px" />
                    <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de Nacimiento" ItemStyle-Width="85px" />
                    <asp:BoundField DataField="ID_Grado" HeaderText="ID Grado" ItemStyle-Width="50px" ReadOnly="true"/>

                    <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Editar" Text="Ver Detalles" ControlStyle-CssClass="btn btn-primary btn-xs" ItemStyle-Width="50px" />
                    <asp:CommandField ButtonType="Button" HeaderText="Eliminar" ShowDeleteButton="true" ShowHeader="true" ControlStyle-CssClass="btn btn-danger btn-xs" ItemStyle-Width="50px" CausesValidation="false" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>