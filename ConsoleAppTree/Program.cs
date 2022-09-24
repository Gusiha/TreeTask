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
        Node Root = new("A", 10);
        Root.Children?.Update(1,new("IvanHunter",0));
        for (int i = 0; i < Root.Children?.Length; i++)
        {
            Root.Children?.PrintChildren(i);
        }

        Console.WriteLine("-------------------------");

        Root.Children?.Delete(0);
        for (int i = 0; i < Root.Children?.Length; i++)
        {
            Root.Children?.PrintChildren(i);
        }
    }

}

