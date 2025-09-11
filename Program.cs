using System;
using System.IO;
using System.Text;

// Обработка текста
// Дан текст. Текст разбит на слова, предполагается, что слово – это группа символов,
// не содержащая пробелов и отделённая пробелами от других слов
// Текст может содержать и несколько предложений, признаком конца предложения является точка
// Составить программу для обработки текстовой информации по поставленному условию
// Каждое слово "один" заменить на "два"
// Слово с наибольшим количеством гласных

namespace Homework_6._2
{
   internal class Program
   {
      static void Main(string[] args)
      {
         string fileEnter = "parable.txt";
         string pathEnter = Path.GetFullPath(fileEnter);
         string intermediateFile = "intermediate.txt";
         string pathIntermediate = Path.GetFullPath(intermediateFile);
         string fileInput = "finish.txt";
         string pathInput = Path.GetFullPath(fileInput);

         string text = "Привет, мир, добро пожаловать во вселенную. Привет снова!";
         string oldWord = "Привет";
         string newWord = "Здравствуй";
         Console.WriteLine(text);
         string result = ReplaceWord(text, oldWord, newWord);
         Console.WriteLine(result);

         Console.ReadKey();
      }

      public static string ReplaceWord(string input, string oldWord, string newWord)
      {
         // Проверка на пустые входные данные
         if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(oldWord))
            return input;

         StringBuilder result = new StringBuilder();
         int currentIndex = 0;
         int wordLength = oldWord.Length;

         while (currentIndex < input.Length)
         {
            // Поиск следующего вхождения oldWord
            int foundIndex = input.IndexOf(oldWord, currentIndex, StringComparison.Ordinal);
            if (foundIndex == -1)
            {
               // Если вхождений больше нет, добавляем остаток строки и выходим
               result.Append(input, currentIndex, input.Length - currentIndex);
               break;
            }

            // Проверка границ слова
            bool isStartBoundary = foundIndex == 0 || !IsWordChar(input[foundIndex - 1]);
            bool isEndBoundary = foundIndex + wordLength == input.Length || !IsWordChar(input[foundIndex + wordLength]);

            if (isStartBoundary && isEndBoundary)
            {
               // Замена слова
               result.Append(input, currentIndex, foundIndex - currentIndex);
               result.Append(newWord);
               currentIndex = foundIndex + wordLength;
            }
            else
            {
               // Пропускаем неполное совпадение
               result.Append(input, currentIndex, foundIndex - currentIndex + 1);
               currentIndex = foundIndex + 1;
            }
         }

         return result.ToString();
      }

      private static bool IsWordChar(char c)
      {
         // Проверка, является ли символ частью слова (буква, цифра или underscore)
         return char.IsLetterOrDigit(c) || c == '_';
      }
   }
}