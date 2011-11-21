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
using System.Collections.Generic;

namespace CodeCampster.Models
{
    public interface ICodeCampRepository
    {
        int Add(CodeCamp camp);
        CodeCamp Get(int id);
        IEnumerable<CodeCamp> GetUpcomingCamps();
        IEnumerable<CodeCamp> GetCampsIn(string city, string state);
        void Delete(CodeCamp camp);
    }
}
