<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<etWeb.Models.permiso>" %>

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
                <label for="nombre">nombre:</label>
                <%= Html.TextBox("nombre", Model.nombre) %>
                <%= Html.ValidationMessage("nombre", "*") %>
            </p>
            <p>
                <label for="permiso1">permiso1:</label>
                <%= Html.TextBox("permiso1", Model.permiso1) %>
                <%= Html.ValidationMessage("permiso1", "*") %>
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

