using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewUppgift1AI
{
    internal class CollissionState : State
    {
        int timerDefault = 750;
        int timer = 750;

        int directionCalcDefault = 550;
        int directionCalculationTimer = 550;

        public CollissionState(ObjectManager objectManager, FiniteStateMachine stateMachine) : base(objectManager, stateMachine)
        {

        }

        public override void Enter()
        {
            Debug.WriteLine("Enter Collission");
            objectManager.robot.ReverseDirection();
        }

        public override void Exit()
        {
            Debug.WriteLine("Exit Collission");

            timer = timerDefault;
            directionCalculationTimer = directionCalcDefault;
        }

        public override void Update(GameTime gameTime)
        {
            timer -= (int)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timer <= 0)
            {
                objectManager.robot.SetVelocity(Data.zero);

                directionCalculationTimer -= (int)gameTime.ElapsedGameTime.TotalMilliseconds;

                if (directionCalculationTimer <= 0)
                {
                    stateMachine.ChangeState(objectManager.robot.objectManager.MoveState);
                }
            }
            DogRageModeCheck();
        }
    }
}
