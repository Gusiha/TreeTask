namespace ConsoleAppTree
{
    internal class NodeList
    {
        private Node[]? nodes = new Node[100];

        
        

        int Insert(Node node)
        {
            //TODO Create the try-catch block(node!=null)
            Node?[] NewNode = new Node[nodes.Length + 1];

            for (int i = 0; i < nodes.Length; i++)
                NewNode[i] = nodes[i];

            NewNode[NewNode.Length - 1] = node;
            nodes = NewNode;
            return nodes.Length;
        }
           
        void Delete(int index)
        {

            
        }

        int Search(Node node)
        {
            return Array.FindIndex(nodes, node => node != null);
        }
        void Update(int index, Node node)
        {

        }
        Node GetAt(int index)
        {
            return nodes[index];
        }

       
    }
}
