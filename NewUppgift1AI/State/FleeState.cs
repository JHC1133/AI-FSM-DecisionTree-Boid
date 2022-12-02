using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
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
            robot.SetEvadeDirection(objectManager.dog.Position, robot.Position);
        }

        public override void Exit()
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            
        }
    }
}
