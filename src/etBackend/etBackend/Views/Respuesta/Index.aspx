<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<etBackend.Model.respuesta>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <table>
        <tr>
            <th></th>
            <th>
                id
            </th>
            <th>
                contador
            </th>
            <th>
                texto
            </th>
            <th>
                id_pregunta
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { id=item.id }) %> |
                <%= Html.ActionLink("Details", "Details", new { id=item.id })%>
            </td>
            <td>
                <%= Html.Encode(item.id) %>
            </td>
            <td>
                <%= Html.Encode(item.contador) %>
            </td>
            <td>
                <%= Html.Encode(item.texto) %>
            </td>
            <td>
                <%= Html.Encode(item.id_pregunta) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

