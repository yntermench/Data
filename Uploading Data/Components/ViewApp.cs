using System;
using System.Collections.Generic;

namespace Uploading_Data.Components
{
    public class ViewApp
    {
        static public string Start()
        {
            Console.Write("Введите строку, с которой должны начинаться слова: ");
            string str = Console.ReadLine();
            return str;
        }

        static public void Finish(bool isFind, int count, List<string> words)
        {
            if (isFind)
            {
                Console.WriteLine("Слова были найдены!");
                Console.WriteLine($"Количество найденных слов: {count}");
                Console.WriteLine("Слова: ");
                foreach (var word in words)
                {
                    Console.WriteLine($"{word}");
                }
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Слова, которые начинаются на такую строку не найдены");
                Console.ReadLine();
            }
        }
    }
}
