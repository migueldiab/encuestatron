<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<etWeb.et.usuario>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        <p>
            nombre:
            <%= Html.Encode(Model.nombre) %>
        </p>
        <p>
            email:
            <%= Html.Encode(Model.email) %>
        </p>
        <p>
            id_usuario:
            <%= Html.Encode(Model.id_usuario) %>
        </p>
        <p>
            contrasena:
            <%= Html.Encode(Model.contrasena) %>
        </p>
        <p>
            celular:
            <%= Html.Encode(Model.celular) %>
        </p>
        <p>
            telefono:
            <%= Html.Encode(Model.telefono) %>
        </p>
        <p>
            f_ingreso:
            <%= Html.Encode(String.Format("{0:g}", Model.f_ingreso)) %>
        </p>
        <p>
            id_rol:
            <%= Html.Encode(Model.id_rol) %>
        </p>
    </fieldset>
    <p>
        <%=Html.ActionLink("Edit", "Edit", new { /* id=Model.PrimaryKey */ }) %> |
        <%=Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

