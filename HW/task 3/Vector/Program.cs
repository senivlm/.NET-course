using System;

namespace Vector
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrr = { 1, 2, 3, 3, 3, 3, 2, 2, 0, 0, 0, 0, 0 };
            Vector arr = new Vector(arrr);
            //arr.InitShuffle();
            Console.WriteLine(arr);
            Console.WriteLine(arr.Subsequence());
            Console.WriteLine(arr);

            //Console.WriteLine( arr.IsPalindrom());
            /*try
            {
                arr[0] = 999;
                Console.WriteLine(arr[21]);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }*/


            /*            Pair[] pairs = arr.CalculateFreq();

                        for (int i = 0; i < pairs.Length; i++)
                        {
                            Console.Write(pairs[i] + "\n"); 
                        }
                        Console.WriteLine();*/

            //Console.WriteLine(pairs);
            //arr.RandomInitialization();
            //Console.WriteLine(arr);


        }
    }
}
