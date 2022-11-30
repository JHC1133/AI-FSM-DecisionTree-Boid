using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewUppgift1AI
{
    internal class ObjectManager
    {
        public List<Wall> walls;
        public List<Pee> peeList;

        Wall top, bottom, leftSide, rightSide;        
        Interior floor;

        Robot robot;
        Dog dog;
        WaterBowl waterBowl;

        int peeDefaultVal = 7000;
        int peeTimer = 7000;

        public ObjectManager(FiniteStateMachine stateMachine)
        {
            InitStaticObjects();
            floor = new Interior(Vector2.Zero);
            waterBowl = new WaterBowl();
            peeList = new List<Pee>();

            InitEntities(stateMachine);

        }
        public void Update(GameTime gameTime)
        {
            UpdateWalls();
            UpdateEntities(gameTime);
            UpdatePeeList();
            waterBowl.Update(gameTime);

            peeTimer -= (int)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (peeTimer <= 0)
            {
                RandomPeeAdderPlaceHolder();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
           
            DrawStaticObjects(spriteBatch);

            DrawPeeList(spriteBatch);
            DrawEntities(spriteBatch);
            
        }

        private void InitStaticObjects()
        {
            int wallWidth = 116;

            top = new Wall(Vector2.Zero, TextureManager.wallTopBotTex);
            bottom = new Wall(new Vector2(0, Game1.WindowY - wallWidth), TextureManager.wallTopBotTex);
            leftSide = new Wall(Vector2.Zero, TextureManager.wallSideTex);
            rightSide = new Wall(new Vector2(Game1.WindowX - wallWidth, 0), TextureManager.wallSideTex);
            floor = new Interior(Vector2.Zero);

            walls = new List<Wall>
            {
                top, bottom, leftSide, rightSide,
            };
        }

        private void UpdateWalls()
        {
            top.Update();
            bottom.Update();
            leftSide.Update();
            rightSide.Update();

            
        }

        private void DrawStaticObjects(SpriteBatch spriteBatch)
        {
            top.Draw(spriteBatch);
            bottom.Draw(spriteBatch);
            leftSide.Draw(spriteBatch);
            rightSide.Draw(spriteBatch);

            floor.Draw(spriteBatch);
            waterBowl.Draw(spriteBatch);
        }

        private void InitEntities(FiniteStateMachine stateMachine)
        {
            robot = new Robot(stateMachine, walls, peeList);
            dog = new Dog();
        }

        private void UpdateEntities(GameTime gameTime)
        {
            robot.Update(gameTime);
            dog.Update(gameTime);
        }

        private void DrawEntities(SpriteBatch spriteBatch)
        {
            robot.Draw(spriteBatch);
            dog.Draw(spriteBatch);
        }

        private void UpdatePeeList()
        {
            foreach (Pee pee in peeList)
            {
                pee.Update();
            }
        }

        private void DrawPeeList(SpriteBatch spriteBatch)
        {
            foreach (Pee pee in peeList)
            {
                pee.Draw(spriteBatch);
            }
        }

        private void RandomPeeAdderPlaceHolder()
        {
            peeTimer = peeDefaultVal;

            Random rand = new Random();

            int vX = rand.Next(300, 1500);
            int vY = rand.Next(300, 900);

            peeList.Add(new Pee(new Vector2(vX, vY)));

        }

  
    }
}
