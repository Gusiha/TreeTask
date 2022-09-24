namespace ConsoleAppTree
{
    class Node
    {
        private NodeList? Children;
        private string? Text;

        //TODO Create constructor
        public Node(string text, int amount)
        {
            if (text == null)
                throw new ArgumentNullException("text parameter is null");
            Text = text;
            Children = new NodeList();
        }
    }
}
