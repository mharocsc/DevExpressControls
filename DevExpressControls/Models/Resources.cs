using System.Collections;
using System.Collections.Generic;

namespace DevExpressControls.Models
{
    public class Resource
    {
        public int ResourceID { get; set; }
        public string ResourceName { get; set; }
        public string ResourceDescription { get; set; }
        public string ResourceType { get; set; }
        
        public static class ResourcesProvider
        {
            private static List<Resource> ResList;

            public static IList GetResources()
            {
                if (ResList == null) {
                    ResList = new List<Resource>() {
                        new Resource() { ResourceID = 1, ResourceName = "ENG01", ResourceDescription = "Sr. Engineer", ResourceType = "Labor" },
                        new Resource { ResourceID = 1, ResourceName = "ENG02", ResourceDescription = "Jr. Engineer", ResourceType = "Labor" },
                        new Resource { ResourceID = 1, ResourceName = "MATL1", ResourceDescription = "Intern Engineer", ResourceType = "Material"}
                    };
                }             
                return ResList;
            }

            public static Resource FindRes(string resName)
            {
                return ResList.Find(x => x.ResourceName == resName);
            }

            public static IList GetOptions(string resName)
            {
                List<string> options = new List<string>();
                var resource = FindRes(resName);
                if (resource != null) {
                    if (resource.ResourceType == "Labor") {
                        options.Add("HOURS");
                        options.Add("HOURSTEXT");
                    }
                    else { 
                        options.Add("COST");
                    }
                }      
                return options;
            }
        }
    }
}