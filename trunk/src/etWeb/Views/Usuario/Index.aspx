<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<etWeb.Models.usuario>>" %>

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
                email
            </th>
            <th>
                usuario1
            </th>
            <th>
                contrasena
            </th>
            <th>
                celular
            </th>
            <th>
                telefono
            </th>
            <th>
                f_ingreso
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { id=item.usuario1 }) %> |
                <%= Html.ActionLink("Details", "Details", new { id=item.usuario1 })%>
            </td>
            <td>
                <%= Html.Encode(item.nombre) %>
            </td>
            <td>
                <%= Html.Encode(item.email) %>
            </td>
            <td>
                <%= Html.Encode(item.usuario1) %>
            </td>
            <td>
                <%= Html.Encode(item.contrasena) %>
            </td>
            <td>
                <%= Html.Encode(item.celular) %>
            </td>
            <td>
                <%= Html.Encode(item.telefono) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.f_ingreso)) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

