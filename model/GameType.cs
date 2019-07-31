using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PrevCap.Model
{
    public abstract class GameType
    {
        public virtual String DisplayName { get; protected set; }
        public virtual String Identifier { get; protected set; }
        public virtual Size Size { get; protected set; }
        public virtual Point Base { get; set; }
    }
}
