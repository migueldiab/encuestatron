<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<etBackend.Model.Encuesta>" %>

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
                <label for="contrasena">contrasena:</label>
                <%= Html.TextBox("contrasena") %>
                <%= Html.ValidationMessage("contrasena", "*") %>
            </p>
            <p>
                <label for="f_ingreso">f_ingreso:</label>
                <%= Html.TextBox("f_ingreso") %>
                <%= Html.ValidationMessage("f_ingreso", "*") %>
            </p>
            <p>
                <label for="f_modificacion">f_modificacion:</label>
                <%= Html.TextBox("f_modificacion") %>
                <%= Html.ValidationMessage("f_modificacion", "*") %>
            </p>
            <p>
                <label for="f_vigencia">f_vigencia:</label>
                <%= Html.TextBox("f_vigencia") %>
                <%= Html.ValidationMessage("f_vigencia", "*") %>
            </p>
            <p>
                <label for="f_cierre">f_cierre:</label>
                <%= Html.TextBox("f_cierre") %>
                <%= Html.ValidationMessage("f_cierre", "*") %>
            </p>
            <p>
                <label for="id_agente">id_agente:</label>
                <%= Html.TextBox("id_agente") %>
                <%= Html.ValidationMessage("id_agente", "*") %>
            </p>
            <p>
                <label for="id_cliente">id_cliente:</label>
                <%= Html.TextBox("id_cliente") %>
                <%= Html.ValidationMessage("id_cliente", "*") %>
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

