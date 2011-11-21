using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Linq;
using CodeCampster.Models;

namespace CodeCampster.Tests
{
    [TestFixture]
    public class SessionExamplesFixture
    {
        Configuration cfg;
        ISessionFactory sessionFactory;
        ISession s;

        [TestFixtureSetUp]
        public void Setup()
        {
            cfg = new Configuration()
                    .Configure();
            sessionFactory = cfg.BuildSessionFactory();
        }

        [SetUp, TearDown]
        public void ResetDatabase()
        {
            var schemaExport = new SchemaExport(cfg);
            schemaExport.Execute(false, true, false);
        }

        private void Session(Action<int> action)
        {
            using (session = sessionFactory.OpenSession())
            {
                action.Invoke();
            }
        }

        [Test]
        public void Save_entity()
        {
            Session((i) =>
                {
                    
                    
                });

        }

        [Test]
        public void Retrieve_entity_by_id()
        {
            Session

        }

        [Test]
        public void Retrieve_entity_by_name_with_criteria()
        {

        }

        [Test]
        public void Retrieve_entity_by_address_with_hql()
        {

        }

        [Test]
        public void Retrieve_entity_by_id_with_linq()
        {

        }

        [Test]
        public void Update_entity()
        {

        }

        [Test]
        public void Delete_entity_in_same_session()
        {

        }

        [Test]
        public void Delete_entity_in_different_session()
        {

        }



    }
}
