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
using NHibernate;
using NHibernate.Criterion;

namespace CodeCampster.Models
{
    public class NHibernateCodeCampRepository : ICodeCampRepository
    {
        ISession session;

        public NHibernateCodeCampRepository(ISession _session)
        {
            session = _session;
        }

        #region ICodeCampRepository Members

        public int Add(CodeCamp camp)
        {
        }

        //Get by ID
        public CodeCamp Get(int id)
        {
            //Explain how get works (need to research load a little bit I imagine)
            return session.Get<CodeCamp>(id);
        }

        //Criteria Query
        public IEnumerable<CodeCamp> GetUpcomingCamps()
        {
        }


        //HQL Query
        public IEnumerable<CodeCamp> GetCampsIn(string city, string state)
        {
        }

        public void Update(CodeCamp camp)
        {
        }

        public void Delete(CodeCamp camp)
        {
        }

        #endregion
    }
}
