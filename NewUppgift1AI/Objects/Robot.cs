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
        //public MoveState MoveState { get; private set; }
        //public CollissionState CollissionState { get; private set; }
        //public ChaseState ChaseState { get; private set; }
        //public CleanState CleanState { get; private set; }
        //public FleeState FleeState { get; private set; }

        public Vector2 Position { get => position; set => position = value; }
        public Rectangle Hitbox { get => hitbox; set => hitbox = value; }
        public int DetectionRadius { get => detectionRadius; set => detectionRadius = value; }

        public List<Wall> walls;
        public List<Pee> peeList;
        public ObjectManager objectManager;
        public Dog dog;

        int detectionRadius = 500;

        public Robot(FiniteStateMachine stateMachine, ObjectManager objectManager)
        {
            texture = TextureManager.robotTex;
            position = new Vector2(700, 500);

            this.walls = walls;
            this.peeList = peeList;
            this.stateMachine = stateMachine;
            this.objectManager = objectManager;
            this.dog = dog;

            //MoveState = new MoveState(this, objectManager, stateMachine);
            //CollissionState = new CollissionState(this, objectManager, stateMachine);
            //ChaseState = new ChaseState(this, objectManager, stateMachine);
            //CleanState = new CleanState(this, objectManager, stateMachine);
            //FleeState = new FleeState(this, objectManager, stateMachine);

            //stateMachine.Initialize(objectManager.MoveState);
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
            if (stateMachine.currentState == objectManager.MoveState)
            {
                objectManager.MoveState.Update(gameTime);
            }
            else if (stateMachine.currentState == objectManager.CollissionState)
            {
                objectManager.CollissionState.Update(gameTime);
            }
            else if (stateMachine.currentState == objectManager.ChaseState)
            {
                objectManager.ChaseState.Update(gameTime);
            }
            else if (stateMachine.currentState == objectManager.CleanState)
            {
                objectManager.CleanState.Update(gameTime);
            }
        }
    }
}
