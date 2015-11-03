using System;
using System.Collections;
using System.Collections.Generic;

namespace DevExpressControls.Models
{
    public class Variable
    {
        public int VariableID { get; set; }
        public string VariableName { get; set; }
        public string VariableType { get; set; }


        public static class VariableProvider
        {
            private static List<Variable> VarList;

            public static IList GetVariables()
            {
                if (VarList == null)
                    VarList = InitVariables();
                return VarList;
            }

            private static List<Variable> InitVariables()
            {
                return new List<Variable>() {
                        new Variable() { VariableID = 1, VariableName = "HOURS", VariableType = "Labor" },
                        new Variable { VariableID = 2, VariableName = "HOURSTEXT", VariableType = "Labor" },
                        new Variable { VariableID = 3, VariableName = "COST", VariableType = "Material"},
                        new Variable { VariableID = 4, VariableName = "COSTTEXT", VariableType = "Material"}
                };
            }

            public static List<Variable> VarFilter(string varType)
            {
                return VarList.FindAll(x => x.VariableType == varType);
            }

            public static IList GetOptions(string resName)
            {
                if (VarList == null)
                    VarList = InitVariables();

                var options = new List<Variable>();
                var resource = Resource.ResourcesProvider.FindRes(resName);
                if (resource != null)
                    options = VarFilter(resource.ResourceType);

                return options;
            }
        }
    }
}