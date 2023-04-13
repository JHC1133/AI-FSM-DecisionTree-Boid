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

        public MoveState(ObjectManager objectManager, FiniteStateMachine stateMachine) : base(objectManager, stateMachine)
        {

        }

        public override void Enter()
        {

            Debug.WriteLine("Enter Move");
            objectManager.robot.SetVelocity(Data.robotDefaultVel);

            objectManager.robot.SetDirection(objectManager.robot.RandomMovement());
            

        }

        public override void Exit()
        {
            Debug.WriteLine("Exit Move");
        }

        public override void Update(GameTime gameTime)
        {

            if (CheckRobotPeeDistance(objectManager.peeList))
            {
                stateMachine.ChangeState(objectManager.robot.objectManager.ChaseState);
            }
            else if (CheckWallCollision() || CheckAquariumCollision())
            {
                stateMachine.ChangeState(objectManager.robot.objectManager.CollissionState);
            }
            else if (DogRageModeCheck())
            {
                stateMachine.ChangeState(objectManager.robot.objectManager.FleeState);
            }

            
        }

        public bool CheckWallCollision()
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

        public bool CheckRobotPeeDistance(List<Pee> peeList)
        {
            foreach (Pee pee in peeList)
            {
                if (objectManager.robot.GetDistance(objectManager.robot.Position, pee.position) < objectManager.robot.DetectionRadius)
                {
                    return true;
                }
            }          
            return false;
        }
    }
}
