using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CodeCampster.Models;

namespace CodeCampster.Tests.Models.CodeCampTests
{
    [TestFixture]
    public class AddPresentationTests
    {
        CodeCamp camp;
        Presentation presentation;

        [SetUp]
        public void Setup()
        {
            camp = new CodeCamp();
            presentation = new Presentation()
            {
                Name = "Brian Hartsock",
                Abstract = "Intro to NHibernate, enough said",
                Level = AudienceLevel.L100
            };

            camp.Presentations.Add(presentation);
        }


        [Test]
        public void Presentation_has_id()
        {
            Assert.That(presentation.Id, Is.Not.EqualTo(0));
        }

        [Test]
        public void Presentation_is_in_enumeration()
        {
            Assert.That(camp.Presentations, Has.Member(presentation));
        }

        [Test]
        public void Presentation_can_be_removed()
        {
            camp.Presentations.Remove(presentation);
        }
    }
}
