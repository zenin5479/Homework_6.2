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

         string oldWord = "один";
         string newWord = "два";
         string[] result = ReplaceWord(pathEnter, oldWord, newWord);
         InputArrayString(result);

         Console.ReadKey();
      }

      public static string[] ReplaceWord(string path, string oldWord, string newWord)
      {
         // Одномерный массив строк
         string[] arrayString = { };
         // Чтение файла за одну операцию
         string[] allLines = File.ReadAllLines(path);
         if (allLines == null)
         {
            Console.WriteLine("Ошибка при открытии файла для чтения");
         }
         else
         {
            Console.WriteLine("Исходный массив строк");
            int indexLines = 0;
            while (indexLines < allLines.Length)
            {
               allLines[indexLines] = allLines[indexLines];
               Console.WriteLine(allLines[indexLines]);
               indexLines++;
            }

            // Разделение строки на подстроки по пробелу для определения количества столбцов в строке
            int[] sizeArray = new int[allLines.Length];
            char symbolSpace = ' ';
            int countRow = 0;
            int countSymbol = 0;
            int countСolumn = 0;
            while (countRow < allLines.Length)
            {
               string line = allLines[countRow];
               while (countSymbol < line.Length)
               {
                  if (symbolSpace == line[countSymbol])
                  {
                     countСolumn++;
                  }

                  if (countSymbol == line.Length - 1)
                  {
                     countСolumn++;
                  }

                  countSymbol++;
               }

               sizeArray[countRow] = countСolumn;
               Console.WriteLine("В строке {0} количество столбцов {1}", countRow, countСolumn);
               countСolumn = 0;
               countRow++;
               countSymbol = 0;
            }

            // Поиск максимального и минимального элемента массива
            // Cчитаем, что максимум - это первый элемент массива
            int max = sizeArray[0];
            // Cчитаем, что минимум - это первый элемент массива
            int min = sizeArray[0];
            int columns = 0;
            while (columns < sizeArray.Length)
            {
               if (max < sizeArray[columns])
               {
                  max = sizeArray[columns];
               }

               if (min > sizeArray[columns])
               {
                  min = sizeArray[columns];
               }

               columns++;
            }
            Console.WriteLine("Максимум равен: {0}", max);
            Console.WriteLine("Минимум равен: {0}", min);

            //
            // Разделение строки на подстроки по пробелу и конвертация подстрок в double
            Console.WriteLine("Одномерный строковый массив");
            StringBuilder stringModified = new StringBuilder();
            arrayString = new string[allLines.Length];
            string[] arrayLine = new string[sizeArray];
            char spaceCharacter = ' ';
            int row = 0;
            int column = 0;
            int countCharacter = 0;

            string lines = allLines[row];
            while (column < sizeArray)
            {
               while (countCharacter < lines.Length)
               {
                  if (spaceCharacter == lines[countCharacter])
                  {
                     string subLine = stringModified.ToString();
                     arrayLine[column] = subLine;
                     Console.Write(arrayLine[column] + " "); // ?
                     stringModified.Clear();
                     column++;
                  }
                  else
                  {
                     stringModified.Append(lines[countCharacter]);
                  }

                  if (countCharacter == lines.Length - 1)
                  {
                     string subLine = stringModified.ToString();
                     arrayLine[column] = subLine;
                     Console.Write(arrayLine[column]);
                     stringModified.Clear();
                     column++;
                  }

                  countCharacter++;
               }
               Array.Clear(arrayLine, 0, arrayLine.Length);
               countCharacter = 0;
            }
            Console.WriteLine();
         }

         return arrayString;
      }

      public static void InputArrayString(string[] inputArray)
      {
         Console.WriteLine("Массив строк:");
         int i = 0;
         while (i < inputArray.Length)
         {
            Console.Write(inputArray[i]);
            i++;
         }

         Console.WriteLine();
      }
   }
}