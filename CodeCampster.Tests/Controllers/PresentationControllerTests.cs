using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CodeCampster.Controllers;
using CodeCampster.Models;
using Moq;
using System.Web.Mvc;
using System.Web.Routing;

namespace CodeCampster.Tests.Controllers
{
    [TestFixture]
    public class PresentationControllerTests
    {
        [Test]
        public void add_presentation()
        {
            var camp = new CodeCamp();

            var repo = new Mock<ICodeCampRepository>();
            repo.Setup(r => r.Get(1))
                .Returns(camp);
            var controller = new PresentationController(repo.Object);


            var presentation = new Presentation()
            {
                Name = "NHibernate",
                Abstract = "Really awesome",
                Level = AudienceLevel.L100
            };

            //Assert result?

            controller.Add(1, presentation);

            Assert.That(camp.Presentations, Has.Member(presentation));
            
        }
    }
}
