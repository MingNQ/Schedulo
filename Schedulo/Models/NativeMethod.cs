using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Schedulo.Models
{
    internal static class NativeMethod
    {
        [DllImport("user32.dll")]
        public static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll"), ]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
    }
}
