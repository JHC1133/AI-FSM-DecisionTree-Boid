using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewUppgift1AI
{
    internal class CleanState : State
    {
        public CleanState(Robot robot, FiniteStateMachine stateMachine) : base(robot, stateMachine)
        {

        }

        public override void Enter()
        {
            robot.SetVelocity(Data.zero);
        }

        public override void Exit()
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            foreach (Pee pee in robot.peeList)
            {
                if (robot.GetDistance(robot.Position, pee.position) < 25)
                {
                    robot.peeList.Remove(pee);
                    stateMachine.ChangeState(robot.MoveState);
                }
            }
        }
    }
}
