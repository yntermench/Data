using LoadData.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Uploading_Data.Model
{
    public class WordSearch
    {
        private static List<Word> GetSortWords(string str, ApplicationDbContext context)
        {
            IQueryable<Word> words = context.Words;
            List<Word> foundWords = words.Where(w => w.Content.StartsWith(str)).ToList();
            return foundWords;
        }
        private static List<Word> SortWordsEqual(List<Word> foundWords)
        {
            List<Word> sortedWords = foundWords.OrderByDescending(w => w.AmountMentions).ThenBy(w => w.Content).ToList();
            return sortedWords;
        }
        public static List<string> SearchWordsDb(string str, ApplicationDbContext context)
        {
            if (context.Words.Count() != 0)
            {
                List<Word> tempWords = GetSortWords(str, context);
                List<Word> sortWords = SortWordsEqual(tempWords);
                List<string> words = sortWords.Select(w => w.Content).Take(5).ToList();
                return words;
            }
            else
            {
                Console.WriteLine("База данных не заполнена для поиска слов");
                Console.ReadLine();
                return null;
            }
        }

    }
}
