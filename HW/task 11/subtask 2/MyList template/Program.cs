namespace ASDF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyList<int> myList = new MyList<int>() { 2, 3, 6, 1, 4, 5 };
            Console.WriteLine(myList);
            Console.WriteLine( myList.FindIndex(2, new Comparer()));

            //MyList list = new MyList(1, 3, 4, 5, 2, 9);
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine();
            //Console.WriteLine( list.FindIndex(6));
            //myList.Sort();
            //Console.WriteLine(myList);
            //Console.WriteLine(myList.FindIndex(3));
        }
    }
}