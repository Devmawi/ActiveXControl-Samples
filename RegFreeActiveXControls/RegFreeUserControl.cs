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

namespace RegFreeActiveXControls
{
    [ComVisible(true)]
    [Guid("00213331-FB5D-4936-8BDC-B49850FA4E6F"), ClassInterface(ClassInterfaceType.None)]
    public partial class RegFreeUserControl : UserControl, IRegFreeUserControl
    {
        // Initilizing for better intellisense in VBA Editor
        public string CustomStringProperty { get; set; } = String.Empty;
        public int CustomIntegerProperty { get; set; } = 0;
        public bool CustomBooleanProperty { get; set; } = false;

        public RegFreeUserControl()
        {
            InitializeComponent();
            iRegFreeUserControlBindingSource.DataSource = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = this.CustomStringProperty;
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        [ComRegisterFunction]
        private static void Register(Type t)
        {
            ComRegistration.RegisterControl(t);
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        [ComUnregisterFunction]
        private static void Unregister(Type t)
        {
            ComRegistration.UnregisterControl(t);
        }
    }
}
