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
        DT newDecisionTree;

        public ObjectManager objectManager;

        int thirstTimer;
        int peeTimer;

        int peeDelay;
        int drinkDelay;
        int moveDirectionTimer; //Move to local?

        int peeTimerDefault = 5000;
        int thirstTimerDefault = 3000;

        int peeDelayDefault = 1000;
        int drinkDelayDefault = 1500;

        public bool isDogThirsty;
        public bool isThereWater;
        public bool isPeeTimerZero;

        public bool drinkMode;
        public bool peeMode;
        public bool rageMode;
        public bool moveMode;
         
        bool hasDrunk;
        bool hasPeed;

        Color color;

        public Vector2 Position { get => position; set => position = value; }
        public Rectangle Hitbox { get => hitbox; set => hitbox = value; }

        public Dog(ObjectManager objectManager)
        {
            this.objectManager = objectManager;
            texture = TextureManager.dogTex;
            position = new Vector2(500, 500);
         
            peeTimer = peeTimerDefault;
            drinkDelay = drinkDelayDefault;

            newDecisionTree = new DT();

            isThereWater = true; //Set by clicking on bowl, public static?
            isDogThirsty = true; //Starts with true to begin loop
            //isPeeTimerZero = false;

            //moveMode = true;
            //rageMode = true;
            
        }

        public override void Update(GameTime gameTime)
        {
            Position += direction * velocity;
            Hitbox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            newDecisionTree.root.Evaluate(this);

            if (hasDrunk)
            {
                peeTimer -= (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            }
            else if (hasPeed)
            {
                thirstTimer -= (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            }

            PeeTimerCheck();
            ThirstMeterCheck();
            CheckWallCollision();
            WaterAvailabiltyCheck();
            RageModeColorToggle();

            if (moveMode)
            {
                Random random = new Random();
                Debug.WriteLine("Dog is in MOVEmode");
                SetVelocity(Data.dogDefaultVel);

                moveDirectionTimer -= (int)gameTime.ElapsedGameTime.TotalMilliseconds;

                if (moveDirectionTimer <= 0)
                {
                    SetDirection(RandomMovement());
                    moveDirectionTimer = random.Next(1000, 7000);
                }
            }
            else if (peeMode)
            {
                Debug.WriteLine("Dog is in PEEmode");
                SetVelocity(Data.zero);

                peeDelay -= (int)gameTime.ElapsedGameTime.TotalMilliseconds;            

                if (peeDelay <= 0)
                {
                    Pee();
                }

            }
            else if (rageMode)
            {
                Debug.WriteLine("Dog is in RAGEmode");
                SetVelocity(Data.dogRageModeVel);
                SetDirection(objectManager.robot.Position, Position);
                CheckWallCollision();

            }
            else if (drinkMode)
            {
                Debug.WriteLine("Dog is in DRINKmode");
                SetDirection(objectManager.waterBowl.position, Position);
                SetVelocity(Data.dogDrinkModeVel);

                if (GetDistance(objectManager.waterBowl.position, Position) < 100)
                {
                    SetVelocity(Data.zero);
                    drinkDelay -= (int)gameTime.ElapsedGameTime.TotalMilliseconds;

                    if (drinkDelay <= 0)
                    {
                        Drink();
                        drinkDelay = drinkDelayDefault;
                    }                                  
                }             
            }
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, color);
        }

        private void Drink()
        {
            hasDrunk = true;
            peeDelay = peeDelayDefault;
            thirstTimer = thirstTimerDefault;
            isDogThirsty = false; //Breaks loop
            objectManager.waterBowl.waterAvailable = false;
        }

        private void Pee()
        {
            objectManager.peeList.Add(new Pee(Position));
            hasDrunk = false;
            hasPeed = true;
            peeTimer = peeTimerDefault;
            isPeeTimerZero = false; //Breaks loop
        }

        private void ThirstMeterCheck()
        {
            if (thirstTimer < 0)
            {
                isDogThirsty = true;
            }
        }

        private void PeeTimerCheck()
        {
            if (peeTimer < 0)
            {
                isPeeTimerZero = true;
            }
        }

        private void WaterAvailabiltyCheck()
        {
            if (objectManager.waterBowl.waterAvailable)
            {
                isThereWater = true;
            }
            else
            {
                isThereWater = false;
            }
        }

        public void CheckWallCollision()
        {
            foreach (Wall wall in objectManager.walls)
            {
                if (Hitbox.Intersects(wall.Hitbox))
                {
                    ReverseDirection();
                }
            }
        }

        private void RageModeColorToggle()
        {
            if (rageMode)
            {
                color = Color.Red;
            }
            else
            {
                color = Color.White;
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
