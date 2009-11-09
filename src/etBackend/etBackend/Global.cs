using System;
using System.Web;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework.Config;
using etBackend.Models;

namespace etBackend
{
    public class Global : HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            ActiveRecordStarter.Initialize(typeof(Usuario).Assembly, ActiveRecordSectionHandler.Instance);

        }
    }
}
