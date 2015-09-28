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
            public static IList GetResources()
            {
                return new List<Resource>() {
                    new Resource() { ResourceID = 1, ResourceName = "ENG01", ResourceDescription = "Sr. Engineer", ResourceType = "Labor" },
                    new Resource { ResourceID = 1, ResourceName = "ENG02", ResourceDescription = "Jr. Engineer", ResourceType = "Labor" },
                    new Resource { ResourceID = 1, ResourceName = "ENG03", ResourceDescription = "Intern Engineer", ResourceType = "Labor"}
                };
            }
        }
    }
}