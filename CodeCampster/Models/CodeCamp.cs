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
using Iesi.Collections.Generic;

namespace CodeCampster.Models
{
    public class CodeCamp
    {
        public CodeCamp()
        {
            Presentations = new HashedSet<Presentation>();
            Address = new Address();
        }

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual Address Address { get; set; }

        public virtual ISet<Presentation> Presentations { get; set; }
    }
}
