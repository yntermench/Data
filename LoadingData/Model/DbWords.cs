using System.Collections.Generic;
using System.Linq;

namespace LoadData.Model
{
    public class DbWords
    {
        static private void AddDbWord(List<Word> wordsSelected, int i, ApplicationDbContext context)
        {
            context.Words.Add(wordsSelected[i]);
            context.SaveChanges();
        }
        static public void SelectionDbWords(List<Word> wordsSelected, ApplicationDbContext context)
        {
            for (int i = 0; i < wordsSelected.Count(); i++)
            {
                if (context.Words != null)
                {
                    bool isFound = false;
                    foreach (Word wordContext in context.Words.ToList())
                    {
                        if (wordContext.Content == wordsSelected[i].Content)
                        {
                            wordContext.AmountMentions += wordsSelected[i].AmountMentions;
                            context.Words.Update(wordContext);
                            context.SaveChanges();
                            isFound = true;
                            break;
                        }
                    }

                    if (isFound == true)
                    {
                        continue;
                    }
                    else
                    {
                        AddDbWord(wordsSelected, i, context);
                    }
                }
                else
                {
                    AddDbWord(wordsSelected, i, context);
                }
            }
        }
    }
}
