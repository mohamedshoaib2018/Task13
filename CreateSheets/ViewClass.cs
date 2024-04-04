using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateSheets
{
    public class ViewClass
    {
        public View View { get; set; }
        public ElementId Id => View.Id;
        public string ViewName => View.Name;
        public bool IsChecked {  get; set; }

        public ViewClass(View view)
        {

            View= view;
            //ViewName= View.Name;
            IsChecked = false;
        }



    }
}
