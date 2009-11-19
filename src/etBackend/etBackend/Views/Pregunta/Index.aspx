<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<etBackend.Model.pregunta>>" %>

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
                planteo
            </th>
            <th>
                condicion
            </th>
            <th>
                f_ultima_respuesta
            </th>
            <th>
                id_encuesta
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
                <%= Html.Encode(item.planteo) %>
            </td>
            <td>
                <%= Html.Encode(item.condicion) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.f_ultima_respuesta)) %>
            </td>
            <td>
                <%= Html.Encode(item.id_encuesta) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

