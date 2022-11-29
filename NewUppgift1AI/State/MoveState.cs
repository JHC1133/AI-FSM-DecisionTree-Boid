using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
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
            robot.SetVelocity(Data.robotDefaultVel);
            robot.SetDirection(robot.RandomMovement());
        }

        public override void Exit()
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            //Ex: If you would want to change texture for this state


        }
    }
}
