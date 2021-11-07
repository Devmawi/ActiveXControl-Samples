using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RegFreeActiveXControls
{
    [Guid("A40908EC-2D17-45FF-B075-479B97FC1A05"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IRegFreeUserControlEventSource
    {
        [DispId(1)]
        void CustomClick(string customString, int customInteger, bool customBoolean);
    }
}
