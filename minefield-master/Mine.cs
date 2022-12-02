using System;
using System.Collections.Generic;
using System.Text;

namespace Minefield_Online
{
    public class Mine : System.Windows.Forms.Button
    {
        public ushort x, y;
        public bool bomb = false;
        public bool open = false;
        public bool flag = false;
        public ushort count { get; set; }

        public Mine(ushort _x, ushort _y)
        {
            count = 0;
            open = false;
            flag = false;
            x = _x;
            y = _y;
        }

        public Mine() {
            count = 0;
            open = false;
            flag = false;
            x = 0;
            y = 0;
        }
    }
}
