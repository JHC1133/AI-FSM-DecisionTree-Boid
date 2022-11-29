using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewUppgift1AI
{
    internal class FiniteStateMachine
    {


        public FiniteStateMachine()
        {

        }

        public State currentState { get; private set; }

        public void Initialize(State startingState)
        {
            currentState = startingState;
            currentState.Enter();
        }

        public void ChangeState(State newState) 
        {
            currentState.Exit();
            currentState = newState;
            currentState.Enter();
        }
    }
}
