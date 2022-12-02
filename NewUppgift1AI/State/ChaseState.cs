using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewUppgift1AI
{
    internal class ChaseState : State
    {
        public ChaseState(Robot robot, ObjectManager objectManager, FiniteStateMachine stateMachine) : base(robot, objectManager, stateMachine)
        {

        }

        public override void Enter()
        {
            foreach (Pee pee in objectManager.peeList)
            {
                robot.SetDirection(pee.position, robot.Position);
            }
        }

        public override void Exit()
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            foreach (Pee pee in objectManager.peeList)
            {
                if (robot.GetDistance(robot.Position, pee.position) < 25)
                {
                    
                    stateMachine.ChangeState(robot.CleanState);
                }
            }
        }
    }
}
