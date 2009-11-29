using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using DataTypesObjects;
using System.Xml.Serialization;

namespace encuestaTron
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Fachada : System.Web.Services.WebService
    {
        [XmlInclude(typeof(Usuario))]
        [WebMethod]
<<<<<<< .mine
        public ResultadoWs UsuarioLogin(String usuario, String password)
=======
        public bool validarUsuario(String usuario, String password)
>>>>>>> .r31
        {
<<<<<<< .mine
           ResultadoWs retorno = new ResultadoWs();
           Usuario user= new Usuario();
            try
            {
                 user = Usuario.Login(usuario, password);
                 retorno.Resultado.Add(user);
                    
            }
            catch (Exception e)
            {

                retorno.Error = e.Message;
            }
            
            return retorno;
=======
            return Usuario.validarUsuario(usuario, password);
>>>>>>> .r31
        }
    }
}
