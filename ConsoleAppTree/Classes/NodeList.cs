using System.Diagnostics;
using static ConsoleAppTree.AutoGeneration;


namespace ConsoleAppTree
{
    class NodeList
    {
        private Node[] nodes;

        private readonly string UnicodeSymbols = "│├─└";

        public int Length { get { return nodes.Length; } private set { } }

        public NodeList(int amount)
        {
            nodes = new Node[amount];
            for (int i = 0; i < amount; i++)
            {
                nodes[i] = new Node(Generation(), 0);
            }
        }

        public static void Print(Node root)
        {
            Console.WriteLine();
        }

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

        public int Insert(params Node[] arr)
        {
            try
            {
                Array.Resize(ref nodes, nodes.Length + arr.Length);
                for (int i = 0; i < arr.Length; i++)
                {
                    nodes = nodes.Append(arr[i]).ToArray();
                }
                
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

            try
            {
                if (index < 0 || index >= nodes.Length)
                    throw new ArgumentOutOfRangeException("Incorrect index!");
                var temporary = new Node[nodes.Length - 1];


                for (int i = 0; i < index; i++)
                {
                    temporary[i] = nodes[i];
                }

                for (int i = index + 1; i < nodes.Length; i++)
                {
                    temporary[i - 1] = nodes[i];
                }

                nodes = temporary;
            }

            catch (ArgumentOutOfRangeException ex)
            {
                Debug.Indent();
                Debug.WriteLine(ex.Message);
                Debug.Unindent();

                while (int.TryParse(Console.ReadLine(), out index) == false)
                {
                    Debug.Indent();
                    Debug.WriteLine("Incorrect symbol. Input index again: ");
                    Debug.Unindent();

                }
                Delete(index);
            }


        }

        public void ShortDelete(int index)
        {
            try
            {
                if ((index < 0) || (index >= nodes.Length))
                    throw new ArgumentOutOfRangeException("index");

                var temporary = new Node[nodes.Length - 1];
                Array.Copy(nodes, 0, temporary, 0, index);
                Array.Copy(nodes, index + 1, temporary, index, nodes.Length - index - 1);

                nodes = temporary;
            }

            catch (ArgumentOutOfRangeException ex)
            {
                Debug.Indent();
                Debug.WriteLine(ex.Message);
                Debug.Unindent();

                while (int.TryParse(Console.ReadLine(), out index) == false)
                {
                    Debug.Indent();
                    Debug.WriteLine("Incorrect symbol. Input index again: ");
                    Debug.Unindent();
                }
                Delete(index);
            }

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
        public Node GetAt(int index)
        {
            return nodes[index];
        }

        public void PrintChildren(int index)
        {
            if (nodes[index] != null)
            {
                Console.WriteLine(nodes[index].Text);
            }
            
        }

    }
}
