using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PrevCap
{
    public abstract class GameType
    {
        public virtual String DisplayName { get; }
        public virtual String Identifier { get; }
        public virtual Size Size { get; }
        public Point Base { get; set; }
    }
}
