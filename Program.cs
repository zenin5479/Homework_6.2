using System;
using System.IO;

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
         Console.WriteLine(text);
         string oldWord = "Привет";
         string newWord = "Здравствуй";
         string[] result = ReplaceWord(pathEnter, oldWord, newWord);
         Console.WriteLine(result);

         Console.ReadKey();
      }

      public static string[] ReplaceWord(string path, string oldWord, string newWord)
      {
         
         
         
         return new string[] { };
      }
   }
}