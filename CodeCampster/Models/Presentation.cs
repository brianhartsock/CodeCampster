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

namespace CodeCampster.Models
{
    public class Presentation
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Abstract { get; set; }
        public virtual AudienceLevel Level { get; set; }
    }
}
