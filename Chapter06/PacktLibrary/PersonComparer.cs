﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt.Shared;

public class PersonComparer : IComparer<Person>
{
    public int Compare(Person? x, Person? y)
    {
        if (x is null || y is null) return 0;

        //compare the name lengths
        int result = x.Name.Length.CompareTo(y.Name.Length);

        //...if they are equal...
        if (result == 0)
        {
            //...then compare by names...
            return x.Name.CompareTo(y.Name);
        }
        else   //result will be -1 or 1
        {
            //otherwise compare by lenghts
            return result;
        }
    }
}
