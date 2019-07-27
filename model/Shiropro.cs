using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PrevCap.model
{
    public class Shiropro : GameType
    {
        public override String DisplayName { get { return "城プロ"; } }
        public override String Identifier { get { return "shiropro"; } }
        public override Size Size { get { return new Size(1275, 720); } }
    }
}
