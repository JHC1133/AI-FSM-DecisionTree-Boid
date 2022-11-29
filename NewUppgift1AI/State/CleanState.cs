using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Debug.WriteLine("Enter CLEAN");
            robot.SetVelocity(Data.zero);
        }

        public override void Exit()
        {
            Debug.WriteLine("EXIT CLEAN");
        }

        public override void Update(GameTime gameTime)
        {
            if (PeeRemover())
            {
                stateMachine.ChangeState(robot.MoveState);
            }
        }

        private bool PeeRemover()
        {
            foreach (Pee pee in robot.peeList)
            {
                if (robot.GetDistance(robot.Position, pee.position) < 25)
                {
                    robot.peeList.Remove(pee);
                    return true;
                }              
            }
            return false;
        }
    }
}
