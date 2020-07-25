using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace AQWConnect
{
    /// <summary>
    /// Provides a console for debug / logging purposes
    /// </summary>
    class Console
    {
        [DllImport("kernel32.dll", EntryPoint = "GetStdHandle", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll", EntryPoint = "AllocConsole", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int AllocConsole();

        [DllImport("kernel32.dll")]
        public static extern bool FreeConsole();

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
        static IntPtr handle;

        /// <summary>
        /// Initializes the console and hides it
        /// </summary>
        public static void Initialize()
        {
            AllocConsole();
            System.Console.WriteLine("Console Attached");
            handle = GetConsoleWindow();
            ShowConsole(false);
        }
      
        /// <summary>
        /// Shows or hides the console window
        /// </summary>
        /// <param name="Staus"></param>
        public static void ShowConsole(bool Staus = true)
        {
            ShowWindow(handle, Staus ? SW_SHOW : SW_HIDE);
        }

        public static void Write(string message)
        {
#if DEBUG
            Debug.Write(message);
#endif
            System.Console.Write(message);
        }
        public static void WriteLine(string message)
        {
#if DEBUG
            Debug.WriteLine(message);
#endif
            System.Console.WriteLine(message);
        }
    }
}
