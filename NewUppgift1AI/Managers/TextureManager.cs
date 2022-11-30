using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewUppgift1AI
{
    internal class TextureManager
    {
        public static Texture2D dogTex, robotTex, peePuddleTex, woodenFloorTex, wallSideTex, wallTopBotTex, waterBowlEmptyTex, waterBowlFilledTex;

        public static void LoadTex(ContentManager content)
        {
            dogTex = content.Load<Texture2D>("322868_1100-800x825");
            robotTex = content.Load<Texture2D>("download");
            peePuddleTex = content.Load<Texture2D>("peePuddle");
            woodenFloorTex = content.Load<Texture2D>("woodenFloor");
            wallSideTex = content.Load<Texture2D>("wallSide");
            wallTopBotTex = content.Load<Texture2D>("wallTopBot");
            waterBowlEmptyTex = content.Load<Texture2D>("waterBowl");
            waterBowlFilledTex = content.Load<Texture2D>("waterBowlFilled");
        }
    }
}
