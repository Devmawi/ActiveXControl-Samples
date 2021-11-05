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

namespace RegistrationFreeActiveXControl
{
    [ComVisible(true)]
    [Guid("667e9f57-67a4-4bd5-a64e-e4e067abf55d"), ClassInterface(ClassInterfaceType.None)]
    [ProgId("RegistrationFreeActiveXControl.MyRegistrationFreeControl")]
    [ComDefaultInterface(typeof(IRegistrationFreeControl))]
    public partial class MyRegistrationFreeControl: UserControl, IRegistrationFreeControl
    {
        public MyRegistrationFreeControl()
        {
            InitializeComponent();
        }

        public int ForegroundColor { get; set; }
        public int BackgroundColor { get; set; }
        public int ControlWidth { get; set; }
        public int ControlHeight { get; set; }
        public string Url { get; set; }
    }
}
