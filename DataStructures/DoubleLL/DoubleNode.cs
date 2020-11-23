using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.DoubleLL
{
    class DoubleNode
    {
        public int Value { get; set; }
        public DoubleNode Next { get; set; }
        public DoubleNode Previous { get; set; }

        public DoubleNode()
        {
            Next = null;
            Previous = null;
        }

        public DoubleNode(int value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }
    }
}
