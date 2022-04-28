using System;
using System.Collections.Generic;
using System.Text;

namespace Tree
{
    public class LCRSTree
    {
        public LCRSNode Root { get; set; }

        public LCRSTree(object rootData)
        {
            this.Root = new LCRSNode(rootData);
        }

        public LCRSNode AddChild(LCRSNode parent, object data)
        {
            if (parent == null)
            {
                return null;
            }

            LCRSNode child = new LCRSNode(data);

            // 부모 노드의 왼쪽 자식 노드가 null이면 왼쪽 노드에 추가한다.
            if (parent.LeftChild == null)
            {
                parent.LeftChild = child;
            }
            // null이 아니면 왼쪽 자식 노드에 있는 오른쪽 형제 노드를 계속 따라가 마지막 형제 노드 다음에 자식을 추가한다.
            else
            {
                var node = parent.LeftChild;

                while (node.RightSibling != null)
                {
                    node = node.RightSibling;
                }
                node.RightSibling = child;
            }

            return child;
        }

        public LCRSNode AddSibling(LCRSNode node, object data)
        {
            if (node == null)
            {
                return null;
            }

            // 형제 노드가 null이 아닐때까지 이동한다.
            while (node.RightSibling != null)
            {
                node = node.RightSibling;
            }

            var sibling = new LCRSNode(data);
            node.RightSibling = sibling;
            return sibling;
        }

        // 레벨순으로 트리노드 출력
        public void PrintLevelOrder()
        {
            var queue = new Queue<LCRSNode>();
            // 먼저 루트 노드를 큐에 등록한다.
            queue.Enqueue(this.Root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                while (node != null)
                {
                    Console.WriteLine($"{node.Data}");

                    // 왼쪽 자식 노드가 있으면 큐에 등록한다.
                    if (node.LeftChild != null)
                    {
                        queue.Enqueue(node.LeftChild);
                    }

                    // 다음 형제 노드로 이동
                    node = node.RightSibling;
                }
            }
        }

        public void PrintIndentTree()
        {
            PrintIndent(this.Root, 1);
        }

        private void PrintIndent(LCRSNode node, int indent)
        {
            if (node == null)
            {
                return;
            }

            // 현재 노드 출력
            string pad = " ".PadLeft(indent);
            Console.WriteLine($"{pad} {node.Data}");

            // 왼쪽 자식
            PrintIndent(node.LeftChild, indent + 1);

            // 오른쪽 형제
            PrintIndent(node.RightSibling, indent);
        }
    }
}
