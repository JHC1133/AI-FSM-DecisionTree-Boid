using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewUppgift1AI
{
    internal class Flock
    {
        AqWater aqWater;
        private List<Boid> boids;

        private int numBoids = 10;
        private static Random rand = new Random();

        public Flock(AqWater aqWater)
        {
            this.aqWater = aqWater;

            boids = new List<Boid>();

            for (int i = 0; i < numBoids; i++)
            {
                Boid b = new Boid(rand.Next(((int)aqWater.Position.X), aqWater.Texture.Width), rand.Next(((int)aqWater.Position.Y), aqWater.Texture.Height), this, aqWater);
                Add(b);
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Boid b in boids)
            {
                b.Draw(spriteBatch);
            }
        }

        public void Update()
        {
            Task.Run(() => {
                foreach (Boid b in boids)
                {
                    b.Accelerate(FlockBehaviour.Avoidance(b, boids) * 1.5f);
                    b.Accelerate(FlockBehaviour.AvoidPoints(b, GetBorderPoints(b)) * 5);
                    b.Accelerate(FlockBehaviour.Alignment(b, boids) / 1.5f);
                    b.Accelerate(FlockBehaviour.Cohesion(b, boids) / 3);
                    b.Accelerate(b.velocity / 7);
                    b.Run();
                }
            });
        }

        public void Add(Boid boid)
        {
            boids.Add(boid);
        }

        public void Remove(Boid boid)
        {
            boids.Remove(boid);
        }

        private List<Vector2> GetBorderPoints(Boid boid)
        {
            return new List<Vector2>() {
            new Vector2(boid.position.X, 0),
            new Vector2(boid.position.X, aqWater.Texture.Width),
            new Vector2(0, boid.position.Y),
            new Vector2(aqWater.Texture.Height, boid.position.Y)
            };
        }
    }
}
