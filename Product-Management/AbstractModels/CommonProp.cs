using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Management.AbstractModels
{
    abstract class CommonProp
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public bool IsStatus { get; set; }
    }
}
