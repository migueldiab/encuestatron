<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<etWeb.Models.respuesta>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="id">id:</label>
                <%= Html.TextBox("id", Model.id) %>
                <%= Html.ValidationMessage("id", "*") %>
            </p>
            <p>
                <label for="contador">contador:</label>
                <%= Html.TextBox("contador", Model.contador) %>
                <%= Html.ValidationMessage("contador", "*") %>
            </p>
            <p>
                <label for="texto">texto:</label>
                <%= Html.TextBox("texto", Model.texto) %>
                <%= Html.ValidationMessage("texto", "*") %>
            </p>
            <p>
                <label for="id_pregunta">id_pregunta:</label>
                <%= Html.TextBox("id_pregunta", Model.id_pregunta) %>
                <%= Html.ValidationMessage("id_pregunta", "*") %>
            </p>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

