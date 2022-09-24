using ConsoleAppTree;


class Program
{

    //static void Print(string[] funny)
    //{
    //    for(int i = 0; i < funny.Length; i++)
    //        Console.Write(funny[i]);
    //    Console.WriteLine();
    //}
    static void Main()
    {
        Node Root = new("A", 3);
        Root.Children?.Update(2,new("b",0));
        for (int i = 0; i < 3; i++)
        {
            Root.Children?.PrintChildren(i);
        }
    }
}

