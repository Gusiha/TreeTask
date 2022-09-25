using System.ComponentModel;

namespace ConsoleAppTree
{
    class Node
    {
        private static int StaticKey = -1;
        public NodeList? Children;
        private string _text;
        private readonly int _key;
        public int Key
        {
            get { return _key; }
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }


        public Node(string text = "default", int amount = 1)
        {
            text ??= "default";

            Text = text;
            _key = ++StaticKey;
            Children = new NodeList(amount);
            
        }

    }
}
