<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<etWeb.Models.permiso_usuario>" %>

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
                <label for="id_usuario">id_usuario:</label>
                <%= Html.TextBox("id_usuario", Model.id_usuario) %>
                <%= Html.ValidationMessage("id_usuario", "*") %>
            </p>
            <p>
                <label for="id_permiso">id_permiso:</label>
                <%= Html.TextBox("id_permiso", Model.id_permiso) %>
                <%= Html.ValidationMessage("id_permiso", "*") %>
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

