using System.Diagnostics;

namespace ConsoleAppTree
{
    internal class NodeList
    {
        private Node[] nodes = new Node[100];
        
        public NodeList(params Node[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                nodes.Append(arr[i]);
            }
        }

        int Insert(Node node)
        {
            try
            {
                Node[] NewNode = new Node[nodes.Length + 1];

                for (int i = 0; i < nodes.Length; i++)
                    NewNode[i] = nodes[i];

                NewNode[NewNode.Length - 1] = node;
                nodes = NewNode;
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
           
        void Delete(int index)
        {
            try
            {
                nodes[index] = null;
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
                Delete(index);
            }  
        }

        int Search(Node node)
        {
            //TODO Fix Search() method
            return Array.FindIndex(nodes, node => node != null);
        }
        void Update(int index, Node node)
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
        Node? GetAt(int index)
        {
            return nodes[index];
        }

       
    }
}
