using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using WinRT.Interop;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.UI.WindowsAndMessaging;
using Windows.Win32.UI.Shell;

namespace NotepadClone.Controls
{
    // Why Microsoft??

    /// <summary>
    /// A class that adds the functions that are missing in Microsoft.UI.Xaml.Window
    /// </summary>
    public class WindowEx : Window
    {
        // Reference / 参考元: https://github.com/marb2000/DesktopWindow/ , https://github.com/shinta0806/TestWindowSubclass

        public static IntPtr Handle { get; private set; }
        private readonly SUBCLASSPROC _subclassProc;

        public WindowEx()
        {
            Handle = WindowNative.GetWindowHandle(this);
            if (Handle == IntPtr.Zero) throw new NullReferenceException("The Window handle is null.");

            _subclassProc = new SUBCLASSPROC(CustomSubClassProc);
            PInvoke.SetWindowSubclass((HWND)Handle, _subclassProc, UIntPtr.Zero, UIntPtr.Zero);
        }
        
        private LRESULT CustomSubClassProc(HWND hWnd, uint Msg, WPARAM wParam, LPARAM lParam, nuint uIdSubclass, nuint dwRefData)
        {
            switch (Msg)
            {
                case 16: // WM_CLOSE
                    if (this.Closing is not null)
                    {
                        if (IsClosing == false)
                            OnClosing();
                        return (LRESULT)IntPtr.Zero;
                    }
                    break;
                default: break;
            }

            // 引っかからなかったら元を呼ぶ
            return PInvoke.DefSubclassProc(hWnd, Msg, wParam, lParam);
        }

        public bool IsClosing { get; set; }
        public event EventHandler<WindowClosingEventArgs> Closing;
        private void OnClosing()
        {
            WindowClosingEventArgs windowClosingEventArgs = new(this);
            Closing.Invoke(this, windowClosingEventArgs);
        }
    }

    public class WindowClosingEventArgs : EventArgs
    {
        public WindowEx Window { get; private set; }
        public WindowClosingEventArgs(WindowEx window)
        {
            Window = window;
        }

        public void TryCancel()
        {
            Window.IsClosing = true;
            Window.Close();
        }
    }
}
