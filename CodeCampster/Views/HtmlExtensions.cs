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
using System.Web.Mvc.Html;

namespace CodeCampster.Views
{
    public static class HtmlExtensions
    {
        //public string 
        public static string MasterMenu(this HtmlHelper html, string title, string action, string controller)
        {
            if (controller.Equals(html.ViewContext.RouteData.Values["controller"] as string, StringComparison.OrdinalIgnoreCase) &&
                action.Equals(html.ViewContext.RouteData.Values["action"] as string, StringComparison.OrdinalIgnoreCase))
            {
                return "<li class='selected'>" + html.ActionLink(title, action, controller) + "</li>";
            }
            else
            {
                return "<li>" + html.ActionLink(title, action, controller) + "</li>";
            }
        }
    }
}
