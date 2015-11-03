using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
using DevExpress.Web.Mvc;
using DevExpress.XtraCharts;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;

namespace DevExpressControls.Helpers
{
    public static class DocVariableDemoHelper
    {
        public static double GetHours(string resourceName)
        {
            //Do the necessary search of Hours according to resourceName DB, XML, etc.
            return 8;
        }

        public static double GetCost(string resourceName)
        {
            //Do the necessary search of Hours according to resourceName DB, XML, etc.
            return 55.5;
        }

        public static string GetResHrsText(string resourceName)
        {
            //Do the necessary search to get the information that you need according to resourceName DB, XML, etc.
            var hours = GetHours(resourceName);
            var days = 5;
            string dayss = days == 1 ? " day" : " days";
            string hourss = hours == 1 ? " hour" : " hours";
            return resourceName + " will work " + days + dayss + ", " + hours + hourss + ".";
        }

        public static string GetResCostText(string resourceName)
        {
            //Do the necessary search to get the information that you need according to resourceName DB, XML, etc.
            var cost = GetCost(resourceName);
            var days = 5;
            string dayss = days == 1 ? " day" : " days";
            return resourceName + " have a cost of production of " + (days * cost) + ", per " + days + "" +  dayss + ".";
        }

    }
}
