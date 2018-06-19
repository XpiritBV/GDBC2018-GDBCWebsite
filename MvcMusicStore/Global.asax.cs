using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;


namespace MvcMusicStore
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mBode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            

          //  System.Environment.SetEnvironmentVariable("MusicStoreEntities", "Data Source=|DataDirectory|MvcMusicStoreEnv.sdf");
     
            System.Data.Entity.Database.SetInitializer(new MvcMusicStore.Models.SampleData());
         

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);

            RouteConfig.RegisterRoutes(RouteTable.Routes);
  
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

        }
    }
}