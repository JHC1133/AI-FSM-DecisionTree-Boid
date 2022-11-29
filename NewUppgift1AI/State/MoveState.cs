using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewUppgift1AI
{
    internal class MoveState : State
    {
        public MoveState(Robot robot, FiniteStateMachine stateMachine) : base(robot, stateMachine)
        {

        }

        public override void Enter()
        {

            Debug.WriteLine("Enter Move");
            robot.SetVelocity(Data.robotDefaultVel);

            robot.SetDirection(robot.RandomMovement());

            //if (robot.currentOrientation != Vector2.Zero)
            //{
            //    if (robot.RandomMovement() == robot.oldOrientation)
            //    {
            //        robot.SetDirection(robot.RandomMovement());
            //    }
            //    //else
            //    //{
            //    //    robot.SetDirection(robot.RandomMovement());
            //    //}
            //}
            //else
            //{
                
            //}


        }

        public override void Exit()
        {
            Debug.WriteLine("Exit Move");
        }

        public override void Update(GameTime gameTime)
        {

            if (CheckWallCollision())
            {
                stateMachine.ChangeState(robot.CollissionState);
            }
        }

        public bool CheckWallCollision()
        {

            foreach (Wall wall in robot.walls)
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
