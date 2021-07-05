using System.Collections.Generic;

namespace LoadData.Model
{
    public class TempWords
    {
        static private List<Word> AddTempWord(string content, List<Word> words)
        {
            Word word = new Word
            {
                Content = content,
                AmountMentions = 1
            };

            words.Add(word);
            return words;
        }

        static public List<Word> SelectionTempWords(List<Word> wordsTemp, string[] text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].Length >= 3 && text[i].Length <= 20)
                {
                    if (wordsTemp != null)
                    {
                        bool isFound = false;
                        foreach (Word word in wordsTemp)
                        {
                            if (word.Content == text[i])
                            {
                                word.AmountMentions += 1;
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
                            AddTempWord(text[i], wordsTemp);
                        }
                    }
                    else
                    {
                        AddTempWord(text[i], wordsTemp);
                    }
                }
            }

            return wordsTemp;
        }
    }
}
