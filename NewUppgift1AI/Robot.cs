using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewUppgift1AI
{
    internal class Robot : Entity
    {
        public MoveState MoveState { get; private set; }
        public CollissionState CollissionState { get; private set; }

        public Robot(FiniteStateMachine stateMachine)
        {
            texture = TextureManager.robotTex;
            position = new Vector2(700, 500);

            MoveState = new MoveState(this, stateMachine);
            CollissionState = new CollissionState(this, stateMachine);

            stateMachine.Initialize(MoveState);
        }

        public override void Update(GameTime gameTime) 
        {
            position += direction * velocity;
            hitbox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
