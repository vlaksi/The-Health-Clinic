using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SekretarWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjU1NDM0QDMxMzgyZTMxMmUzMGU0MFhCUFZob2ZIdytJckNkVFBHTDN3RHRTYUUrc0kvUER2VWs1VWhtSFk9");
        }

    }
}
