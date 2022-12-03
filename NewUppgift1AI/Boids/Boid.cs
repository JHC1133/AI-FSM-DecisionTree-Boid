using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewUppgift1AI
{
    internal class Boid
    {
        static Random random = new Random();
        Texture2D texture;

        private const int speed = 5;
        private const int turnSpeed = 30 / speed;

        public Vector2 position { get; private set; }
        public Vector2 cellPosition { get; private set; }

        public Vector2 velocity;
        public Vector2 acceleration;

        Flock flock;

        public Boid(int x, int y, Flock flock)
        {
            this.position = new Vector2(x, y);
            this.flock = flock;
            
            texture = TextureManager.fishTex;
            velocity = new Vector2(random.Next() * 2 - 1, random.Next() * 2 - 1);
            acceleration = new Vector2();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White, rotation: GetRotationRad(), origin: new Vector2(5, 5), 1f, SpriteEffects.None, 1);
           
        }

        public void Run()
        {
            velocity += acceleration;
            acceleration = Vector2.Zero;

            if (Math.Abs(velocity.Length()) > speed)
            {
                velocity.Normalize();
                velocity *= speed;
            }

            position += velocity;
            cellPosition = new Vector2(position.X / Game1.cellWidth, position.Y / Game1.cellHeight);

            Borders();
        }

        private void Borders()
        {
            if (position.X < 0 || position.X > Game1.WindowX ||
                position.Y < 0 || position.Y > Game1.WindowY)
                position = new Vector2(Game1.WindowX / 2, Game1.WindowY / 2);
        }


        public float GetRotationRad()
        {
            return (float)Math.Atan2(velocity.Y, velocity.X) + MathHelper.PiOver2;
        }

        public void Accelerate(Vector2 accel)
        {
            acceleration += accel / turnSpeed;
        }
    }
}
