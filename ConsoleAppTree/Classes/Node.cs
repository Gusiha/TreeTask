using System.ComponentModel;

namespace ConsoleAppTree
{
    class Node
    {
        public NodeList? Children;
        [DefaultValue("Test")]
        private string text;
 


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
        }

    }
}
