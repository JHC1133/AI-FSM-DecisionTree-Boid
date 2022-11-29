﻿using Microsoft.Xna.Framework;
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

        public CollissionState(Robot robot, FiniteStateMachine stateMachine) : base(robot, stateMachine)
        {

        }

        public override void Enter()
        {
            Debug.WriteLine("Enter Collission");
            robot.ReverseDirection();
        }

        public override void Exit()
        {
            Debug.WriteLine("Exit Collission");

            timer = timerDefault;
        }

        public override void Update(GameTime gameTime)
        {
            timer -= (int)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timer <= 0)
            {
                stateMachine.ChangeState(robot.MoveState);
            }
        }
    }
}
