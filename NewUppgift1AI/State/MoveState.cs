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

        public MoveState(Robot robot, ObjectManager objectManager, FiniteStateMachine stateMachine) : base(robot, objectManager, stateMachine)
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

            if (CheckRobotPeeDistance(objectManager.peeList))
            {
                stateMachine.ChangeState(robot.objectManager.ChaseState);
            }
            else if (CheckWallCollision() || CheckAquariumCollision())
            {
                stateMachine.ChangeState(robot.objectManager.CollissionState);
            }
            else if (DogRageModeCheck())
            {
                stateMachine.ChangeState(robot.objectManager.FleeState);
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

        public bool CheckAquariumCollision()
        {
            if (robot.Hitbox.Intersects(objectManager.aquarium.Hitbox))
            {
                return true;
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
