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
        public static Texture2D dogTex, robotTex, fishTex, peePuddleTex, woodenFloorTex, wallSideTex, wallTopBotTex, waterBowlEmptyTex, waterBowlFilledTex, aquariumTex, aqWaterTex;

        public static void LoadTex(ContentManager content)
        {
            dogTex = content.Load<Texture2D>("dogAlpha");
            robotTex = content.Load<Texture2D>("robotAlpha");
            peePuddleTex = content.Load<Texture2D>("peePuddleAlpha");
            woodenFloorTex = content.Load<Texture2D>("woodenFloor");
            wallSideTex = content.Load<Texture2D>("wallSide");
            wallTopBotTex = content.Load<Texture2D>("wallTopBot");
            waterBowlEmptyTex = content.Load<Texture2D>("waterBowlAlpha");
            waterBowlFilledTex = content.Load<Texture2D>("waterBowlFilledAlpha");
            fishTex = content.Load<Texture2D>("fishAlpha");
            aquariumTex = content.Load<Texture2D>("aquariumBase");
            aqWaterTex = content.Load<Texture2D>("aquariumWater");
        }
    }
}
