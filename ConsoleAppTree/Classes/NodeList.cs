using System;
using System.Diagnostics;
using System.Reflection;
using static ConsoleAppTree.AutoGeneration;


namespace ConsoleAppTree
{

    class NodeList
    {
        private Node[] nodes;

        //TODO [IVAN,Senya] напишите функцию Print(). Ниже есть символы, юзайте их. Насчет реализации: у Вани там был какой-то пример.
        private readonly string UnicodeSymbols = "│├─└";


        public int Length { get { return nodes.Length; } private set { } }

        public NodeList(int amount)
        {
            nodes = new Node[amount];
            for (int i = 0; i < amount; i++)
            {
                nodes[i] = new Node(Generation(), 0);
            }
        }

        public static void Print(Node root)
        {
            //Print() intendes for IVAN
            Console.WriteLine();
        }

        public int Insert()
        {
            try
            {
                Array.Resize(ref nodes, nodes.Length + 1);
                nodes = nodes.Append(new("Default", 0)).ToArray();
                return nodes.Length;
            }
            catch (ArgumentNullException ex)
            {
                Debug.Indent();
                Debug.WriteLine(ex.Message);
                Debug.Unindent();
                throw;
            }
        }


        public int Insert(Node node)
        {
            try
            {
                Array.Resize(ref nodes, nodes.Length + 1);
                nodes = nodes.Append(node).ToArray();
                return nodes.Length;
            }
            catch (ArgumentNullException ex)
            {
                Debug.Indent();
                Debug.WriteLine(ex.Message);
                Debug.Unindent();
                throw;
            }
        }

        public int Insert(params Node[] arr)
        {
            try
            {
                Array.Resize(ref nodes, nodes.Length + arr.Length);
                for (int i = 0; i < arr.Length; i++)
                {
                    nodes = nodes.Append(arr[i]).ToArray();
                }

                return nodes.Length;
            }

            catch (ArgumentNullException ex)
            {
                Debug.Indent();
                Debug.WriteLine(ex.Message);
                Debug.Unindent();
                throw;
            }
        }

        public int Insert(in Node node)
        {
            try
            {
                Array.Resize(ref nodes, nodes.Length + 1);
                nodes = nodes.Append(node).ToArray();
                return nodes.Length;
            }
            catch (ArgumentNullException ex)
            {
                Debug.Indent();
                Debug.WriteLine(ex.Message);
                Debug.Unindent();
                throw;
            }
        }

        public void Delete(int key)
        {
            for (int i = 0; i < nodes.Length; i++)
            {
                if (nodes[i].Key == key)
                    ShortDelete(i);
                else if (nodes[i].Children != null)
                {
                    var node = nodes[i].Children?.Search(key);
                    if (node != null)
                        ShortDelete(i);
                }
            }
            return;
        }

        //private void Delete(int index)
        //{

        //    try
        //    {
        //        if (index < 0 || index >= nodes.Length)
        //            throw new ArgumentOutOfRangeException("Incorrect index!");
        //        var temporary = new Node[nodes.Length - 1];


        //        for (int i = 0; i < index; i++)
        //        {
        //            temporary[i] = nodes[i];
        //        }

        //        for (int i = index + 1; i < nodes.Length; i++)
        //        {
        //            temporary[i - 1] = nodes[i];
        //        }

        //        nodes = temporary;
        //    }

        //    catch (ArgumentOutOfRangeException ex)
        //    {
        //        Debug.Indent();
        //        Debug.WriteLine(ex.Message);
        //        Debug.Unindent();

        //        while (int.TryParse(Console.ReadLine(), out index) == false)
        //        {
        //            Debug.Indent();
        //            Debug.WriteLine("Incorrect symbol. Input index again: ");
        //            Debug.Unindent();

        //        }
        //        Delete(index);
        //    }


        //}

        private void ShortDelete(int index)
        {
            try
            {
                if ((index < 0) || (index >= nodes.Length))
                    throw new ArgumentOutOfRangeException("index");

                var temporary = new Node[nodes.Length - 1];
                Array.Copy(nodes, 0, temporary, 0, index);
                Array.Copy(nodes, index + 1, temporary, index, nodes.Length - index - 1);

                nodes = temporary;
            }

            catch (ArgumentOutOfRangeException ex)
            {
                Debug.Indent();
                Debug.WriteLine(ex.Message);
                Debug.Unindent();

                while (int.TryParse(Console.ReadLine(), out index) == false)
                {
                    Debug.Indent();
                    Debug.WriteLine("Incorrect symbol. Input index again: ");
                    Debug.Unindent();
                }
                ShortDelete(index);
            }

        }


        public Node? Search(string text)
        {
            for(int i = 0; i < nodes.Length; i++)
            {
                if (nodes[i].Text == text)
                    return nodes[i];
                else if (nodes[i].Children != null)
                {
                    var node = nodes[i].Children?.Search(text);
                    if (node != null)
                        return node;
                }
            }
            return null;
        }

        public Node? Search(int key)
        {
            for (int i = 0; i < nodes.Length; i++)
            {
                if (nodes[i].Key == key)
                    return nodes[i];
                else if (nodes[i].Children != null)
                {
                    var node = nodes[i].Children?.Search(key);
                    if (node != null)
                        return node;
                }
            }
            return null;
        }

       

        public void Update(int index, Node node)
        {
            try
            {
                nodes[index] = node;
            }
            catch (IndexOutOfRangeException ex)
            {
                Debug.WriteLine(ex.Message);
                while (int.TryParse(Console.ReadLine(), out int result) == false)
                {
                    Debug.Indent();
                    Debug.WriteLine("Incorrect symbol. Input index again: ");
                    Debug.Unindent();
                    if (int.TryParse(Console.ReadLine(), out result))
                        break;
                }
                Update(index, node);
            }
        }


        public Node GetAt(int index)
        {
            return nodes[index];
        }

        /*public Node GetAt(Node[] node, int index)
        {
            node = null; // по идее удаляю массив нодов, и тот самый node[index] из управляемой кучи ..... на самом деле мы присваиваем null копии, содержащей в себе ссылку, т.е. ссылку мы не трогаем

            return nodes[index]; // по идее в оригинальном массиве теперь тоже ничего нету, ведь как бы ссылочный тип в параметре
        }*/

        public void GetAtRef(ref Node node, int key)
        {
            for (int i = 0; i < nodes.Length; i++)
            {
                Node temp = nodes[i].Children.Search(key);
                node.Text = temp != null ? temp.Text : node.Text ;
            }
        }

        public void GetAtOut(out Node node, int key)
        {
            node = null;
            for (int i = 0; i < nodes.Length; i++)
                node = nodes[i].Children.Search(key);
        }

        //TODO [VLAD] Я в комментах к этому методу(ниже) написал в чем главная разница между ref и out (можешь глянуть видосик сереги https://youtu.be/4Z6e-qwK_Wc, )
        //Проблема в том, что GetAt(ref Node[] node, int index)
        //                  и
        //                    GetAt(out Node[] node, int index)
        //                  не могут существовать вместе (они не считаются перегрузками)
        //Нужно как-то показать эту разницу. Можешь, к примеру, с параметрами поиграться, типа убрать или добавить что-то => получится перегрузка

        /*public Node GetAt(out Node[] node, int index)
        {
            node = null; // переприсваивание внутри метода обязательно для out-параметра + null присваивается самой ссылке, то есть NodeList nodes - будет уничтожен.

            return nodes[index];
        }
*/



        public void PrintChildren(int index)
        {
            if (nodes[index] != null)
            {
                Console.WriteLine(nodes[index].Text);
            }
            
        }

    }
}
