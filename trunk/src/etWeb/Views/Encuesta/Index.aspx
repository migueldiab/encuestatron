<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<etWeb.et.encuesta>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Servicios de Encuestas
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Servicios de Encuestas</h2>

    <h4>Ver Encuestas por : </h4>
    <ul>
      <li><%= Html.ActionLink("Agente", "ListaPorAgente")%></li>
      <li><%= Html.ActionLink("Cliente", "ListaPorCliente")%></li>
      <li><%= Html.ActionLink("Fecha de Ingreso", "ListaPorFechaIngreso")%></li>
      <li><%= Html.ActionLink("Fecha de Vigencia", "ListaPorVigencia")%></li>
      <li><%= Html.ActionLink("Fecha de Cierre", "ListaPorCierre")%></li>      
    </ul>

    <h4>Funciones : </h4>
    <ul>
        <li><%= Html.ActionLink("Crear Encuesta", "Create") %></li>
    </ul>
</asp:Content>

