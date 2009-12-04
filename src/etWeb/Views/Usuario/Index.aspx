<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<etWeb.et.usuario>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Servicios de Usuarios</h2>
    <h4>Acciones :</h4>
    <ul>
        <li><%= Html.ActionLink("Crear Agente", "CrearAgente") %></li>
        <li><%= Html.ActionLink("Crear Cliente", "CrearCliente") %></li>
    </ul>
    <h4>Lista Usuarios :</h4>
    <table class="data-table">
        <tr>
            <th>
                Id
            </th>
            <th>
                Nombre
            </th>
            <th>
                eMail
            </th>
            <th>
                Celular
            </th>
            <th>
                Telefono
            </th>
            <th>
                Ingreso
            </th>
            <th>
                Rol
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
            <% if (item.rol == "Cliente") { %>
              <%= Html.ActionLink(Html.Encode(item.id_usuario), "EditarCliente", new { id = item.id_usuario })%>
            <% } else { %>
              <%= Html.ActionLink(Html.Encode(item.id_usuario), "Edit", new { id = item.id_usuario })%>
            <% } %>
            </td>
            <td>
                <%= Html.Encode(item.nombre) %>
            </td>
            <td>
                <%= Html.Encode(item.email) %>
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
            <td>
                <%= Html.Encode(item.rol) %>
            </td>
        </tr>
    
    <% } %>

    </table>
</asp:Content>

