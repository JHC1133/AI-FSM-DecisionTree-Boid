using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NewUppgift1AI
{
    internal class WaterBowl : NonMovingObject
    {
        int timerDefault = 3000; //3 seconds
        int waterBowlTimer;

        bool waterAvailable;

        public WaterBowl() 
        {
            texture = TextureManager.waterBowlFilledTex;
            position = new Vector2(Game1.WindowX - texture.Width * 2, Game1.WindowY / 2 - texture.Height / 2);

            waterBowlTimer = timerDefault;
            waterAvailable = true;
        }

        public void Update(GameTime gameTime)
        {
            Hitbox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            waterBowlTimer -= (int)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (waterBowlTimer <= 0)
            {
                waterAvailable = false;
            }

            WaterTextureChanger();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        private void WaterTextureChanger()
        {
            if (waterAvailable)
            {
                texture = TextureManager.waterBowlFilledTex;
            }
            else
            {
                texture = TextureManager.waterBowlEmptyTex;
            }
        }
    }
}
