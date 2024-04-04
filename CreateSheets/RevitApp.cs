using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CreateSheets
{
    internal class RevitApp : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            //01-Create Tab
            string tabName = "Kayan";
            application.CreateRibbonTab(tabName);
            //02-Create Panel
            string panelName = "Trainig Plugins";
            RibbonPanel myPanel = application.CreateRibbonPanel(tabName,panelName);
            //03-Create Push Button Data
            string internalName = "View Button";
            string text_externalName = "View Button";
            string assemplyName = Assembly.GetExecutingAssembly().Location;
            PushButtonData buttonData = new PushButtonData(internalName, text_externalName, assemplyName,"CreateSheets.MainClass");
            //04-Create Push Button 
            PushButton buttton = myPanel.AddItem(buttonData) as PushButton;
            //05- Customization - add Image
            Uri myUri = new Uri("pack://application:,,,/CreateSheets;component/Image/01-35x35.png");
            BitmapImage myImage = new BitmapImage(myUri);
            buttton.LargeImage = myImage;
            return Result.Succeeded;
        }
    }
}
