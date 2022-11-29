using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewUppgift1AI
{
    abstract class NonMovingObject
    {
        protected Texture2D texture;
        public Vector2 position;
        protected Rectangle hitbox;

        public Rectangle Hitbox { get => hitbox; set => hitbox = value; }

        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
