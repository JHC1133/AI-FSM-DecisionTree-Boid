using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewUppgift1AI
{
    public static class Data
    {
        /// <summary>
        /// Orientation
        /// </summary>
        public static Vector2 up = new Vector2(0, -1);
        public static Vector2 down = new Vector2(0, 1);
        public static Vector2 right = new Vector2(1, 0);
        public static Vector2 left = new Vector2(-1, 0);

        /// <summary>
        /// Movement
        /// </summary>
        public static float robotDefaultVel = 5.5f;
        public static float robotFleeModeVel = 7f;

        public static float dogDefaultVel = 3.5f;
        public static float dogDrinkModeVel = 4.5f;
        public static float dogRageModeVel = 6f;

        public static float zero = 0f;
    }
}
