using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work_with_text
{
    internal class Sentence//only words
    {
        string[] words;

        public string[] Words { get { return words; } }
        public Sentence()
        {
            words = new string[1];
        }
        public Sentence(string[] strings)
        {
            words = strings;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string str in words)
                sb.Append(str + "\n");
            return sb.ToString();
        }
    }
}
