<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<etWeb.Models.respuesta>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        <p>
            id:
            <%= Html.Encode(Model.id) %>
        </p>
        <p>
            contador:
            <%= Html.Encode(Model.contador) %>
        </p>
        <p>
            texto:
            <%= Html.Encode(Model.texto) %>
        </p>
        <p>
            id_pregunta:
            <%= Html.Encode(Model.id_pregunta) %>
        </p>
    </fieldset>
    <p>

        <%=Html.ActionLink("Edit", "Edit", new { id=Model.id }) %> |
        <%=Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

