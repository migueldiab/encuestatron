using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Xml;
using System.Xml.XPath;
using miSitio.Com.etWebService;


namespace miSitio.Com
{
    public partial class _Default : System.Web.UI.Page
    {
       private static etWebService.etWebService etWebService = new etWebService.etWebService();
       private static miSitio.Com.etWebService.ListaEncuestaResult2 lista; 
       private Dictionary<String, String> clavesEncuestas = new Dictionary<String, String>();
       private static pregunta preguntaActiva;
       private static String ACCION_RESPONDER = "Responder";
       private static String ACCION_CONSULTAR = "Consultar";
       private static List<respuesta> respuestasElegidas;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            cargarClavesEncuestas();
            if (!Page.IsPostBack)
            {
                mostrarListaEncuestas();
            }
            lblErrores.Text = "";
        }
        private void limpiarMensajes()
        {
            lblEncuesta.Text = "";
            lblPregunta.Text = "";
        }
        private void mostrarListaEncuestas()
        {
            lista = etWebService.getListaEncuestas();
            GridViewEncuestas.DataSource = lista.ListaEncuestas;
            GridViewEncuestas.DataBind();
        }
        private void cargarClavesEncuestas()
        {
            clavesEncuestas.Add("Enc1", "111");
            clavesEncuestas.Add("Enc2", "222");
            clavesEncuestas.Add("Enc3", "333");
            clavesEncuestas.Add("Enc5", "555");
        }
        protected void getEncuestaParaResponder(String idEncuesta, String pass)
        {
            try
            {
                miSitio.Com.etWebService.ListaEncuestaResult2 response = etWebService.encuestaPorIdPassword(idEncuesta, pass);
                if (response.Error == null)
                {
                    pregunta pregunta = response.ListaEncuestas[0].Preguntas.First();
                    plantearPregunta(pregunta);
                }
                else
                {
                    mostrarMensaje(response.Error);
                }
            }
            catch (Exception ex)
            {

                mostrarMensaje("Error desconocido");
            }
           
        }
        protected void plantearPregunta(pregunta pregunta)
        {
            try
            {
                preguntaActiva = pregunta;
                lblPregunta.Text = pregunta.planteo;
                String[] opciones = new String[pregunta.respuestas.Length];
                if (opciones.Length < 1) mostrarMensaje ("No hay opciones") ;
                int contador = 0;
                foreach (respuesta res in pregunta.respuestas)
                {
                    opciones[contador++] = res.texto;
                }
                this.GridViewOpciones.DataSource = opciones;
                this.GridViewOpciones.DataBind();
            }
            catch (Exception ex)
            {
                
                mostrarMensaje("Error al plantear las opciones");
            }
        }

        protected void GridViewEncuestas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = GridViewEncuestas.SelectedIndex;
                EncuestaPortal encuesta = (EncuestaPortal)lista.ListaEncuestas[index];
                String accion=GridViewEncuestas.Rows[index].Cells[2].Text;
                if ( accion == ACCION_RESPONDER)
                {
                    respuestasElegidas = new List<respuesta>();
                    String idEncuesta = encuesta.Nombre;
                    lblEncuesta.Text = "Respondiendo encuesta: " + idEncuesta;
                    String pass = getPasswordEncuesta(idEncuesta);
                    getEncuestaParaResponder(idEncuesta, pass);
                }
                if (accion == ACCION_CONSULTAR)
                {
                    String idEncuesta = encuesta.Nombre;
                    lblEncuesta.Text = "Consultando encuesta: " + idEncuesta;
                    String pass = getPasswordEncuesta(idEncuesta);
                    getEncuestaParaConsultar(idEncuesta, pass);
                }
                else
                {
                    lblEncuesta.Text = "Encuesta aun inactiva " ;
                }
                

            }
            catch (Exception ex)
            {

                mostrarMensaje(ex.Message);
            }
        }
        protected void getEncuestaParaConsultar(String idEncuesta, String pass)
        {
            try
            {
                miSitio.Com.etWebService.ListaEncuestaResult2 response = etWebService.encuestaPorIdPassword(idEncuesta, pass);
                if (response.Error == null)
                {
                    EncuestaPortal encuesta = response.ListaEncuestas[0];
                    mostrarResultadoEncuesta(encuesta);
                }
                else
                {
                    mostrarMensaje(response.Error);
                }
            }
            catch (Exception ex)
            {

                mostrarMensaje("Error desconocido");
            }

        }
        private void mostrarResultadoEncuesta(EncuestaPortal encuesta)
        {
            Table tabla = new Table();
          int preg = 1;
          
            foreach (pregunta p in encuesta.Preguntas)
            {
                TableRow fila = new TableRow();
                TableCell celda1 = new TableCell();
                celda1.Text = preg.ToString()+" Pregunta:";
                celda1.Font.Bold = true;
                TableCell celda2 = new TableCell();
                celda2.Text = p.planteo;
                TableCell celda3 = new TableCell();
                celda3.Text = "";
                fila.Cells.Add(celda1);
                fila.Cells.Add(celda2);
                fila.Cells.Add(celda3);
                tabla.Rows.Add(fila);
                int resp = 1;
                preg++;
                foreach (respuesta res in p.respuestas)
                {
                    TableRow fila2 = new TableRow();

                    TableCell celda4 = new TableCell();
                    celda4.Text ="-----Opcion -- "+ resp + " ------------->";
                    celda4.Font.Bold = true;
                    TableCell celda5 = new TableCell();
                    celda5.Text = res.texto;
                    TableCell celda6 = new TableCell();
                    celda6.Text = res.contador.ToString();
                    fila2.Cells.Add(celda4);
                    fila2.Cells.Add(celda5);
                    fila2.Cells.Add(celda6);
                    tabla.Rows.Add(fila2);
                    resp++;
                }

            }
            Page.Controls.Add(tabla);

        }
        protected String getPasswordEncuesta(String idEncuesta)
        {
            try
            {
                String retorno = clavesEncuestas[idEncuesta];
                return retorno;

            }
            catch (Exception ex)
            {
                
                this.lblErrores.Text = ex.Message;
                return "no hay clave para la encuesta";
            } 
            
        }

        protected void GridViewOpciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = GridViewOpciones.SelectedIndex;
            respuesta respuestaElegida = preguntaActiva.respuestas[index];
            getSiguientePregunta(respuestaElegida);
        }
        private void getSiguientePregunta(respuesta respuesta)
        {
            respuestasElegidas.Add(respuesta);
            miSitio.Com.etWebService.getPreguntaResult2 response = etWebService.getSiguientePreguntaEncuesta(respuesta);
            if (response.Error == null)
            {
                pregunta pregunta = response.Pregunta;
                plantearPregunta(pregunta);
            }
            else
            {
                if (response.Error.Contains("Gracias"))
                {
                    this.GridViewOpciones.DataSource = null;
                    this.GridViewOpciones.DataBind();
                    miSitio.Com.etWebService.ResultWs response2 = etWebService.guardarEncuesta(respuestasElegidas.ToArray());
                    
                }
                lblPregunta.Text=(response.Error);
            }
            
        }
        private void mostrarMensaje(String msg)
        {
            
            lblErrores.Text ="ATENCION: "+ msg;
        }
    }
}
