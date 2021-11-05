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

namespace RegistrationFreeActiveXControl
{
    [ComVisible(true)]
    [Guid("8944362e-e31f-4d9c-8ad5-7cd7eb4aa4a5"), ClassInterface(ClassInterfaceType.None)]
    [ComDefaultInterface(typeof(IRegistrationFreeControl1))]
    public partial class MyRegistrationFreeControl1: UserControl, IRegistrationFreeControl1
    {
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

        const int OLEMISC_RECOMPOSEONRESIZE = 1;
        const int OLEMISC_CANTLINKINSIDE = 16;
        const int OLEMISC_INSIDEOUT = 128;
        const int OLEMISC_ACTIVATEWHENVISIBLE = 256;
        const int OLEMISC_SETCLIENTSITEFIRST = 131072;

        // These routines perform the additional COM registration needed by ActiveX controls
        [EditorBrowsable(EditorBrowsableState.Always)]
        [ComRegisterFunction]
        private static void Register(Type t)
        {
            try
            {
                // GuardNullType(t, "t");
                // GuardTypeIsControl(t);

                // CLSID
                string key = @"CLSID\" + t.GUID.ToString("B");

                using (RegistryKey subkey = Registry.ClassesRoot.OpenSubKey(key, true))
                {

                    // InProcServer32
                    RegistryKey inprocKey = subkey.OpenSubKey("InprocServer32", true);
                    if (inprocKey != null)
                    {
                        inprocKey.SetValue(null, Environment.SystemDirectory + @"\mscoree.dll");
                    }

                    //Control
                    using (subkey.CreateSubKey("Control"))
                    { }

                    // Misc
                    using (RegistryKey miscKey = subkey.CreateSubKey("MiscStatus"))
                    {
                        const int MiscStatusValue = OLEMISC_RECOMPOSEONRESIZE +
                                                    OLEMISC_CANTLINKINSIDE + OLEMISC_INSIDEOUT +
                                                    OLEMISC_ACTIVATEWHENVISIBLE + OLEMISC_SETCLIENTSITEFIRST;

                        miscKey.SetValue("", MiscStatusValue.ToString(), RegistryValueKind.String);
                    }

                    // ToolBoxBitmap32
                    //using (RegistryKey bitmapKey = subkey.CreateSubKey("ToolBoxBitmap32"))
                    //{
                    //    // If you want to have different icons for each control in this assembly
                    //    // you can modify this section to specify a different icon each time.
                    //    // Each specified icon must be embedded as a win32resource in the
                    //    // assembly; the default one is at index 101, but you can add additional ones.
                    //    bitmapKey.SetValue("", Assembly.GetExecutingAssembly().Location + ", 101",
                    //                       RegistryValueKind.String);
                    //}

                    // TypeLib
                    using (RegistryKey typeLibKey = subkey.CreateSubKey("TypeLib"))
                    {
                        Guid libId = Marshal.GetTypeLibGuidForAssembly(t.Assembly);
                        typeLibKey.SetValue("", libId.ToString("B"), RegistryValueKind.String);
                    }

                    // Version
                    using (RegistryKey versionKey = subkey.CreateSubKey("Version"))
                    {
                        int major, minor;
                        Marshal.GetTypeLibVersionForAssembly(t.Assembly, out major, out minor);
                        versionKey.SetValue("", String.Format("{0}.{1}", major, minor));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        [ComUnregisterFunction]
        private static void Unregister(Type t)
        {
            try
            {
                // GuardNullType(t, "t");
                // GuardTypeIsControl(t);

                // CLSID
                string key = @"CLSID\" + t.GUID.ToString("B");
                Registry.ClassesRoot.DeleteSubKeyTree(key);
            }
            catch (Exception ex)
            {
                throw ex;
                //LogAndRethrowException("ComUnregisterFunction failed.", t, ex);
            }
        }

        
    }
}
