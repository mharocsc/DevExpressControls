using System;
using System.Configuration;

namespace DevExpressControls.Helpers
{
    public static class Utils
    {
        static bool? _isSiteMode;
        public static bool IsSiteMode
        {
            get
            {
                if (!_isSiteMode.HasValue)
                {
                    //_isSiteMode = ConfigurationManager.AppSettings["SiteMode"].Equals("true", StringComparison.InvariantCultureIgnoreCase);
                    _isSiteMode = true;
                }
                return _isSiteMode.Value;
            }
        }
    }
}