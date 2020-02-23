using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ED2_LAB3_2.Models
{
    public class Node
    {
        public Node rightChild { get; set; }
        public Node leftChild { get; set; }
        public Node intermideateChild { get; set; }
        public Soda rightVal { get; set; }
        public Soda leftVal { get; set; }
    }
}
