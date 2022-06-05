using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Work_with_text
{
    internal class Text
    {
        //static char[] sentenceDelims = { '.', '!', '?' };
        static char[] wordsDelims = { ',', '-', ':', '.', '!', '?' };
        public static Paragraph ReadSentences(StreamReader reader)
        {
            string str = reader.ReadLine();
            while (!reader.EndOfStream)
            {
                str += reader.ReadLine();
            }
            string[] arr = Regex.Split(str, @"(?<=[.!?])", RegexOptions.IgnorePatternWhitespace).Where(s => s != String.Empty).ToArray<string>();
            for (int i = 0; i < arr.Length; i++)
                arr[i] = arr[i].Trim();
            return new Paragraph(arr);

        }
        public static Sentence SplitWords(string sentence)
        {
            foreach (char delim in wordsDelims)
            {
                sentence = sentence.Replace(delim.ToString(), string.Empty);
            }
            return new Sentence(sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries));
        }

        public static string MaxString(string[] arr)
        {
            return arr.Where(s => s.Length == arr.Max(i => i.Length)).ToList()[0];
        }
        public static string MinString(string[] arr)
        {
            return arr.Where(s => s.Length == arr.Min(i => i.Length)).ToList()[0];
        }
        public static string ToString(string[] arr)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string str in arr)
                sb.Append(str + "\n");
            return sb.ToString();
        }
        public static void WriteToFile(StreamWriter writer, string[] arr)
        {
            foreach (var item in arr)
            {
                writer.WriteLine(item);
            }
            
        }
    }

    
}
