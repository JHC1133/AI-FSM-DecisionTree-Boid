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
        int directionCalculationTimer = 1000;
        int dirCalcTimerDefault = 1000;

        public CleanState(ObjectManager objectManager, FiniteStateMachine stateMachine) : base(objectManager, stateMachine)
        {

        }

        public override void Enter()
        {
            Debug.WriteLine("Enter CLEAN");
            objectManager.robot.SetVelocity(Data.zero);
        }

        public override void Exit()
        {
            Debug.WriteLine("EXIT CLEAN");

            directionCalculationTimer = dirCalcTimerDefault;
        }

        public override void Update(GameTime gameTime)
        {
            if (PeeRemover())
            {
                stateMachine.ChangeState(objectManager.robot.objectManager.MoveState);
            }

            DogRageModeCheck();

        }

        private bool PeeRemover()
        {
            foreach (Pee pee in objectManager.peeList)
            {
                if (objectManager.robot.GetDistance(objectManager.robot.Position, pee.position) < 25)
                {
                    objectManager.peeList.Remove(pee);
                    return true;
                }              
            }
            return false;
        }
    }
}
