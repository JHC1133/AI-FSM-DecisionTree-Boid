using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewUppgift1AI
{
    internal class InputManager
    {
        public struct MyMouseState
        {
            public static MouseState oldMouseState;
            public static MouseState mouseState;
        }

        public static void Update()
        {
            MyMouseState.oldMouseState = MyMouseState.mouseState;
            MyMouseState.mouseState = Mouse.GetState();
        }

        public static bool SingleLeftClick()
        {
            if (MyMouseState.mouseState.LeftButton == ButtonState.Pressed && MyMouseState.oldMouseState.LeftButton == ButtonState.Released)
            {
                return true;
            }
            return false;
        }

    }
}
