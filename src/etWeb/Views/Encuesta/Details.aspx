<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<etWeb.et.encuesta>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Resultados de Encuesta
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Resultados de : <%= Html.Encode(Model.nombre) %></h2>
    <fieldset>
        <legend>Datos Generales</legend>
        <p>Entró en vigencia : <%= Html.Encode(String.Format("{0:U}", Model.f_vigencia)) %></p>
        <p>Fecha de cierre : <%= Html.Encode(String.Format("{0:U}", Model.f_cierre)) %></p>
        <p>Cliente : <%= Html.Encode(Model.id_cliente) %></p>
    </fieldset>
  <table class="data-table">
      <% foreach (etWeb.et.pregunta unaPregunta in Model.preguntas) { %>
      <th colspan=20>      
        <%= Html.Encode(unaPregunta.planteo) %>
      </th>
      <tr>
        <% foreach (etWeb.et.respuesta unaRespuesta in unaPregunta.respuestas) { %>
          <td><%= Html.Encode(unaRespuesta.texto) %></td>
          <td><%= Html.Encode(unaRespuesta.contador) %></td>
        <% } %>
      </tr>
      <% } %>

    
  </table>
</asp:Content>

