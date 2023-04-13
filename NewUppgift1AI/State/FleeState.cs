using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewUppgift1AI
{
    internal class FleeState : State
    {
        public FleeState(ObjectManager objectManager, FiniteStateMachine stateMachine) : base(objectManager, stateMachine)
        {
        }

        public override void Enter()
        {
            Debug.WriteLine("Robot Enter FLEE");
            
            objectManager.robot.SetVelocity(Data.robotFleeModeVel);           
        }

        public override void Exit()
        {
            Debug.WriteLine("Robot Exit FLEE");
        }

        public override void Update(GameTime gameTime)
        {
            //if (CheckWallCollision())
            //{
            //    stateMachine.ChangeState(robot.objectManager.CollissionState);
            //}

            Debug.WriteLine("Robot UPDATE FLEE");

            objectManager.robot.SetEvadeDirection(objectManager.dog.Position, objectManager.robot.Position);

            if (CheckWallCollision() || CheckAquariumCollision())
            {
                objectManager.robot.ReverseDirection();
            }

            if (!DogRageModeCheck())
            {
                stateMachine.ChangeState(objectManager.MoveState);
            }
        }

        private bool CheckWallCollision()
        {

            foreach (Wall wall in objectManager.walls)
            {
                if (objectManager.robot.Hitbox.Intersects(wall.Hitbox))
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckAquariumCollision()
        {
            if (objectManager.robot.Hitbox.Intersects(objectManager.aquarium.Hitbox))
            {
                return true;
            }
            return false;
        }
    }
}
