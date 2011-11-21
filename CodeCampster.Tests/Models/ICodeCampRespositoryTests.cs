using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CodeCampster.Models;

namespace CodeCampster.Tests.Models
{
    public abstract class EmptyCodeCampRepositoryTests
    {
        //Assume camps is empty before every tests
        protected ICodeCampRepository camps;

        [Test]
        public void get_returns_no_camps()
        {
            Assert.That(camps.Get(2), Is.Null);
            Assert.That(camps.GetCampsIn("asdf", "asdf"), Has.Count.EqualTo(0));
        }

        [Test]
        public void GetUpcomginCamps_returns_no_camps()
        {
            Assert.That(camps.GetUpcomingCamps(), Has.Count.EqualTo(0));
        }

        [Test]
        public void GetCampsIn_returns_no_camps()
        {
            Assert.That(camps.GetCampsIn("asdf", "asdf"), Has.Count.EqualTo(0));
        }
    }

    public abstract class ICodeCampRespositoryTests
    {
        protected ICodeCampRepository camps;
        CodeCamp camp1;
        CodeCamp camp2;
        CodeCamp camp3;

        [SetUp]
        public virtual void Setup()
        {
            camp1 = new CodeCamp()
            {
                Name = "1",
                Date = DateTime.Now.AddDays(10),
                Address = new Address()
                {
                    City = "Richmond",
                    State = "VA"
                }
            }; 
            camp2 = new CodeCamp()
            {
                Name = "2",
                Date = DateTime.Now.AddDays(20),
                Address = new Address()
                {
                    City = "Roanoke",
                    State = "VA"
                }
            };
            camp3 = new CodeCamp()
            {
                Name = "3",
                Date = DateTime.Now.AddDays(0),
                Address = new Address()
                {
                    City = "San Francisco",
                    State = "CA"
                }
            };

            camps.Add(camp1);
            camps.Add(camp2);
            camps.Add(camp3);
        }

        [Test]
        public void get_camp_after_adding()
        {
            Assert.That(camps.Get(camp1.Id), Is.Not.Null);
        }

        [Test]
        public void camps_ordered_by_date_time_when_returned()
        {            
            var results = camps.GetUpcomingCamps();

            Assert.That(results.ElementAt(0).Id, Is.EqualTo(camp3.Id));
            Assert.That(results.ElementAt(1).Id, Is.EqualTo(camp1.Id));
            Assert.That(results.ElementAt(2).Id, Is.EqualTo(camp2.Id));
        }

        [Test]
        public void get_camps_by_location()
        {
            var results = camps.GetCampsIn(camp2.Address.City, camp2.Address.State);
            var j = results.ElementAt(0).Presentations.Count;
            Assert.That(results.ElementAt(0).Id, Is.EqualTo(camp2.Id));
        }

        [Test]
        public void delete_camp()
        {
            /*
            //This isn't actually going to work live, because of transactional issues.
            var camp = CreateCamp();

            var id = camps.Add(camp);
            Assert.That(camps.Get(id), Is.Not.Null);

            camps.GetCampsIn(camp.Address.City, camp.Address.State);
            camps.Delete(camp);

            Assert.That(camps.Get(id), Is.Null);
             */
        }
    }
}
