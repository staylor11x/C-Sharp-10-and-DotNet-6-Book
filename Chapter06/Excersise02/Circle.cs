using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excersise02
{
    public class Circle : Square
    {
        //fields
        protected double radius;
        public Circle() { }

        public Circle(double radius) : base(width: radius * 2) { }

        public double Radius
        {
            get
            {
                return height / 2;
            }
            set
            {
                Height = value * 2;
            }
        }

        public override double Area => (Width/2) * (Width/2) * Math.PI;
    }
}
