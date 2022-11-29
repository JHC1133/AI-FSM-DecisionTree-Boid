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
        Wall top, bottom, leftSide, rightSide;        
        Interior floor;

        Robot robot;

        public ObjectManager(FiniteStateMachine stateMachine)
        {
            InitWalls();
            floor = new Interior(Vector2.Zero);

            InitEntities(stateMachine);

        }
        public void Update(GameTime gameTime)
        {
            UpdateWalls();
            UpdateEntities(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            floor.Draw(spriteBatch);
            DrawWalls(spriteBatch);
            DrawEntities(spriteBatch);
            
        }

        private void InitWalls()
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

        private void DrawWalls(SpriteBatch spriteBatch)
        {
            top.Draw(spriteBatch);
            bottom.Draw(spriteBatch);
            leftSide.Draw(spriteBatch);
            rightSide.Draw(spriteBatch);
        }

        private void InitEntities(FiniteStateMachine stateMachine)
        {
            robot = new Robot(stateMachine);
        }

        private void UpdateEntities(GameTime gameTime)
        {
            robot.Update(gameTime);
        }

        private void DrawEntities(SpriteBatch spriteBatch)
        {
            robot.Draw(spriteBatch);
        }

  
    }
}
