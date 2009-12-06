<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<etWeb.et.encuesta>>" %>


<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Encuestas por Fecha de Ingreso
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Encuestas por Fecha de Ingreso</h2>

  <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>
                <label for="fechaInicial">Inicio - Fin</label>
                <%= Html.DatePicker("fechaInicial", Html.Encode(String.Format("{0:dd/MM/yyyy}", DateTime.Now)))%> 
                <%= Html.DatePicker("fechaFinal", Html.Encode(String.Format("{0:dd/MM/yyyy}", DateTime.Now)))%> 
                <%= Html.ValidationMessage("id_cliente", "*")%>
                <input type="submit" value="Ver" />
            
         <fieldset>
            <legend>Resultados</legend>            
               <div>
    </div>
 
    <table class="data-table">
        <tr>
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
                  <%= Html.ActionLink(Html.Encode(item.nombre), "Details", new { id = item.nombre })%>
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

