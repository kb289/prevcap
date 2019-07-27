using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PrevCap.util
{
    public class OnceTimer
    {
        public OnceTimer(int interval, Action action)
        {
            Timer timer = new Timer();
            timer.Interval = interval;
            timer.Tick += (sender, e) =>
            {
                action();
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }
    }
}
