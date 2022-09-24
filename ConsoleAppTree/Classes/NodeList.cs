using System.Diagnostics;
using static ConsoleAppTree.AutoGeneration;


namespace ConsoleAppTree
{
    class NodeList
    {
        private Node[] nodes;
        public NodeList(int amount)
        {
            nodes = new Node[amount];
            for (int i = 0; i < amount; i++)
            {
                nodes[i] = new Node(Generation(), 0);
            }
        }

        //public NodeList(Node element)
        //{
        //    //var nodes1 = (Node[])nodes.Clone();
        //    Array.Resize(ref nodes, nodes.Length + 1);
        //    nodes = (Node[])nodes.Append(element);
        //}

        public int Insert(Node node)
        {
            try
            {
                Array.Resize(ref nodes, nodes.Length + 1);
                nodes = nodes.Append(node).ToArray();
                return nodes.Length;
            }
            catch (ArgumentNullException ex)
            {
                Debug.Indent();
                Debug.WriteLine(ex.Message);
                Debug.Unindent();
                throw;
            }
        }

        public void Delete(int index)
        {
            /*try
            {*/
            if (index < 0 || index >= nodes.Length)
                throw new ArgumentOutOfRangeException("Incorrect index!");
            var temporary = new Node[nodes.Length - 1];
            var j = 0;
            for (int i = 0; i < temporary.Length; i++)
            {
                if (j == index)
                    j++;
                temporary[i] = nodes[j];
            }
            nodes = temporary;


            /*}
            catch (IndexOutOfRangeException ex)
            {
                Debug.Indent();
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("Incorrect symbol. Input index again: ");
                Debug.Unindent();
                throw new IndexOutOfRangeException("Incorrect index!");
            }*/
        }

        public int Search(Node node)
        {
            //TODO Fix Search() method
            return Array.FindIndex(nodes, node => node != null);
        }
        public void Update(int index, Node node)
        {
            try
            {
                nodes[index] = node;
            }
            catch (IndexOutOfRangeException ex)
            {
                Debug.WriteLine(ex.Message);
                while (int.TryParse(Console.ReadLine(), out int result) == false)
                {
                    Debug.Indent();
                    Debug.WriteLine("Incorrect symbol. Input index again: ");
                    Debug.Unindent();
                    if (int.TryParse(Console.ReadLine(), out result))
                        break;
                }
                Update(index, node);
            }
        }
        public Node? GetAt(int index)
        {
            return nodes[index];
        }

        public void PrintChildren(int index)
        {
            Console.WriteLine(nodes[index].Text);
        }

    }
}
