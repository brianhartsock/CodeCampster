using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Mvc;
using CodeCampster.Models;

namespace CodeCampster.Controllers
{
    public class PresentationController : Controller
    {
        ICodeCampRepository camps;

        public PresentationController()
            : this(new InMemoryCodeCampRepository(CodeCampController.CodeCamps))
            //: this(new NHibernateCodeCampRepository(MvcApplication.GetCurrentSession()))
        {
        }

        public PresentationController(ICodeCampRepository _camps)
        {
            camps = _camps;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Add(
            int campId, 
            [Bind(Prefix="presentation")] Presentation presentation)
        {
            var camp = camps.Get(campId);
            CheckCamp(camp);

            camp.Presentations.Add(presentation);

            return RedirectToCamp(camp);
        }

        public ActionResult Delete(int campId, int presentationId)
        {
            var camp = camps.Get(campId);
            CheckCamp(camp);

            var presentation = camp.Presentations
                .Where(p => p.Id == presentationId)
                .FirstOrDefault();
            CheckPresentation(presentation);

            camp.Presentations.Remove(presentation);

            return RedirectToCamp(camp);
        }

        private ActionResult RedirectToCamp(CodeCamp camp)
        {
            return RedirectToAction("Show", "CodeCamp", new { id = camp.Id });
        }

        private void CheckCamp(CodeCamp obj)
        {
            if (obj == null)
            {
                throw new HttpException(404, "Code Camp not found");
            }
        }

        private void CheckPresentation(Presentation obj)
        {
            if (obj == null)
            {
                throw new HttpException(404, "Presentation not found");
            }
        }
    }
}
