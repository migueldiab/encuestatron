<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<etWeb.et.encuesta>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Editar Encuesta <%= Html.Encode(Model.nombre) %></h2>
    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>
    <p style="color: Red;"><%= Html.ViewData["error"] %></p>
    <% using (Html.BeginForm()) {%>
        <fieldset>
            <legend>Datos Generales</legend>
            <p>
              <label for="nombre">Nombre :</label>
              <%= Html.Encode(Model.nombre) %>
            </p>
            <p>
                <label for="contrasena">Contraseña :</label>
                <%= Html.Password("contrasena", Model.contrasena) %>
                <%= Html.ValidationMessage("contrasena", "*") %>
            </p>
            <p>
                <label for="f_vigencia">Fecha de Vigencia :</label>
                <%= Html.DatePicker("f_vigencia", Html.Encode(String.Format("{0:dd/MM/yyyy}", Model.f_vigencia)))%> 
                <%= Html.ValidationMessage("f_vigencia", "*") %>
            </p>
            <p>
                <label for="f_cierre">Fecha de Cierre:</label>
                <%= Html.DatePicker("f_cierre", Html.Encode(String.Format("{0:dd/MM/yyyy}", Model.f_cierre)))%> 
                <%= Html.ValidationMessage("f_cierre", "*") %>
            </p>
            <p>
                <label for="id_cliente">Cliente :</label>
                <%= Html.DropDownList("id_cliente")%>
                <%= Html.ValidationMessage("id_cliente", "*") %>
            </p>
            <p>
                <%= Html.Hidden("nombre", Model.nombre)%>
                <input type="submit" value="Guardar y Agregar Preguntas" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Menu Encuestas", "Index") %>
    </div>
    
</asp:Content>