<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<etWeb.et.encuesta>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        <p>
            nombre:
            <%= Html.Encode(Model.nombre) %>
        </p>
        <p>
            contrasena:
            <%= Html.Encode(Model.contrasena) %>
        </p>
        <p>
            f_ingreso:
            <%= Html.Encode(String.Format("{0:g}", Model.f_ingreso)) %>
        </p>
        <p>
            f_modificacion:
            <%= Html.Encode(String.Format("{0:g}", Model.f_modificacion)) %>
        </p>
        <p>
            f_vigencia:
            <%= Html.Encode(String.Format("{0:g}", Model.f_vigencia)) %>
        </p>
        <p>
            f_cierre:
            <%= Html.Encode(String.Format("{0:g}", Model.f_cierre)) %>
        </p>
        <p>
            id_cliente:
            <%= Html.Encode(Model.id_cliente) %>
        </p>
    </fieldset>
    <p>
        <%=Html.ActionLink("Edit", "Edit", new { /* id=Model.PrimaryKey */ }) %> |
        <%=Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

