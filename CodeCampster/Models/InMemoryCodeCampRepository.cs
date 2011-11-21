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
    public class InMemoryCodeCampRepository : ICodeCampRepository
    {
        IList<CodeCamp> camps;

        public InMemoryCodeCampRepository(IList<CodeCamp> _camps)
        {
            camps = _camps;
        }

        public InMemoryCodeCampRepository()
            : this(new List<CodeCamp>())
        {
        }

        #region ICodeCampRepository Members

        public int Add(CodeCamp camp)
        {
            camp.Id = GenerateNewId();

            camps.Add(camp);

            return camp.Id;
        }

        public CodeCamp Get(int id)
        {
            return camps
                .Where(c => c.Id == id)
                .FirstOrDefault();
        }

        public IEnumerable<CodeCamp> GetUpcomingCamps()
        {
            return camps.
                    OrderBy(c => c.Date).
                    ToList();
        }

        public IEnumerable<CodeCamp> GetCampsIn(string city, string state)
        {
            return camps
                .Where(c => c.Address.City == city && c.Address.State == state)
                .ToList();
        }
        
        public void Delete(CodeCamp camp)
        {
            camps.Remove(camp);
        }

        #endregion

        private int GenerateNewId()
        {
            return new Random().Next(1000);
        }
    }
}
