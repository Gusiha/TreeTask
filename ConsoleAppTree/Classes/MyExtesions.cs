using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppTree;

namespace ConsoleAppTree.Extension
{
    static class MyExtensions
    {
        public static void PrintNodeInfo(this Node node)
        {
            Console.WriteLine($"Name : { node.Text}\nAmount of kids: {node.Children?.Length}");
        }
    }
}
