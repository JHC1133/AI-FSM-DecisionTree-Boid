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

        public State(Robot robot, FiniteStateMachine stateMachine)
        {
            this.robot = robot;
            this.stateMachine = stateMachine;
        }

        public abstract void Enter();

        public abstract void Exit();

        public abstract void Update(GameTime gameTime);
    }
}
