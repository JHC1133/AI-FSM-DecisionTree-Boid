using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewUppgift1AI
{
    abstract class Entity
    {
        protected Texture2D texture;
        protected Vector2 direction, distance, position;
        protected float velocity;
        protected Rectangle hitbox;

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);


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

        }

        /// <summary>
        /// Set direction towards another object
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="position"></param>
        public virtual void SetDirection(Vector2 targetDirection, Vector2 position)
        {
            direction = targetDirection;
            this.direction.Normalize();
        }

        /// <summary>
        /// Set direction away from object you want to evade
        /// </summary>
        /// <param name="evadeDirection"></param>
        /// <param name="position"></param>
        public virtual void SetEvadeDirection(Vector2 evadeDirection, Vector2 position)
        {
            direction = evadeDirection;
            this.direction.Normalize();
        }
    }
}
