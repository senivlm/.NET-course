using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    class FileWork //for Vector
    {

        static public void LimitedMemoryMergeSort(string inputFile, string outputFile)
        {
            SplitVector(inputFile, "help_file_1.txt", "help_file_2.txt");
            //Посортуємо кожен з підмасивів
            Vector vector1 = new Vector();
            vector1.ReadFromFile("help_file_1.txt");
            vector1.SplitMergeSort(); //vector1.QuickSort();
            StreamWriter writer = new StreamWriter("help_file_1.txt");
            vector1.WriteToFileColumn(writer);
            writer.Close();

            vector1.ReadFromFile("help_file_2.txt");
            vector1.SplitMergeSort(); //vector1.QuickSort();
            writer = new StreamWriter("help_file_2.txt");
            vector1.WriteToFileColumn(writer);
            writer.Close();

            //фінальне злиття
            MergeWithFiles("help_file_1.txt", "help_file_2.txt", outputFile);
        }
        static public void SplitVector(string inputFile, string outFile1, string outFile2)//розділяємо  вектор на два файли
        {

            StreamReader reader1 = new StreamReader(inputFile);
            string line = reader1.ReadLine();
            string[] numbers = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            StreamWriter writer = new StreamWriter(outFile1);
            for (int i = 0; i < numbers.Length / 2; i++)
            {
                writer.Write(numbers[i] + " ");
            }
            writer.Close();
            writer = new StreamWriter(outFile2);
            for (int i = numbers.Length / 2; i < numbers.Length; i++)
            {
                writer.Write(numbers[i] + " ");
            }
            writer.Close();
        }
        static private void MergeWithFiles(string file1, string file2, string result)
        {

            StreamReader reader1 = new StreamReader(file1);
            //ці нулі візьмуть вже участь у сортуванні, чого нам не треба!
            int el1 = 0;
            StreamReader reader2 = new StreamReader(file2);
            int el2 = 0;

            StreamWriter writer = new StreamWriter(result);
            while (!reader1.EndOfStream && !reader2.EndOfStream)
            {
                if (el1 < el2)
                {
                    el1 = Int32.Parse(reader1.ReadLine());
                    writer.Write(el1 + " ");
                }
                else
                {
                    el2 = Int32.Parse(reader2.ReadLine());
                    writer.Write(el2 + " ");
                }
            }
            while (!reader1.EndOfStream)
            {
                el1 = Int32.Parse(reader1.ReadLine());
                writer.Write(el1 + " ");
            }
            while (!reader2.EndOfStream)
            {
                el2 = Int32.Parse(reader2.ReadLine());
                writer.Write(el2 + " ");
            }
            writer.Close();
        }
    }
}
