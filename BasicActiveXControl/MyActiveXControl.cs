using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyComControls
{
    [ComVisible(true)]
    [ProgId("MyComControls.MyActiveXControl")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [Guid("E66C39CB-BB8B-4738-AA0E-5E0D1F2DB230")]
    public partial class MyActiveXControl : UserControl
    {
        public MyActiveXControl()
        {
            InitializeComponent();
        }

        [ComRegisterFunction()]
        public static void RegisterClass(string key)
        {
            // Strip off HKEY_CLASSES_ROOT from the passed key as I don’t need it
            StringBuilder sb = new StringBuilder(key);
            sb.Replace(@"HKEY_CLASSES_ROOT", "");

            // Open the CLSID{guid} key for write access
            RegistryKey k = Registry.ClassesRoot.OpenSubKey(sb.ToString(), true);

            // And create the ‘Control’ key – this allows it to show up in
            // the ActiveX control container
            RegistryKey ctrl = k.CreateSubKey("Control");
            ctrl.Close();

            // Next create the CodeBase entry – needed if not string named and GACced.
            RegistryKey inprocServer32 = k.OpenSubKey("InprocServer32", true);
            inprocServer32.SetValue("CodeBase", Assembly.GetExecutingAssembly().CodeBase);
            inprocServer32.Close();

            // Finally close the main key
            k.Close();
        }

        [ComUnregisterFunction()]
        public static void UnregisterClass(string key)
        {
            StringBuilder sb = new StringBuilder(key);
            sb.Replace(@"HKEY_CLASSES_ROOT", "");

            // Open HKCRCLSID{guid} for write access
            RegistryKey k = Registry.ClassesRoot.OpenSubKey(sb.ToString(), true);

            // Delete the ‘Control’ key, but don’t throw an exception if it does not exist
            k.DeleteSubKey("Control", false);

            // Next open up InprocServer32
            RegistryKey inprocServer32 = k.OpenSubKey("InprocServer32", true);

            // And delete the CodeBase key, again not throwing if missing
            k.DeleteSubKey("CodeBase", false);

            // Finally close the main key
            k.Close();
        }

        [ComVisible(true)]
        public string LabelText { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = LabelText;
        }
    }
}
