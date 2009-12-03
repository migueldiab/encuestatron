<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<etWeb.et.encuesta>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Lista Por Agente
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Lista Por Agente</h2>

  <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>
        <fieldset>
            <legend>Seleccione el Agente</legend>            
            <p>
                <label for="id_agente">Agente :</label>
                <%= Html.DropDownList("id_agente")%>
                <%= Html.ValidationMessage("id_agente", "*") %>
            </p>
            <p>
                <input type="submit" value="ListaPorAgente" />
            </p>
        </fieldset>
        
        
         <fieldset>
            <legend>Resultados</legend>            
               <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>
 
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
    <% if (Model!=null) { %>
      <% foreach (var item in Model) { %>
      
          <tr>
              <td>
                  <%= Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }) %> |
                  <%= Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ })%>
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
    <% } %>
    </table>

        </fieldset>
    <% } %>

</asp:Content>

