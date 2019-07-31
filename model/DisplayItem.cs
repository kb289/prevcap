using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PrevCap.Model
{
    public class DisplayItem
    {
        public Screen Screen { get; set; }
        public override string ToString()
        {
            return Screen.DeviceName.Replace(@"\\.\", "") + (Screen.Primary ? "(Primary)" : "");
        }
    }
}
