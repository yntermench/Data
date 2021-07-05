using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LoadData.Model
{
    public class TextFile
    {
        static private char[] IgnoreSigns { get; } = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '`', '~', '@', '!',
            '"', '#', '№', '%', ':', '^', '?', '&', '*', '(', ')', '-', '_', '=', '+', '\\', '|', '/', '{', '}', '[', ']', ';', '.', '\r','\n', '<', '>', '\'', ',', '…', '«' , '»', ' ', '—'};
        static public string[] LoadTextFile(string path)
        {
            using (StreamReader sr = new StreamReader(path, Encoding.UTF8, false))
            {
                string[] text = sr.ReadToEnd().Split(IgnoreSigns, StringSplitOptions.RemoveEmptyEntries);
                return text;
            }
        }

        public static void RenderWordsFile(ApplicationDbContext repository, string[] text)
        {
            List<Word> wordsTemp = new List<Word>();
            List<Word> wordsDb = TempWords.SelectionTempWords(wordsTemp, text);

            List<Word> wordsSelected = wordsDb.Where(w => w.AmountMentions >= 4).ToList();
            DbWords.SelectionDbWords(wordsSelected, repository);
        }
    }
}
