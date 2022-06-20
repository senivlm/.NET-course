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
            Storage storage = new Storage();
            StreamReader reader = null;
            StreamWriter writer = null;
            bool successfulRead = false;
            for (int i = 0; i < 3 && !successfulRead; i++)
            {
                try
                {
                    if (readerName == "")
                        throw new FileNotFoundException();
                    reader = new StreamReader(readerName);
                    writer = new StreamWriter(errorRegistrationName, true);
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
       // Цей метод теж можна подати як декоруючий
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
        static public void EditInvalidData(DateTime dateTime, Storage storage)
        {
            StreamReader reader = new StreamReader(StorageText.errorRegistrationName);
            while (!reader.EndOfStream)
            {
                string str = reader.ReadLine();
                char[] delim = { ' ', ':', '.' };
                string[] arr = str.Split(delim, 7);
                DateTime dateOfRecord = new DateTime(Int32.Parse(arr[2]), Int32.Parse(arr[1]), Int32.Parse(arr[0]),
                    Int32.Parse(arr[3]), Int32.Parse(arr[4]), Int32.Parse(arr[5]));


                if (dateOfRecord > dateTime)
                {
                    Console.WriteLine("Please, enter this product correctly:\n" + arr[6]);
                    bool successfulRead = false;

                    str = Console.ReadLine();

                    for (int j = 0; j < 2 && !successfulRead; j++)
                    {
                        try
                        {
                            arr = str.Split(' ', 2);
                            Product p = null;
                            if (arr[0] == "d")
                            {
                                p = new DairyProduct();
                            }
                            else if (arr[0] == "m")
                            {
                                p = new Meat();
                            }
                            else
                                throw new Exception();
                            p.Read(arr[1]);
                            successfulRead = true;
                            storage.AddProduct(p);
                        }
                        catch
                        {
                            Console.WriteLine($"Invalid data! You have {2 - j} new attemps. Try to enter one more time");
                            str = Console.ReadLine();
                        }
                    }
                }
            }
        }
    }
}
