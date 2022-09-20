using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTree
{
    internal class Node
    {
        NodeList Children;
        string Text;

        //TODO Create constructor
        public Node(string text, int amount)
        {
            text = Console.ReadLine();
            for (int i = 0; i < amount; i++)
            {
                Children = new NodeList();
            }

        }
    }
}
