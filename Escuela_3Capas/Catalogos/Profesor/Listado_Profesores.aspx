<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Listado_Profesores.aspx.cs" Inherits="Escuela_3Capas.Catalogos.Profesor.Listado_Profesores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <h2>Listado de Profesores</h2>
        <p>
            <%--<asp:Button ID="Insertar" runat="server" Text="Agregar" CssClass="btn btn-primary" Width="85px" OnClick="Insertar_Click" /></p>--%>
            <asp:Button ID="Insertar" runat="server" Text="Agregar" CssClass="btn btn-primary" Width="300px" OnClick="Insertar_Click" />
        </p>
    </div>

    <div class="row">

        <asp:GridView ID="GVProfesores" runat="server"
            CssClass="table table-bordered table-striped table-condensed"
            AutoGenerateColumns="false"
            DataKeyNames="ID_Profesor"
            OnRowDeleting="GVProfesores_RowDeleting"
            OnRowCommand="GVProfesores_RowCommand"
            OnRowEditing="GVProfesores_RowEditing"
            OnRowUpdating="GVProfesores_RowUpdating"
            OnRowCancelingEdit="GVProfesores_RowCancelingEdit">
            <%-- Arriba se generan los eventos "onrow" --%>
            <Columns>
                <asp:BoundField DataField="ID_Profesor" HeaderText="No. de Profesor" ItemStyle-Width="50px" ReadOnly="true" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" ItemStyle-Width="85px" />
                <asp:BoundField DataField="APaterno" HeaderText="Apellido Paterno" ItemStyle-Width="85px" />
                <asp:BoundField DataField="AMaterno" HeaderText="Apellido Materno" ItemStyle-Width="85px" />
                <asp:BoundField DataField="CURP" HeaderText="CURP" ItemStyle-Width="85px" />
                <asp:BoundField DataField="Sexo" HeaderText="Sexo" ItemStyle-Width="85px" />
                <asp:BoundField DataField="Telefono" HeaderText="Telefono" ItemStyle-Width="85px" />
                <asp:BoundField DataField="FechaNacimiento" HeaderText="FechaNacimiento" ItemStyle-Width="85px" />

                <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Editar" Text="Ver Detalles" ControlStyle-CssClass="btn btn-primary btn-xs" ItemStyle-Width="50px" />

                <%--<asp:CommandField ButtonType="Button" HeaderText="2" ShowEditButton="true" ShowHeader="true" ControlStyle-CssClass="btn btn-warning btn-xs" ItemStyle-Width="50px" />--%>

                <asp:CommandField ButtonType="Button" HeaderText="Eliminar" ShowDeleteButton="true" ShowHeader="true" ControlStyle-CssClass="btn btn-danger btn-xs" ItemStyle-Width="50px" CausesValidation="false"/>
            </Columns>
        </asp:GridView>

    </div>

</asp:Content>
