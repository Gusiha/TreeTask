using ConsoleAppTree;


class Program
{
    static void Main()
    {
        Node Root = new("A", 10);
        Node child = new("B", 0);
        Node child2 = new("C", 0);

        Root.Children?.Update(1,new("IvanHunter",0));


        for (int i = 0; i < Root.Children?.Length; i++)
        {
            Root.Children?.PrintChildren(i);
        }

        Console.WriteLine("-------------------------");
        Console.WriteLine(Root.Children.GetAt(1)) ;
        Root.Children?.Insert(in child);
        for (int i = 0; i < Root.Children?.Length; i++)
        {
            Root.Children?.PrintChildren(i);
        }
    }

}

