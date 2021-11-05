using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationFreeActiveXControl
{
    [ComVisible(true)]
    [Guid("9592ed19-cc55-4a43-9f9d-c3f67f8943fd")]
    public interface IRegistrationFreeControl1
    {
        /// <summary>
        /// Gets or sets a value indicating whether the user control is visible.
        /// </summary>
        [DispId(1)]
        bool Visible { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user control is enabled.
        /// </summary>
        [DispId(2)]
        bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the foreground color of the user control.
        /// </summary>
        [DispId(3)]
        int ForegroundColor { get; set; }

        /// <summary>
        /// Gets or sets the background color of the user control.
        /// </summary>
        [DispId(4)]
        int BackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the background image of the user control.
        /// </summary>
        [DispId(5)]
        Image BackgroundImage { get; set; }

        /// <summary>
        /// Forces the control to invalidate its client area and immediately redraw 
        /// itself and any child controls.
        /// </summary>
        [DispId(6)]
        void Refresh();

        // add additional properties and methods visible in VB6

        [DispId(7)]
        int ControlWidth { get; set; }

        [DispId(8)]
        int ControlHeight { get; set; }

        [DispId(9)]
        bool Init();

        [DispId(10)]
        bool New();

        [DispId(11)]
        bool Change();

        [DispId(12)]
        string Url2 { get; set; }

        [DispId(13)]
        int SelectedVersion { get; }
    }
}
