<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<etWeb.et.encuesta>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <table>
        <tr>
            <th></th>
            <th>
                nombre
            </th>
            <th>
                contrasena
            </th>
            <th>
                f_ingreso
            </th>
            <th>
                f_modificacion
            </th>
            <th>
                f_vigencia
            </th>
            <th>
                f_cierre
            </th>
            <th>
                id_cliente
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { id=item.nombre }) %> |
                <%= Html.ActionLink("Details", "Details", new { id = item.nombre })%>
            </td>
            <td>
                <%= Html.Encode(item.nombre) %>
            </td>
            <td>
                <%= Html.Encode(item.contrasena) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.f_ingreso)) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.f_modificacion)) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.f_vigencia)) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.f_cierre)) %>
            </td>
            <td>
                <%= Html.Encode(item.id_cliente) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

