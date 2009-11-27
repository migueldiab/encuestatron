<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<etWeb.Models.permiso_usuario>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        <p>
            id_usuario:
            <%= Html.Encode(Model.id_usuario) %>
        </p>
        <p>
            id_permiso:
            <%= Html.Encode(Model.id_permiso) %>
        </p>
    </fieldset>
    <p>

        <%=Html.ActionLink("Edit", "Edit", new { id=Model.id_usuario }) %> |
        <%=Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

