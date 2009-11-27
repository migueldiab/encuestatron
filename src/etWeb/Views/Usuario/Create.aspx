<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<etWeb.Models.usuario>" %>

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
                <label for="nombre">nombre:</label>
                <%= Html.TextBox("nombre") %>
                <%= Html.ValidationMessage("nombre", "*") %>
            </p>
            <p>
                <label for="email">email:</label>
                <%= Html.TextBox("email") %>
                <%= Html.ValidationMessage("email", "*") %>
            </p>
            <p>
                <label for="usuario1">usuario1:</label>
                <%= Html.TextBox("usuario1") %>
                <%= Html.ValidationMessage("usuario1", "*") %>
            </p>
            <p>
                <label for="contrasena">contrasena:</label>
                <%= Html.TextBox("contrasena") %>
                <%= Html.ValidationMessage("contrasena", "*") %>
            </p>
            <p>
                <label for="celular">celular:</label>
                <%= Html.TextBox("celular") %>
                <%= Html.ValidationMessage("celular", "*") %>
            </p>
            <p>
                <label for="telefono">telefono:</label>
                <%= Html.TextBox("telefono") %>
                <%= Html.ValidationMessage("telefono", "*") %>
            </p>
            <p>
                <label for="f_ingreso">f_ingreso:</label>
                <%= Html.TextBox("f_ingreso") %>
                <%= Html.ValidationMessage("f_ingreso", "*") %>
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

