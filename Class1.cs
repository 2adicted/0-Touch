using Autodesk.DesignScript.Runtime;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Collections;
using System.Collections.Generic;
using Proto = Revit.Elements;

namespace DynamoNodes
{
    public class ImportedInstance
    {
        internal ImportedInstance()
        {

        }
        public static List<bool> IsLinked([DefaultArgument("{}")] IList elements)
        {        
            List<bool> value = new List<bool>();

            foreach(var ins in elements)
            {
                var ce = (Proto.Element) ins;
                Element element = ce.InternalElement;
                ImportInstance instance = element as ImportInstance;
                
                if (instance == null)
                {
                    TaskDialog.Show("Error", "Expecting Impored Instance");
                    return value;
                }
                else
                {
                    value.Add(instance.IsLinked);
                }
            }

            return value;
        }
    }
}
