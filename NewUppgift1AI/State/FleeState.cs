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
        public FleeState(Robot robot, ObjectManager objectManager, FiniteStateMachine stateMachine) : base(robot, objectManager, stateMachine)
        {
        }

        public override void Enter()
        {
            Debug.WriteLine("Robot Enter FLEE");
            
            robot.SetVelocity(Data.robotFleeModeVel);           
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

            robot.SetEvadeDirection(objectManager.dog.Position, robot.Position);

            foreach (Wall wall in objectManager.walls)
            {
                if (robot.Hitbox.Intersects(wall.Hitbox))
                {
                    robot.ReverseDirection();
                }
            }
        }

        public bool CheckWallCollision()
        {

            foreach (Wall wall in objectManager.walls)
            {
                if (robot.Hitbox.Intersects(wall.Hitbox))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
