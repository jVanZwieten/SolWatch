using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolWatch
{
    internal static class InputManager
    {
        static int lastScroll = Mouse.GetState().ScrollWheelValue;

        public static int ScrollDelta
        {
            get
            {
                var scrollState = Mouse.GetState().ScrollWheelValue;
                var delta = scrollState - lastScroll;
                lastScroll = scrollState;
                return delta;
            }
        }
    }
}
