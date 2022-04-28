using System;
using System.Collections.Generic;
using System.Text;

namespace Tree
{
    public class TreeNode2
    {
        public object Data { get; set; }
        public List<TreeNode2> Links { get; private set; }

        public TreeNode2(object data)
        {
            this.Data = data;
            Links = new List<TreeNode2>();
        }
    }
}
