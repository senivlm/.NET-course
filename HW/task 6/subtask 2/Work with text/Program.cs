using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Work_with_text
{//Не знайшла 1 завдання
   
    class Program
    {
        static void Main(string[] args)
        {
            Paragraph paragraph;
            using (StreamReader reader = new StreamReader(@"D:\.NET course\Work with text\Work with text\input.txt"))
            {
                paragraph = Text.ReadSentences(reader);

            }
            Console.WriteLine(paragraph);

            foreach (string s in paragraph.Sentences)
            {
                Text.SplitWords(s);
            }

            Console.WriteLine("Min words:");
            Console.WriteLine(paragraph.MinLengthWords());
            Console.WriteLine("Max words:");
            Console.WriteLine(paragraph.MaxLengthWords());

            using (StreamWriter writer = new StreamWriter(@"D:\.NET course\Work with text\Work with text\output.txt"))
            {
                Text.WriteToFile(writer, paragraph.Sentences);
            }


        }



    }
    
}
