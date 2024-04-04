using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateSheets
{
    internal class ExternalPlace : IExternalEventHandler
    {
        public List<ViewClass> TargetViews {  get; set; }
        public void Execute(UIApplication app)
        {
            try
            {
                var doc = app.ActiveUIDocument.Document;
                using (Transaction trans = new Transaction(doc,"Create Sheets")) 
                {
                    trans.Start();
                    var titleBlock = new FilteredElementCollector(doc)
                        .OfCategory(BuiltInCategory.OST_TitleBlocks)
                        .WhereElementIsElementType()
                        .FirstOrDefault().Id;
                    int i = 500;
                    foreach(var ViewClass in TargetViews)
                    {
                        var Sheet = ViewSheet.Create(doc,titleBlock);
                        Sheet.Name = ViewClass.ViewName;
                        Sheet.SheetNumber = $"{i}";
                        i++;
                        var outline = Sheet.Outline;
                        XYZ ceterPoint = new XYZ((outline.Max.U + outline.Min.U) / 2, (outline.Max.V + outline.Min.V) / 2, 0);
                        var viewPort = Viewport.Create(doc,Sheet.Id,ViewClass.View.Id,ceterPoint);
                    }
                    trans.Commit();
                }
                
            }
            catch (Exception ex)
            {

                TaskDialog.Show("Warning", ex.Message);
            }
        }

        public string GetName() => "Place";
    }
}
