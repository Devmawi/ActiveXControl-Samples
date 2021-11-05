using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Reflection;

namespace RegistrationFreeActiveXControl
{
    [ComVisible(true)]
    [Guid("dcc52b9f-62da-48d8-b10e-448808b8319d"), ClassInterface(ClassInterfaceType.None)]
    public partial class MyRegistrationFreeControl1: UserControl, IRegistrationFreeControl1
    {
        public const string ClassId = "dcc52b9f-62da-48d8-b10e-448808b8319d";
        public const string InterfaceId = "9592ed19-cc55-4a43-9f9d-c3f67f8943fd";
        public const string EventsId = "ee34715d-3911-473f-b4fd-229b3a46f7b9";
        public MyRegistrationFreeControl1()
        {
            InitializeComponent();
        }

        public int ForegroundColor { get; set; }
        public int BackgroundColor { get; set; }
        public int ControlWidth { get; set; }
        public int ControlHeight { get; set; }

        public bool Init()
        {
            return true;
        }

        public bool New()
        {
            return true;
        }

        public bool Change()
        {
            return true;
        }
   
        public string Url2 { get; set; }
        public int SelectedVersion { get; }

        //[EditorBrowsable(EditorBrowsableState.Always)]
        [ComRegisterFunction]
        private static void Register(Type t)
        {
            ComRegistration.RegisterControl(t);
        }

       // [EditorBrowsable(EditorBrowsableState.Always)]
        [ComUnregisterFunction]
        private static void Unregister(Type t)
        {
            ComRegistration.UnregisterControl(t);
        }




    }
}
