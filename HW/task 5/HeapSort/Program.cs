using System;

namespace Vector
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Vector vector = new Vector(15);
            vector.RandomInitialization(0, 30);
            Console.WriteLine(vector);
            vector.HeapSort();
            Console.WriteLine(vector);



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
