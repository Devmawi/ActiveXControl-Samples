using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistrationFreeActiveXControl
{
    [Guid("9646121f-4c85-4bb9-b50b-7f2bdb5b2f2b"), ClassInterface(ClassInterfaceType.None)]
    public partial class MyUserControl1 : UserControl
    {
        public MyUserControl1()
        {
            InitializeComponent();
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        [ComRegisterFunction]
        public static void Register(Type t)
        {
            ComRegistration.RegisterControl(t);
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        [ComUnregisterFunction]
        public static void Unregister(Type t)
        {
            ComRegistration.UnregisterControl(t);
        }
    }
}
