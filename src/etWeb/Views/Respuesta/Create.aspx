<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<etWeb.Models.respuesta>" %>

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
                <label for="contador">contador:</label>
                <%= Html.TextBox("contador") %>
                <%= Html.ValidationMessage("contador", "*") %>
            </p>
            <p>
                <label for="texto">texto:</label>
                <%= Html.TextBox("texto") %>
                <%= Html.ValidationMessage("texto", "*") %>
            </p>
            <p>
                <label for="id_pregunta">id_pregunta:</label>
                <%= Html.TextBox("id_pregunta") %>
                <%= Html.ValidationMessage("id_pregunta", "*") %>
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

