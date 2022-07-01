using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Translator
    {
        private Dictionary<string, string> vocabluary;
        private string text;
        private string pathToText;
        private string pathToDictionary;
        private int countVariedle = 3;

        public Translator() : this(@"../../../Text.txt", @"../../../Dictionary.txt")
        {

        }

        public Translator(string pathToText, string pathToDictionary)
        {
            vocabluary = new Dictionary<string, string>();
            text = "";
            this.pathToText = pathToText;
            this.pathToDictionary = pathToDictionary;
        }

        public Translator(Dictionary<string, string> vocabluary, string text, string pathToText, string pathToDictionary)
        {
            this.pathToText = pathToText;
            this.pathToDictionary = pathToDictionary;
            this.vocabluary = vocabluary;
            this.text = text;
        }

        public void AddText(string text)
        {
            this.text += text;
        }

        public void AddDictionary(Dictionary<string, string> dictionary)
        {
            this.vocabluary = dictionary;
        }

        public string ChangeWords()
        {
            string result = "";
            var words = text.Split(' ');
            foreach (string word in words)
            {
                bool isFirstUpper = false;
                char temp = ' ';
                string tempWord = "";
                int i = 0;
                if (word.Length > 0)
                {
                    isFirstUpper = char.IsUpper(word[0]);
                    
                    if ((word.Length == 1)&&(Char.IsPunctuation(word[0])))
                        tempWord = word;
                    else if (Char.IsPunctuation(word[word.Length - 1]))
                    {
                        temp = word[word.Length - 1];
                        while (!vocabluary.ContainsKey(word[0..^1].ToLower()) && i < countVariedle)
                        {
                            AddToDictionary(word[0..^1]);
                            i++;
                        }
                        
                        tempWord = vocabluary[word[0..^1].ToLower()] + temp;
                    }
                    else
                    {
                        while (!vocabluary.ContainsKey(word.ToLower()) && i < countVariedle)
                        {
                            AddToDictionary(word);
                            i++;
                        }
                        tempWord = vocabluary[word.ToLower()];
                    }
                }
                if (isFirstUpper)
                    result += char.ToUpper(tempWord[0]) + tempWord[1..] + " ";
                else
                    result += tempWord + " ";
            }
            return result;
        }

        private void AddToDictionary(string word)
        {
            word = word.ToLower();
            Console.WriteLine($"Введiть замiну для слова {word}");
            string value = Console.ReadLine();
            vocabluary.Add(word, value);
            Reader.WriteToDictionary(word, value, @"../../../Dictionary.txt");
        }
    }
}
