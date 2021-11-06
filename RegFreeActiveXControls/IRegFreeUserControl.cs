using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RegFreeActiveXControls
{
    [ComVisible(true)]
    [Guid("10675027-46E8-496E-B611-9820D394EFCA")]
    public interface IRegFreeUserControl
    {
        [DispId(1)]
        string CustomStringProperty { get; set; }

        [DispId(2)]
        int CustomIntegerProperty { get; set; }

        [DispId(3)]
        bool CustomBooleanProperty { get; set; }

    }
}
