using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewUppgift1AI
{
    internal class WaterBowl : NonMovingObject
    {


        public WaterBowl() 
        {
            texture = TextureManager.waterBowlFilledTex;
        }

        public void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
