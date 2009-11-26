<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<etWeb.Models.encuesta>" %>

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
                <label for="nombre">nombre:</label>
                <%= Html.TextBox("nombre", Model.nombre) %>
                <%= Html.ValidationMessage("nombre", "*") %>
            </p>
            <p>
                <label for="contrasena">contrasena:</label>
                <%= Html.TextBox("contrasena", Model.contrasena) %>
                <%= Html.ValidationMessage("contrasena", "*") %>
            </p>
            <p>
                <label for="f_ingreso">f_ingreso:</label>
                <%= Html.TextBox("f_ingreso", String.Format("{0:g}", Model.f_ingreso)) %>
                <%= Html.ValidationMessage("f_ingreso", "*") %>
            </p>
            <p>
                <label for="f_modificacion">f_modificacion:</label>
                <%= Html.TextBox("f_modificacion", String.Format("{0:g}", Model.f_modificacion)) %>
                <%= Html.ValidationMessage("f_modificacion", "*") %>
            </p>
            <p>
                <label for="f_vigencia">f_vigencia:</label>
                <%= Html.TextBox("f_vigencia", String.Format("{0:g}", Model.f_vigencia)) %>
                <%= Html.ValidationMessage("f_vigencia", "*") %>
            </p>
            <p>
                <label for="f_cierre">f_cierre:</label>
                <%= Html.TextBox("f_cierre", String.Format("{0:g}", Model.f_cierre)) %>
                <%= Html.ValidationMessage("f_cierre", "*") %>
            </p>
            <p>
                <label for="id_agente">id_agente:</label>
                <%= Html.TextBox("id_agente", Model.id_agente) %>
                <%= Html.ValidationMessage("id_agente", "*") %>
            </p>
            <p>
                <label for="id_cliente">id_cliente:</label>
                <%= Html.TextBox("id_cliente", Model.id_cliente) %>
                <%= Html.ValidationMessage("id_cliente", "*") %>
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

