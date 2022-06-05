using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work_with_text
{
    internal class Paragraph
    {
        string[] sentences;
        public string[] Sentences { get { return sentences; } }
        public Paragraph()
        {
            sentences = new string[1];
        }
        public Paragraph(string[] strings)
        {
            sentences = strings;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string str in sentences)
                sb.Append(str + "\n");
            return sb.ToString();
        }
        public Sentence MaxLengthWords()//для кожного речення
        {
            string[] result = new string[sentences.Length];
            for (int i = 0; i < sentences.Length; i++)
            {
                result[i] = Text.MaxString(Text.SplitWords(sentences[i]).Words);
            }
            return new Sentence(result);
        }
        public Sentence MinLengthWords()//для кожного речення
        {
            string[] result = new string[sentences.Length];
            for (int i = 0; i < sentences.Length; i++)
            {
                result[i] = Text.MinString(Text.SplitWords(sentences[i]).Words);
            }
            return new Sentence( result);
        }

    }
}
