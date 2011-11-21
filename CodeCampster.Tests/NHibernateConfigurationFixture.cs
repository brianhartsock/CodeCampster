using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NHibernate.Tool.hbm2ddl;
using System.IO;
using System.Reflection;
using CodeCampster.Models;

namespace CodeCampster.Tests
{
    [TestFixture]
    public class NHibernateConfigurationFixture
    {
        private NHibernate.Cfg.Configuration cfg;

        [SetUp]
        public void ConfigureNHibernate()
        {
            cfg = new NHibernate.Cfg.Configuration();
            cfg.Configure();
        }

        [Test]
        public void Configuration_properties_are_set()
        {
            //Examples in NHibernate download (Configuration_Templates)
            Assert.That(cfg.GetProperty("connection.driver_class"), 
                Is.EqualTo("NHibernate.Driver.MySqlDataDriver"));
            Assert.That(cfg.GetProperty("connection.connection_string"), 
                Is.EqualTo("Database=CodeCampster;Data Source=localhost;User Id=root;Password=root"));
            Assert.That(cfg.GetProperty("dialect"), 
                Is.EqualTo("NHibernate.Dialect.MySQLDialect"));
            Assert.That(cfg.GetProperty("proxyfactory.factory_class"), 
                Is.EqualTo("NHibernate.ByteCode.Castle.ProxyFactoryFactory, NHibernate.ByteCode.Castle"));

            //Only from demo - Print all queries to console
            Assert.That(cfg.GetProperty("show_sql"), 
                Is.EqualTo("true"));

        }

        [Test]
        public void Mappings_are_loaded()
        {
            Assert.That(cfg.GetClassMapping(typeof(CodeCamp)), Is.Not.Null);
            Assert.That(cfg.GetClassMapping(typeof(Presentation)), Is.Not.Null);
        }

        [Test]
        public void Print_database_schema_to_console()
        {
            var export = new SchemaExport(cfg);
            export.Execute(true, true, false);
        }

        [Test]
        public void Build_database_from_configuration()
        {
            var export = new SchemaExport(cfg);
            export.Execute(true, true, false);
        }
    }
}
