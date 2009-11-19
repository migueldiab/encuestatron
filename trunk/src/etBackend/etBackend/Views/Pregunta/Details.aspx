<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<etBackend.Model.pregunta>" %>

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
            planteo:
            <%= Html.Encode(Model.planteo) %>
        </p>
        <p>
            condicion:
            <%= Html.Encode(Model.condicion) %>
        </p>
        <p>
            f_ultima_respuesta:
            <%= Html.Encode(String.Format("{0:g}", Model.f_ultima_respuesta)) %>
        </p>
        <p>
            id_encuesta:
            <%= Html.Encode(Model.id_encuesta) %>
        </p>
    </fieldset>
    <p>

        <%=Html.ActionLink("Edit", "Edit", new { id=Model.id }) %> |
        <%=Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

