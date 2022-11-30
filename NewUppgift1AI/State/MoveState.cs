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
        int moveDirectionTimer = 13000;

        public MoveState(Robot robot, FiniteStateMachine stateMachine) : base(robot, stateMachine)
        {

        }

        public override void Enter()
        {

            Debug.WriteLine("Enter Move");
            robot.SetVelocity(Data.robotDefaultVel);

            robot.SetDirection(robot.RandomMovement());

        }

        public override void Exit()
        {
            Debug.WriteLine("Exit Move");
        }

        public override void Update(GameTime gameTime)
        {
            //COMMENTED CODE BELOW IS DOG MOVE PATTERN TEST
            //Random random = new Random();

            //moveDirectionTimer -= (int)gameTime.TotalGameTime.TotalMilliseconds;

            //if (moveDirectionTimer <= 0)
            //{
            //    robot.SetDirection(robot.RandomMovement());
            //    moveDirectionTimer = random.Next(12000, 16000);
            //}

            if (CheckRobotPeeDistance(robot.peeList))
            {
                stateMachine.ChangeState(robot.ChaseState);
            }
            else if (CheckWallCollision())
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

        public bool CheckRobotPeeDistance(List<Pee> peeList)
        {
            foreach (Pee pee in peeList)
            {
                if (robot.GetDistance(robot.Position, pee.position) < robot.DetectionRadius)
                {
                    return true;
                }
            }          
            return false;
        }
    }
}
