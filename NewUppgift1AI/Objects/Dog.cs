using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewUppgift1AI
{
    internal class Dog : Entity
    {
        DecisionTree decisionTree;

        int thirstMeter;
        int peeTimer;

        bool isDogThirsty;
        bool isThereWater;
        bool isThePeeTimerZero;


        public Vector2 Position { get => position; set => position = value; }
        public Rectangle Hitbox { get => hitbox; set => hitbox = value; }

        public Dog()
        {
            texture = TextureManager.dogTex;
            position = new Vector2(500, 500);

            decisionTree = new DecisionTree();
        }

        public override void Update(GameTime gameTime)
        {
            Position += direction * velocity;
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, Color.White);

        }

        private void GenerateDecisionTree(DecisionTree decisionTree)
        {
            decisionTree = new BinaryTree()
        }

        public bool WaterLevelCheck()
        {
            return false;
        }

        public bool ThirstMeterCheck()
        {
            if (thirstMeter <= 0)
            {
                return true;
            }

            return false;
        }
    }
}
