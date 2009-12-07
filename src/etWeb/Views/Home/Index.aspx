<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Inicio
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">

        
        
            <h1 class="first">Bienvenido a EncuestaTron</h1>
            <div class="photo-container align-left" style="width:202px;">
                <div class="photo-content"> <img src="./Content/images/photo-small-01.jpg" alt="Photo Small 1" /> </div>
                <div class="photo-caption">Seriedad es nuestro compromiso</div>
            </div>
            <p>EncuestaTron lo introduce al fantástico mundo de las encuestas OnLine.</p>
            <ul>
                <li>Rápido.</li>
                <li>Seguro.</li>
                <li>Confiable.</li>
                <li>Económico.</li>
            </ul>
            <div class="photo-container align-right" style="width:202px;">
                <div class="photo-content"> <img src="./Content/images/photo-small-02.jpg" alt="Photo Small 2" /> </div>
                <div class="photo-caption">Miles de encuestas a su alcance</div>
            </div>
         

</asp:Content>
