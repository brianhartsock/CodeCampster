using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Web.Mvc;
using CodeCampster.Models;

namespace CodeCampster.Tests
{
    [TestFixture]
    public class DefaultCodeCampModelBinderTests
    {
        [Test]
        public void all_parameters_are_bound()
        {
            var form = new FormCollection()
            {
                { "Name", "test_name" }
            };

            var context = new ModelBindingContext() { ValueProvider = form.ToValueProvider(), ModelType = typeof(CodeCamp) };

            var mb = new DefaultModelBinder();
            var codeCamp = (CodeCamp) mb.BindModel(null, context);

            Assert.That(codeCamp.Name, Is.EqualTo("test_name"));
        }
    }
}
