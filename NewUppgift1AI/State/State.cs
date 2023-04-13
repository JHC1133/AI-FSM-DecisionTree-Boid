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
        //protected Robot robot;
        protected ObjectManager objectManager;

        public State(ObjectManager objectManager, FiniteStateMachine stateMachine)
        {
            this.objectManager = objectManager;
            this.stateMachine = stateMachine;
        }

        public abstract void Enter();

        public abstract void Exit();

        public abstract void Update(GameTime gameTime);

        public bool DogRageModeCheck()
        {
            if (objectManager.dog.rageMode)
            {
                return true;
            }
            return false;
        }
    }
}
