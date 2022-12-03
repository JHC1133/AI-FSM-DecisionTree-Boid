using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewUppgift1AI
{
    internal class AqWater : NonMovingObject
    {
        public Texture2D Texture { get; private set; }

        public AqWater() 
        {
            Texture = TextureManager.aqWaterTex;
            position = new Vector2(153, 156); // aquarium X + 23, Y + 26
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, position, Color.White);
        }
    }
}
