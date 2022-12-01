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

        int thirstMeter;
        int peeTimer;
        int moveDirectionTimer;

        bool isDogThirsty;
        bool isThereWater;
        bool isThePeeTimerZero;

        bool drinkMode;
        bool peeMode;
        bool rageMode;
        bool moveMode;

        bool placeHolderBool;


        public Vector2 Position { get => position; set => position = value; }
        public Rectangle Hitbox { get => hitbox; set => hitbox = value; }

        public Dog()
        {
            texture = TextureManager.dogTex;
            position = new Vector2(500, 500);

            decisionTree = new DecisionTree();
            binaryTree = new BinaryTree();
            GenerateDecisionTree(binaryTree);

            thirstMeter = 5000;
            peeTimer = 3000;

            //moveMode = true;
        }

        public override void Update(GameTime gameTime)
        {
            Position += direction * velocity;
            Hitbox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            binaryTree.ParseTree();

            //thirstMeter -= (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            peeTimer -= (int)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (moveMode)
            {
                Debug.WriteLine("Dog is in MOVEmode");
                SetVelocity(Data.dogDefaultVel);
                //SetDirection(RandomMovement());
                Random random = new Random();

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
            }
            else if (rageMode)
            {
                Debug.WriteLine("Dog is in RAGEmode");
            }
            else if (drinkMode)
            {
                Debug.WriteLine("Dog is in DRINKmode");
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, Color.White);

        }

        private void GenerateDecisionTree(BinaryTree binaryTree)
        {
            binaryTree.SetRoot(1, ThirstMeterCheck());
            binaryTree.AddTrueNode(1, 2, WaterLevelCheck(), placeHolderBool);
            binaryTree.AddFalseNode(1, 3, PeeTimerCheck(), placeHolderBool);
            binaryTree.AddTrueNode(2, 4, ActivateDrink(), drinkMode);
            binaryTree.AddFalseNode(2, 5, ActivateRage(), rageMode);
            binaryTree.AddTrueNode(3, 6, ActivatePee(), peeMode);
            binaryTree.AddFalseNode(3, 7, ActivateMove(), moveMode);
        }

        private bool WaterLevelCheck()
        {
            return false;
        }

        private bool ThirstMeterCheck()
        {
            if (thirstMeter <= 0)
            {
                return true;
            }
            return false;
        }

        private bool PeeTimerCheck()
        {
            if (peeTimer <= 0)
            {
                return true;
            }
            return false;
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
            //moveMode = true;
            return false;
        }
    }
}
