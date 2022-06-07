using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1
{
    static internal class StorageText
    {
        static string errorRegistrationName = @"D:\.NET course\task_1\task_1\output.txt";
        static public Storage ReadFromConsole()
        {
            Storage storage = new Storage();
            Console.WriteLine(
                "------------------------------------\n" +
                "Enter products as\n" +
                "d name price weight expiration_days\n" +
                "m name price weight category\n" +
                "To finish inputting enter empty line\n" +
                "------------------------------------");
            string str = Console.ReadLine();
            while (str != "")
            {
                char[] delim = { ' ' };
                string[] arr = str.Split(delim, 2);
                if (arr.Length == 1)
                {
                    Console.WriteLine("Invalid data!");
                    str = Console.ReadLine();
                    continue;
                }
                Product product;
                if (arr[0] == "d")
                {
                    product = new DairyProduct();
                }
                else
                {
                    product = new Meat();
                }
                try
                {
                    product.Read(arr[1]);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid data! " + ex.Message);
                }
                storage.AddProduct(product);
                str = Console.ReadLine();
            }
            return storage;
        }
        static public void WriteToConsole(Storage storage)
        {
            foreach (var item in storage.Products)
            {
                Console.WriteLine(item);
            }
        }
        static public Storage ReadFromFile()
        {
            Console.WriteLine("Enter input file");
            string readerName = Console.ReadLine();
            bool successfulRead = false;
            Storage storage = new Storage();
            StreamReader reader = null;
            StreamWriter writer = null;
            for (int i = 0; i < 3 && !successfulRead; i++)
            {
                try
                {
                    if (readerName == "")
                        throw new FileNotFoundException();
                    reader = new StreamReader(readerName);
                    writer = new StreamWriter(errorRegistrationName);
                    successfulRead = true;
                    storage = StorageText.ReadFromStreamReader(reader, writer);
                    
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine($"File not found, you have {2 - i} attemps to enter new name:");
                    readerName = Console.ReadLine();
                }
                finally
                {
                    if (reader != null)
                        reader.Close();
                    if (writer != null)
                        writer.Close();
                }

            }

            return (storage);

        }
        static public Storage ReadFromStreamReader(StreamReader reader, StreamWriter errorRegistration)
        {
            Storage storage = new Storage();
            while (!reader.EndOfStream)
            {
                string str = reader.ReadLine();

                char[] delim = { ' ' };
                string[] arr = str.Split(delim, 2);
                if (arr.Length == 1)
                {
                    errorRegistration.WriteLine(DateTime.Now + " " + str);
                    str = reader.ReadLine();
                    continue;
                }
                Product product;
                try
                {
                    if (arr[0] == "d")
                    {
                        product = new DairyProduct();
                    }
                    else if (arr[0] == "m")
                    {
                        product = new Meat();
                    }
                    else throw new Exception("invalid type");
                    product.Read(arr[1]);
                    storage.AddProduct(product);
                }
                catch (Exception ex)
                {
                    errorRegistration.WriteLine(DateTime.Now + " " + str);
                }
            }
            return storage ;
        }
        static public void EditInvalidData(DateTime dateTime)
        {
            StreamReader reader = new StreamReader(StorageText.errorRegistrationName);
            string str = reader.ReadLine();
            char[] delim = { ' ' , ':', '.'};
            string[] arr = str.Split(delim, 7);
            DateTime dateOfRecord = new DateTime(Int32.Parse(arr[2]), Int32.Parse(arr[1]), Int32.Parse(arr[0]),
                Int32.Parse(arr[3]), Int32.Parse(arr[4]), Int32.Parse(arr[5]));
            /*if (dateOfRecord > dateTime)
            {
                Console.WriteLine("Please, enter this product correctly:\n" + arr[6]);
                try
                {
                    //розібратись із створенням нового продукту зі стрічки і додати тільки якщо введений правильно
                }
            }*/
        }
    }
}
