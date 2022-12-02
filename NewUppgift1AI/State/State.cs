using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewUppgift1AI
{
    abstract class State
    {
        protected FiniteStateMachine stateMachine;
        protected Robot robot;
        protected ObjectManager objectManager;

        public State(Robot robot, ObjectManager objectManager, FiniteStateMachine stateMachine)
        {
            this.robot = robot;
            this.objectManager = objectManager;
            this.stateMachine = stateMachine;
        }

        public abstract void Enter();

        public abstract void Exit();

        public abstract void Update(GameTime gameTime);

        public virtual void DogRageModeCheck()
        {
            if (objectManager.dog.rageMode)
            {
                stateMachine.ChangeState(robot.objectManager.FleeState);
            }
        }
    }
}
