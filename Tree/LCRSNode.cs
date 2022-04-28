using System;
using System.Collections.Generic;
using System.Text;

namespace Tree
{
    public class LCRSNode
    {
        public object Data { get; set; }
        public LCRSNode LeftChild { get; set; }
        public LCRSNode RightSibling { get; set; }

        public LCRSNode(object data)
        {
            this.Data = data;
        }
    }
}
