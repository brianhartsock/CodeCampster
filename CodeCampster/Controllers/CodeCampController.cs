using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using CodeCampster.Models;

namespace CodeCampster.Controllers
{
    public class CodeCampController : Controller
    {
        ICodeCampRepository camps;

        public CodeCampController()
        {
            //Poor man's dependency injection.  Keeping the project simple.
            camps = new InMemoryCodeCampRepository(CodeCamps);
            //camps = new NHibernateCodeCampRepository(MvcApplication.GetCurrentSession());
        }

        public ActionResult Index()
        {
            return View(
                camps.GetUpcomingCamps());
        }

        public ActionResult Show(int id)
        {
            var camp = camps.Get(id);
            CheckCamp(camp);

            var audienceLevels = from AudienceLevel a in Enum.GetValues(typeof(AudienceLevel))
                           select new { id = a, name = a.ToString() };
            ViewData["presentation.AudienceLevels"] = new SelectList(audienceLevels, "id", "name", AudienceLevel.L100);

            return View(camp);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Add()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Add(CodeCamp camp)
        {
            camps.Add(camp);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var camp = camps.Get(id);
            CheckCamp(camp);

            camps.Delete(camp);

            return RedirectToAction("Index");
        }

        private void CheckCamp(CodeCamp camp)
        {
            if (camp == null)
            {
                throw new HttpException(404, "Camp not found");
            }
        }

        public static IList<CodeCamp> CodeCamps;
        static CodeCampController()
        {
            CodeCamps = new List<CodeCamp>()
            {
                new CodeCamp()
                {
                    Id = 1,
                    Date = new DateTime(2009,10,3),
                    Name = "Richmond CC 2009.2",
                    Address = new Address()
                    {
                        City = "Richmond",
                        State = "VA"
                    },
                },
                new CodeCamp()
                {
                    Id = 2,
                    Date = new DateTime(2009,5,3),
                    Name = "Roanoke CC 2009",
                    Address = new Address()
                    {
                        City = "Roanoke",
                        State = "VA"
                    }
                }
            };
        }
    }
}
