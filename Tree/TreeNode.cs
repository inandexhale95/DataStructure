using System;
using System.Collections.Generic;
using System.Text;

namespace Tree
{
    public class TreeNode
    {
        public object Data { get; set; }
        public TreeNode[] Links { get; private set; }

        public TreeNode(object data, int maxDegree = 3)
        {
            this.Data = data;
            this.Links = new TreeNode[maxDegree];
        }
    }
}
