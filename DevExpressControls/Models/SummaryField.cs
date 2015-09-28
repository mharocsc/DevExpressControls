using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevExpressControls.Models
{
    public class SummaryField
    {
        public int SummaryFieldID { get; set; }
        public string FieldLabel { get; set; }
        public string DataType { get; set; }
        public int Lenght { get; set; }
        
        public static class SummaryFieldsProvider
        {
            public static IList GetSummaryFields()
            {
                return new List<SummaryField>() {
                    new SummaryField() { SummaryFieldID = 1, FieldLabel = "BIDDER", DataType = "Text", Lenght = 20 },
                    new SummaryField { SummaryFieldID = 2, FieldLabel = "WBS", DataType = "Text", Lenght = 20 },
                    new SummaryField { SummaryFieldID = 3, FieldLabel = "CLIN", DataType = "Text", Lenght = 20},
                    new SummaryField { SummaryFieldID = 4, FieldLabel = "PHASE", DataType = "Text", Lenght = 20}
                };
            }
        }
    }
}