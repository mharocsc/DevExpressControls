using System.Collections.Generic;

namespace DevExpressControls.Helpers
{
    public static class WidgetsHelper
    {
        public static List<string> GetMailFolders()
        {
            return new List<string>() { "Inbox(1)", "Outbox", "Sent Items", "Deleted Items", "Drafts" };
        }
        public static List<string> GetWidgets()
        {
            return new List<string>() {  "Mail", "Calendar", "Label" };
        }
    }
}