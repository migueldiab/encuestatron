<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<etWeb.et.usuario>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Crear Nuevo Agente
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Crear Nuevo Agente</h2>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>
    <p style="color: Red;"><%= Html.ViewData["error"] %></p>
    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Información del Agente</legend>
            <p>
                <label for="id_usuario">id_usuario:</label>
                <%= Html.TextBox("id_usuario") %>
                <%= Html.ValidationMessage("id_usuario", "*") %>
            </p>
            <p>
                <label for="contrasena">contrasena:</label>
                <%= Html.Password("contrasena") %>
                <%= Html.ValidationMessage("contrasena", "*") %>
            </p>
            <p>
                <label for="nombre">nombre:</label>
                <%= Html.TextBox("nombre") %>
                <%= Html.ValidationMessage("nombre", "*") %>
            </p>
            <p>
                <label for="f_ingreso">f_ingreso:</label>
                <%= Html.DatePicker("f_ingreso", Html.Encode(String.Format("{0:dd/MM/yyyy}", DateTime.Now))) %>
                <%= Html.ValidationMessage("f_ingreso", "*") %>
            </p>                             
            <p>
                <label for="email">email:</label>
                <%= Html.TextBox("email") %>
                <%= Html.ValidationMessage("email", "*") %>
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
        </fieldset>
            <p>
                <input type="submit" value="Crear" /> - <%=Html.ActionLink("Volver a lista", "Index") %>
            </p>

    <% } %>
</asp:Content>

