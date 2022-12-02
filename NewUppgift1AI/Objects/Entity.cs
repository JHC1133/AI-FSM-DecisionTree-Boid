using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewUppgift1AI
{
    abstract class Entity
    {
        public FiniteStateMachine stateMachine;

        protected Texture2D texture;
        protected Vector2 direction, distance, position;
        protected float velocity;
        protected Rectangle hitbox;

        public Vector2 currentOrientation;
        public Vector2 oldOrientation;

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);


        public Vector2 RandomMovement()
        {
            Random random = new Random();

            int outcome;

            if (currentOrientation == Data.up || currentOrientation == Data.down)
            {
                outcome = random.Next(1, 3);

                switch (outcome)
                {
                    case 1:
                        return Data.left;
                    case 2:
                        return Data.right;

                }
            }
            else if (currentOrientation == Data.left || currentOrientation == Data.right)
            {
                outcome = random.Next(1, 3);

                switch (outcome)
                {
                    case 1:
                        return Data.up;
                    case 2:
                        return Data.down;

                }
            }

            //Start point
            return Data.up;

            //switch (outcome)
            //{
            //    case 1:
            //        return Data.up;
            //    case 2:
            //        return Data.down;
            //    case 3:
            //        return Data.left;
            //    case 4:
            //        return Data.right;
            //}

            //return Data.right;

        }

        /// <summary>
        /// Set velocity for Entity
        /// </summary>
        /// <param name="velocity"></param>
        public virtual void SetVelocity(float velocity)
        {
            this.velocity = velocity;
        }

        /// <summary>
        /// Get distance between v1 and v2
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public virtual float GetDistance(Vector2 v1, Vector2 v2)
        {
            float distance = Vector2.Distance(v1, v2);

            return distance;
        }

        /// <summary>
        /// Set general direction
        /// </summary>
        /// <param name="direction"></param>
        public virtual void SetDirection(Vector2 direction)
        {
            this.direction = direction;
            this.direction.Normalize();
            currentOrientation = direction;

        }

        /// <summary>
        /// Set direction towards another object
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="position"></param>
        public virtual void SetDirection(Vector2 direction, Vector2 position)
        {
            this.direction = direction - position;
            this.direction.Normalize();
            currentOrientation = direction;
        }

        /// <summary>
        /// Set direction away from object you want to evade
        /// </summary>
        /// <param name="evadeDirection"></param>
        /// <param name="position"></param>
        public virtual void SetEvadeDirection(Vector2 evadeDirection, Vector2 position)
        {
            //direction = evadeDirection;
            this.direction = position - evadeDirection;
            this.direction.Normalize();
            currentOrientation = direction;
        }

        public void ReverseDirection()
        {
            Vector2 reverseOrientation = currentOrientation *= -1;
            oldOrientation = currentOrientation;
            Debug.WriteLine(oldOrientation);
            SetDirection(reverseOrientation);
        }
    }
}
