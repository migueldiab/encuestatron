<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<etWeb.et.encuesta>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Crear Nueva Encuesta
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Crear Nueva Encuesta</h2>
    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>
    <p style="color: Red;"><%= Html.ViewData["error"] %></p>
    <% using (Html.BeginForm()) {%>
        <fieldset>
            <legend>Cabezal de Encuesta</legend>
            <p>
                <label for="nombre">Nombre :</label>
                <%= Html.TextBox("nombre") %>
                <%= Html.ValidationMessage("nombre", "*") %>
            </p>
            <p>
                <label for="contrasena">Contraseña :</label>
                <%= Html.Password("contrasena") %>
                <%= Html.ValidationMessage("contrasena", "*") %>
            </p>
            <p>
                <label for="f_vigencia">Fecha de Vigencia :</label>
                <%= Html.DatePicker("f_vigencia", Html.Encode(String.Format("{0:dd/MM/yyyy}", DateTime.Now)))%> 
                <%= Html.ValidationMessage("f_vigencia", "*") %>
            </p>
            <p>
                <label for="f_cierre">Fecha de Cierre:</label>
                <%= Html.DatePicker("f_cierre", Html.Encode(String.Format("{0:dd/MM/yyyy}", DateTime.Now)))%> 
                <%= Html.ValidationMessage("f_cierre", "*") %>
            </p>
            <p>
                <label for="id_cliente">Cliente :</label>
                <%= Html.DropDownList("id_cliente") %>
                <%= Html.ValidationMessage("id_cliente", "*") %>
            </p>
            <p>
                <input type="submit" value="Agregar Preguntas" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Menu Encuestas", "Index") %>
    </div>

</asp:Content>

