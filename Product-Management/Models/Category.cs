﻿using Product_Management.AbstractModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Management.Models
{
    internal class Category:CommonProp
    {
        public Category(string name)
        {
            Name = name;
            IsStatus = true;
        }
    }
}
