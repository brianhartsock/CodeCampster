using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CodeCampster.Models;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Cfg;

namespace CodeCampster.Tests.Models
{
    [TestFixture]
    public class NHibernateCodeCampRepositoryTests : ICodeCampRespositoryTests
    {
        Configuration cfg;
        ISessionFactory sessionFactory;
        ISession session;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            cfg = new NHibernate.Cfg.Configuration()
                .Configure();

            sessionFactory = cfg.BuildSessionFactory();
        }

        public override void Setup()
        {
            //Recreate database
            var schema = new SchemaExport(cfg);
            schema.Execute(false, true, false);
            
            //Create session
            session = sessionFactory.OpenSession();
            camps = new NHibernateCodeCampRepository(session);
            base.Setup();
            session.Close();

            session = sessionFactory.OpenSession();
            camps = new NHibernateCodeCampRepository(session);
        }

        [TearDown]
        public void TearDown()
        {
            session.Close();
            session.Dispose();
        }
    }
}
