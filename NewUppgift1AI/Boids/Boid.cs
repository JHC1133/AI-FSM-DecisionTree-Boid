﻿using Microsoft.Xna.Framework;
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

        private const int speed = 2;
        private const int turnSpeed = 15 / speed;

        public Vector2 position { get; private set; }
        public Vector2 cellPosition { get; private set; }

        public Vector2 velocity;
        public Vector2 acceleration;

        Flock flock;
        AqWater aqWater;

        public Boid(int x, int y, Flock flock, AqWater aqWater)
        {
            this.aqWater = aqWater;
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
            int randX = random.Next(130, 564);
            int randY = random.Next(130, 656);

            if (position.X < ((int)aqWater.Position.X) || position.X > aqWater.Texture.Width ||
                position.Y < ((int)aqWater.Position.Y) || position.Y > aqWater.Texture.Height)
            {
                Vector2 revesereVelocity = velocity *= -1;
                velocity = revesereVelocity;
                velocity.Normalize();

                //position = new Vector2(randX, randY);

            }
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
