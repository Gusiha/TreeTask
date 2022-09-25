using ConsoleAppTree;
using ConsoleAppTree.Extension;


class Program
{
    static void Main()
    {
        Node Root = new("A", 10);
        Node child = new("B", 0);
        Node child2 = new("C", 1);
        Root.Children?.Update(0, child);
        Root.Children?.Update(1, child2);

        Root.Children.GetAtOut(out Node node, 3);

        Node node1 = new("A", 0);
        Root.Children.GetAtRef(ref node1, 3);

        Root.Children?.Update(1,new("IvanHunter",0));

        Console.WriteLine("Конец");

        //Root.Children?.Update(1,new("IvanHunter",0));

        ////TODO [VLAD] в этот метод нужно вставить Node[], но nodes из NodeList - private, тут либо public ставить[нехорошо], либо свойство для него писать[хорошо].
        ////В перегрузках GetAt показана разница обычного Node[], ref Node[], out Node[], можешь глянуть, возможно я что-то неправильно сделал и ты успеешь сделать по-другому.
        ////Root.Children?.GetAt()

        //for (int i = 0; i < Root.Children?.Length; i++)
        //{
        //    Root.Children?.PrintChildren(i);
        //}

        //Console.WriteLine("-------------------------");
        //Console.WriteLine(Root.Children?.GetAt(1)) ;
        //Root.Children?.Insert(in child);
        //Root.Children?.Insert();
        //for (int i = 0; i < Root.Children?.Length; i++)
        //{
        //    Root.Children?.PrintChildren(i);
        //}

        //Root.PrintNodeInfo();
    }

}

