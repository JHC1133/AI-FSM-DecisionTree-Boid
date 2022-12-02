using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NewUppgift1AI.DecisionTree;

namespace NewUppgift1AI
{
    internal class Dog : Entity
    {
        DecisionTree decisionTree;
        BinaryTree binaryTree;
        DT newDecisionTree;

        int thirstTimer;
        int peeTimer;
        int rageTimer;
        int moveDirectionTimer; //Move to local?

        int peeTimerDefault = 5000;
        int thirstTimerDefault = 3000;
        int rageTimerDefault = 5000;

        public bool isDogThirsty;
        public bool isThereWater;
        public bool isPeeTimerZero;

        public bool drinkMode;
        public bool peeMode;
        public bool rageMode;
        public bool moveMode;

        bool hasDrunk;
        bool hasPeed;
        bool isRaging;

        bool placeHolderBool; //Remove


        public Vector2 Position { get => position; set => position = value; }
        public Rectangle Hitbox { get => hitbox; set => hitbox = value; }

        public Dog(WaterBowl waterBowl, List<Wall> walls, List<Pee> pee, Robot robot)
        {
            texture = TextureManager.dogTex;
            position = new Vector2(500, 500);

            
            peeTimer = peeTimerDefault;

            newDecisionTree = new DT();

            isThereWater = true; //Set by clicking on bowl, public static?
            isDogThirsty = true; //Starts with true to begin loop
            isPeeTimerZero = false;

            //moveMode = true;
        }

        public override void Update(GameTime gameTime)
        {
            Position += direction * velocity;
            Hitbox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);



            if (hasDrunk)
            {
                peeTimer -= (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            }
            else if (hasPeed)
            {
                
            }
            else if (isRaging)
            {
                
            }

            newDecisionTree.root.Evaluate(this);

            PeeTimerCheck();
            ThirstMeterCheck();

  

            if (moveMode)
            {
                Random random = new Random();
                Debug.WriteLine("Dog is in MOVEmode");
                SetVelocity(Data.dogDefaultVel);

                moveDirectionTimer -= (int)gameTime.ElapsedGameTime.TotalMilliseconds;

                if (moveDirectionTimer <= 0)
                {
                    SetDirection(RandomMovement());
                    moveDirectionTimer = random.Next(1000, 3000);
                }
            }
            else if (peeMode)
            {

                Debug.WriteLine("Dog is in PEEmode");
                SetVelocity(Data.zero);

                //Psuedo, move setting of peeDelay
                int peeDelay = 1000;
                peeDelay -= (int)gameTime.ElapsedGameTime.TotalMilliseconds;

                if (peeDelay <= 0)
                {
                    peeTimer = peeTimerDefault;
                }

            }
            else if (rageMode)
            {
                Debug.WriteLine("Dog is in RAGEmode");
                SetVelocity(Data.dogRageModeVel);
                
            }
            else if (drinkMode)
            {
                Debug.WriteLine("Dog is in DRINKmode");
                
                //SetDirection()
                
            }

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (rageMode)
            {
                spriteBatch.Draw(texture, Position, Color.Red);
            }
            else
            {
                spriteBatch.Draw(texture, Position, Color.White);
            }
        }

        private void Pee(GameTime gameTime)
        {
            SetVelocity(Data.zero);

            int peeDelay = 1000;
            peeDelay -= (int)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (peeDelay <= 0)
            {
                peeTimer = peeTimerDefault;
            }
        }


        private bool WaterLevelCheck()
        {
            return false;
        }

        private void ThirstMeterCheck()
        {
            if (thirstTimer <= 0)
            {
                isDogThirsty = true;
            }
        }

        private void PeeTimerCheck()
        {
            if (peeTimer <= 0)
            {
                isPeeTimerZero = true;
            }
        }





















        private bool ActivateDrink()
        {
            drinkMode = true;
            return false; //Vet inte vad detta ger för effekt
        }

        private bool ActivatePee()
        {
            peeMode = true;
            return false;
        }

        private bool ActivateRage()
        {
            rageMode = true;
            return false;
        }

        private bool ActivateMove()
        {
            moveMode = true;
            return false;
        }


        private void DogModeCheck()
        {
            if (isDogThirsty)
            {
                if (isThereWater)
                {
                    drinkMode = true;
                }
                else
                {
                    rageMode = true;
                }
            }
            else
            {
                if (isPeeTimerZero)
                {
                    moveMode = false;
                    peeMode = true;
                }
                else
                {
                    moveMode = true;
                }
            }
        }

        private void GenerateDecisionTree(BinaryTree binaryTree)
        {
            binaryTree.SetRoot(1, isDogThirsty);
            binaryTree.AddTrueNode(1, 2, isThereWater);
            binaryTree.AddFalseNode(1, 3, isPeeTimerZero);
            binaryTree.AddTrueNode(2, 4, drinkMode);
            binaryTree.AddFalseNode(2, 5, rageMode);
            binaryTree.AddTrueNode(3, 6, peeMode);
            binaryTree.AddFalseNode(3, 7, moveMode);
        }
    }
}
