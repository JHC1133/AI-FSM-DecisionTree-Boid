using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewUppgift1AI.Objects
{
    internal class Field
    {
        public readonly double width;
        public readonly double height;
        public readonly List<Boid> boids = new List<Boid>();
        private readonly Random random= new Random();

        private int boidsCount;

        public Field(double width, double height)
        {
            this.width = width;
            this.height = height;
            boidsCount = 10;

            for (int i = 0; i < boidsCount; i++)
            {
                boids.Add(new Boid(random, width, height));
            }
        }

    }
}
