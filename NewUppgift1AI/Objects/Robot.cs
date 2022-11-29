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
        public ChaseState ChaseState { get; private set; }
        public CleanState CleanState { get; private set; }

        public Vector2 Position { get => position; set => position = value; }
        public Rectangle Hitbox { get => hitbox; set => hitbox = value; }
        public int DetectionRadius { get => detectionRadius; set => detectionRadius = value; }

        public List<Wall> walls;
        public List<Pee> peeList;

        int detectionRadius = 500;

        public Robot(FiniteStateMachine stateMachine, List<Wall> walls, List<Pee> peeList)
        {
            texture = TextureManager.robotTex;
            position = new Vector2(700, 500);

            this.walls = walls;
            this.peeList = peeList;
            this.stateMachine = stateMachine;

            MoveState = new MoveState(this, stateMachine);
            CollissionState = new CollissionState(this, stateMachine);
            ChaseState = new ChaseState(this, stateMachine);
            CleanState= new CleanState(this, stateMachine);

            stateMachine.Initialize(MoveState);
        }

        public override void Update(GameTime gameTime) 
        {
            position += direction * velocity;
            Hitbox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            RobotStateUpdate(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        private void RobotStateUpdate(GameTime gameTime)
        {
            if (stateMachine.currentState == MoveState)
            {
                MoveState.Update(gameTime);
            }
            else if (stateMachine.currentState == CollissionState)
            {
                CollissionState.Update(gameTime);
            }
            else if (stateMachine.currentState == ChaseState)
            {
                ChaseState.Update(gameTime);
            }
            else if (stateMachine.currentState == CleanState)
            {
                CleanState.Update(gameTime);
            }
        }
    }
}
