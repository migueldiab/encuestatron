<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<etWeb.Models.usuario>" %>

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
            usuario1:
            <%= Html.Encode(Model.usuario1) %>
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
    </fieldset>
    <p>

        <%=Html.ActionLink("Edit", "Edit", new { id=Model.usuario1 }) %> |
        <%=Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

