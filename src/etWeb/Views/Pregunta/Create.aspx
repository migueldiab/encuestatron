<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<etWeb.Models.pregunta>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="id">id:</label>
                <%= Html.TextBox("id") %>
                <%= Html.ValidationMessage("id", "*") %>
            </p>
            <p>
                <label for="planteo">planteo:</label>
                <%= Html.TextBox("planteo") %>
                <%= Html.ValidationMessage("planteo", "*") %>
            </p>
            <p>
                <label for="condicion">condicion:</label>
                <%= Html.TextBox("condicion") %>
                <%= Html.ValidationMessage("condicion", "*") %>
            </p>
            <p>
                <label for="f_ultima_respuesta">f_ultima_respuesta:</label>
                <%= Html.TextBox("f_ultima_respuesta") %>
                <%= Html.ValidationMessage("f_ultima_respuesta", "*") %>
            </p>
            <p>
                <label for="id_encuesta">id_encuesta:</label>
                <%= Html.TextBox("id_encuesta") %>
                <%= Html.ValidationMessage("id_encuesta", "*") %>
            </p>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

