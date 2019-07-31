using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PrevCap.Model
{
    public class Kancolle : GameType
    {
        public override String DisplayName { get { return "艦これ"; } }
        public override String Identifier { get { return "kancolle"; } }
        public override Size Size { get { return new Size(1200, 720); } }
    }
}
