


using System;
using System.IO;
using LibraryForStrings;

// Обработка текста
// Дан текст. Текст разбит на слова, предполагается, что слово – это группа символов,
// не содержащая пробелов и отделённая пробелами от других слов
// Текст может содержать и несколько предложений, признаком конца предложения является точка
// Составить программу для обработки текстовой информации по поставленному условию
// Каждое слово "один" заменить на "второй"
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

         string[,] enterArray = VariousMethods.EnterArrayString(pathEnter);
         Console.WriteLine();
         string oldWord = "один";
         string newWord = "второй";
         string[,] replaceArray = VariousMethods.ReplaceWord(enterArray, oldWord, newWord);
         Console.WriteLine();
         string[] intermediate = VariousMethods.OutputArrayString(replaceArray);
         VariousMethods.FileWriteArrayString(pathIntermediate, intermediate, intermediateFile);
         Console.WriteLine();

         string mostVowels = VariousMethods.FindWordWithMostVowels(replaceArray);
         string inputVowels = "Слово с наибольшим количеством гласных: " + mostVowels;
         Console.WriteLine(inputVowels);
         VariousMethods.FileWriteArrayString(pathInput, inputVowels);

         Console.ReadKey();
      }
   }
}