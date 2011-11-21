using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CodeCampster.Models;

namespace CodeCampster.Tests.Models
{
    [TestFixture]
    public class InMemoryCodeCampRepositoryTests : ICodeCampRespositoryTests
    {
        public override void Setup()
        {
            camps = new InMemoryCodeCampRepository();

            base.Setup();
        }
    }
}
