<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<etWeb.et.pregunta>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Agregar Preguntas a Encuesta
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% etWeb.et.encuesta unaEncuesta = (etWeb.et.encuesta)ViewData["unaEncuesta"]; %>

    <h2>Agregar Preguntas <%= Html.Encode(unaEncuesta.nombre) %></h2>
    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>
      <fieldset>
        Cliente : <%= Html.Encode(unaEncuesta.id_cliente) %><br />
        Vigencia : <%= Html.Encode(unaEncuesta.f_vigencia) %><br />   
        Cierre : <%= Html.Encode(unaEncuesta.f_cierre) %><br />
      <ul>
        <% 
          if (ViewData["listaPreguntas"] != null)
          {
            List<etWeb.et.pregunta> listaPreguntas = (List<etWeb.et.pregunta>)ViewData["listaPreguntas"];
            int i = 0;
            foreach (etWeb.et.pregunta unaPregunta in listaPreguntas)
            {
              i++;%>
          <li><%= Html.Encode(unaPregunta.nro_pregunta) + " - " + Html.Encode(unaPregunta.planteo)%>
              <i><%=Html.ActionLink("[editar]", "EditarPregunta", new { id = unaPregunta.id, encuesta = unaPregunta.id_encuesta })%></i> - 
              <i><%=Html.ActionLink("[borrar]", "BorrarPregunta", new { id = unaPregunta.id, encuesta = unaPregunta.id_encuesta })%></i>
          </li>
        <% } } %>
      </ul>
      </fieldset>
        <fieldset>
            <p>
                <label for="planteo">Planteo Pregunta:</label>
                <%= Html.TextArea("planteo") %>
                <%= Html.ValidationMessage("planteo", "*") %>
            </p>
            <p>
                <label for="nro_pregunta">Numero de Pregunta :</label>
                <%= Html.TextBox("nro_pregunta") %> <i>(en blanco autonumera)</i>
                <%= Html.ValidationMessage("nro_pregunta", "*") %>
            </p>
            <p>
                <%= Html.Hidden("id_encuesta", unaEncuesta.nombre)%>
                <input type="submit" value="Agregar Respuestas" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Menu Enceustas", "Index") %>
    </div>

</asp:Content>

