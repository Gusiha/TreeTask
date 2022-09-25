using System.ComponentModel;

namespace ConsoleAppTree
{
    class Node
    {
        static int StaticKey = -1;
        public NodeList? Children;
        private string text;
        private int key;

        public string Text
        {
            get { return text; }
            private set { text = value; }
        }


        public Node(string text, int amount)
        {
            if (text == null)
                throw new ArgumentNullException("text parameter is null");
            Text = text;
            Children = new NodeList(amount);
            key = StaticKey++;
        }

    }
}
