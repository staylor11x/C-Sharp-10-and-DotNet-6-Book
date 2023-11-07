using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excersise02
{
    public abstract class Shape
    {
        //fields
        protected double height;
        protected double width;

        //properties
        public virtual double Height
        {
            get
            {
                return height;
            }
            set
            {
                if(value > 0)
                {
                    height = value;
                }
            }
        }

        public virtual double Width
        {
            get
            {
                return width;
            }
            set
            {
                if(value > 0)
                {
                    width = value;
                }
            }
        }
        
        public abstract double Area { get; }

    }


}
