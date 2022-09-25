using System.ComponentModel;

namespace ConsoleAppTree
{
    class Node
    {
        static int StaticKey = -1;
        public NodeList? Children;
        private string _text;
 


        public string Text
        {
            get { return _text; }
            private set { _text = value; }
        }


        public Node(string text = "default", int amount = 1)
        {
            text ??= "default";

            Text = text;
            Children = new NodeList(amount);
            key = StaticKey++;
        }

    }
}
