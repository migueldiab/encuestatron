using System;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Castle.ActiveRecord;

namespace etBackend.Models
{
    public class Usuario
    {
        [ActiveRecord]
        public class Supplier : ActiveRecordBase<Supplier>
        {
            [PrimaryKey]
            public int Login { get; set; }

            [Property]
            public string Nombre { get; set; }
        }

        private string login;
        private string nombre;
        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string contrasena;
        public string Contrasena
        {
            get { return contrasena; }
            set { contrasena = value; }
        }



    }
}
