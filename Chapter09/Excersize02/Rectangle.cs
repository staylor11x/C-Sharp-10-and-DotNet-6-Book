﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt.Shared
{
    public class Rectangle : Shape
    {
        public Rectangle() { }

        public Rectangle(double height, double width)
        {
            this.height = height;
            this.width = width;
        }
        public override double Area => height * width;
    }
}