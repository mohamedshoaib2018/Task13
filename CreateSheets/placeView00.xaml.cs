using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CreateSheets
{
    /// <summary>
    /// Interaction logic for placeView00.xaml
    /// </summary>
    public partial class placeView00 : Window
    {
        ExternalPlace externalPlace = new ExternalPlace();
        ExternalEvent Explace;
        public placeView00( Document document)
        {
            InitializeComponent();
            try
            {

                var floorPlans = new FilteredElementCollector(document)
                    .OfClass(typeof(ViewPlan)).Cast<ViewPlan>()
                    .Where(x => x.ViewType == ViewType.FloorPlan && !x.IsTemplate)
                .Select(x => new ViewClass(x)).ToList();

                ViewsGrid.ItemsSource = floorPlans;
                Explace = ExternalEvent.Create(externalPlace);
            }
            catch (Exception ex)
            {

                TaskDialog.Show("Warning", ex.Message);
            }
        }

        private void Apply_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<ViewClass> newViews = new List<ViewClass>();
                foreach (var item in ViewsGrid.Items)
                {
                    if (item is ViewClass) 
                    {
                        var tView = item as ViewClass;
                        if (tView.IsChecked) { newViews.Add(tView); }
                    }
                }
                externalPlace.TargetViews = newViews;


                Explace.Raise();

            }
            catch (Exception ex)
            {
                TaskDialog.Show("Warning",ex.Message);
                
            }
        }
    }
}
