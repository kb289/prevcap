using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using PrevCap.Util;

namespace PrevCap.Model
{
    public class CustomGame : GameType
    {
        public override String DisplayName { get; protected set; }
        public override String Identifier { get; protected set; }
        public Size FixedSize { get => base.Size;  }
        public override Size Size
        {
            get
            {
                if (UseSize)
                {
                    return FixedSize;
                }
                else
                {
                    if (UseClientArea)
                        return WindowUtil.GetClientAreaSize(ProcessId);
                    else
                        return WindowUtil.GetWindowSize(ProcessId);
                }
            }
        }
        public override Point Base
        {
            get
            {
                if (UseSize)
                {
                    return base.Base;
                }
                else
                {
                    if (UseClientArea)
                        return WindowUtil.GetClientAreaPoint(ProcessId);
                    else
                        return WindowUtil.GetWindowPoint(ProcessId);
                }
            }
        }
        public bool UseSize { get; protected set; }
        public int ProcessId { get; protected set; }
        public bool UseClientArea { get; protected set;  }

        private static CustomGame _default = new CustomGame("カスタム", "custom", new Size(1920, 1280), new Point(),
            true, 0, true);
        public static CustomGame Default { get { return _default; } }

        public CustomGame(String displayName, String identifier, Size size, Point basePoint,
            bool useSize, int processId, bool useClientArea)
        {
            DisplayName = displayName;
            Identifier = identifier;
            base.Size = size;
            Base = basePoint;
            UseSize = useSize;
            ProcessId = processId;
            UseClientArea = useClientArea;
        }
    }
}
