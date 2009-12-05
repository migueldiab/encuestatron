<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<etWeb.et.respuesta>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	RespuestasPregunta
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% etWeb.et.pregunta unaPregunta = (etWeb.et.pregunta)ViewData["unaPregunta"]; %>
    <h2>Respuestas a : <%= Html.Encode(unaPregunta.planteo) %></h2>
    <ul>
      <% 
        if (ViewData["listaRespuestas"] != null)
        {
          List<etWeb.et.respuesta> listaRespuestas = (List<etWeb.et.respuesta>)ViewData["listaRespuestas"];
          int i = 0;
          foreach (etWeb.et.respuesta unaRespuesta in listaRespuestas)
          {
            i++;%>
        <li><%= i + " - " + Html.Encode(unaRespuesta.texto)%></li>
      <% } } %>
    </ul>
    
    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>
    <% using (Html.BeginForm()) {%>
      
        <fieldset>
            <p>
                <label for="texto">Respuesta :</label>
                <%= Html.TextBox("texto") %>
                <%= Html.ValidationMessage("texto", "*") %>
            </p>
            <p>
                <%= Html.Hidden("id_pregunta", unaPregunta.id)%>
                <input type="submit" name="btnSubmit" value="Guardar y Agregar" />
                <%= Html.ActionLink("Volver a Preguntas", "PreguntasEncuesta", new RouteValueDictionary(new { nombreEncuesta = unaPregunta.id_encuesta }))%>
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

