using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CodeCampster.Models;
using NHibernate.Cfg;
using NHibernate;

namespace CodeCampster
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "CodeCamp", action = "Index", id = "" }  // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
        }

        //public const string NHibernateSessionKey = "nhibernate_session";

        //public static ISessionFactory SessionFactory { get; private set; }
    //    protected void Application_Start()
    //    {
    //        RegisterRoutes(RouteTable.Routes);

    //        var cfg = new Configuration()
    //            .Configure();
    //        SessionFactory = cfg.BuildSessionFactory();
    //    }

    //    protected void Application_BeginRequest()
    //    {
    //        var session = SessionFactory.OpenSession();
    //        var transaction = session.BeginTransaction();
    //        Context.Items[NHibernateSessionKey] = session;
    //    }

    //    public static ISession GetCurrentSession()
    //    {
    //        return HttpContext.Current.Items[NHibernateSessionKey] as ISession;
    //    }

    //    protected void Application_EndRequest()
    //    {
    //        var session = GetCurrentSession();
    //        var transaction = session.Transaction;
    //        using (session)
    //        using (transaction)
    //        {
    //            if (Context.Error == null)
    //            {
    //                transaction.Commit();
    //            }
    //            else
    //            {
    //                transaction.Rollback();
    //            }

    //            session.Close();
    //        }
    //    }
    }
}