using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SnippetManagerGuiAppWinForms
{
    public class ScintillaIntegration : NativeWindow
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr LoadLibrary(string libname);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern bool FreeLibrary(IntPtr hModule);
        private static IntPtr hModule = IntPtr.Zero;
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr CreateWindowEx(int dwExStyle, string lpClassName, string lpWindowName, int dwStyle, int x, int y, int nWidth, int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);
        public ScintillaIntegration(Control control)
        {
            // try to load only if it's not loaded already, whether by not attempting it at all or errors
            if (hModule == IntPtr.Zero)
            {
                hModule = LoadLibrary("SciLexer.dll");
            }
            if (hModule == IntPtr.Zero)
            {
                throw new Exception("Failed to load SciLexer.dll");
            }
            CreateWindowEx(0, "Scintilla", "", 0, 0, 0, 0, 0, control.Handle, IntPtr.Zero, hModule, IntPtr.Zero);
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
        }
    }
}
