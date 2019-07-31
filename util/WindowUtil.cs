using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace PrevCap.Util
{
    static class WindowUtil
    {
        public static Size GetClientAreaSize(int processId)
        {
            Size size = new Size(1, 1);
            Process process = Process.GetProcessById(processId);
            if (process == null)
                return size;
            var rect = new Win32Api.RECT();
            return Win32Api.GetClientRect(process.MainWindowHandle, out rect) ?
                new Size(rect.Right, rect.Bottom) : size;
        }

        public static Point GetClientAreaPoint(int processId)
        {
            Point point = new Point(0, 0);
            Process process = Process.GetProcessById(processId);
            if (process == null)
                return point;
            Win32Api.ClientToScreen(process.MainWindowHandle, ref point);
            return point;
        }

        public static Point GetWindowPoint(int processId)
        {
            Point point = new Point();
            Process process = Process.GetProcessById(processId);
            if (process == null)
                return point;
            var rect = new Win32Api.RECT();
            // Windows 10における1pxの枠を除去するため+1する
            return Win32Api.DwmGetWindowAttribute(process.MainWindowHandle, Win32Api.DWMWA_EXTENDED_FRAME_BOUNDS, out rect, 16) == 0 ?
                new Point(rect.Left + 1, rect.Top + 1) : point;
        }

        public static Size GetWindowSize(int processId)
        {
            Size size = new Size();
            Process process = Process.GetProcessById(processId);
            if (process == null)
                return size;
            var rect = new Win32Api.RECT();
            // Windows 10における1pxの枠を除去するため-2する
            return Win32Api.DwmGetWindowAttribute(process.MainWindowHandle, Win32Api.DWMWA_EXTENDED_FRAME_BOUNDS, out rect, 16) == 0 ?
                new Size(rect.Right - rect.Left - 2, rect.Bottom - rect.Top - 2) : size;
        }
    }
}
