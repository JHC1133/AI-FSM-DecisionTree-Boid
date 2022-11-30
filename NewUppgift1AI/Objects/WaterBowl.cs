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
            position = new Vector2(Game1.WindowX - texture.Width, Game1.WindowY - texture.Height / 2);
        }

        public void Update(GameTime gameTime)
        {
            Hitbox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
