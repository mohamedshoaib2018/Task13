using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateSheets
{
    [Transaction(TransactionMode.Manual)]
    public class MainClass : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document doc = commandData.Application.ActiveUIDocument.Document;
                
            try
            {
                placeView00 placeView = new placeView00(doc);
                placeView.Show();

            }
            catch (Exception ex)
            {

                TaskDialog.Show("Warning", ex.Message );
            }
            return Result.Succeeded;
        }
    }
}
