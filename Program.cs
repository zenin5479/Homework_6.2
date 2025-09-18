using System;
using System.Globalization;
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
   internal class InputArrayDouble
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
         string[,] result = ReplaceWord(pathEnter, oldWord, newWord);
         InputArrayString(result);

         Console.ReadKey();
      }

      public static string[,] ReplaceWord(string path, string oldWord, string newWord)
      {
         // Одномерный массив строк
         string[,] arrayString = { };
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

            // Поиск максимального элемента массива
            // Cчитаем, что максимум - это первый элемент массива
            int max = sizeArray[0];
            int columns = 0;
            while (columns < sizeArray.Length)
            {
               if (max < sizeArray[columns])
               {
                  max = sizeArray[columns];
               }

               columns++;
            }

            Console.WriteLine("Максимум равен: {0}", max);

            // Разделение строк на подстроки по пробелу и заполнение двумерного массива строк элементами
            // Измерение массива (0) - количество строк, измерение массива (1) - количество столбцов, равное максимуму
            Console.WriteLine("Двумерный массив строк");
            StringBuilder stringModified = new StringBuilder();
            arrayString = new string[allLines.Length, max];
            char spaceCharacter = ' ';
            int row = 0;
            int column = 0;
            int countCharacter = 0;
            while (row < arrayString.GetLength(0))
            {
               string line = allLines[row];
               while (column < sizeArray[row])
               {
                  while (countCharacter < line.Length)
                  {
                     if (spaceCharacter == line[countCharacter])
                     {
                        string subLine = stringModified.ToString();
                        arrayString[row, column] = subLine;
                        Console.Write(arrayString[row, column] + " ");
                        stringModified.Clear();
                        column++;
                     }
                     else
                     {
                        stringModified.Append(line[countCharacter]);
                     }

                     if (countCharacter == line.Length - 1)
                     {
                        string subLine = stringModified.ToString();
                        arrayString[row, column] = subLine;
                        Console.Write(arrayString[row, column]);
                        stringModified.Clear();
                        column++;
                     }

                     countCharacter++;
                  }

                  countCharacter = 0;
               }

               Console.WriteLine();
               column = 0;
               row++;
            }

            //
            int k = 0;
            int l = 0;
            while (k < arrayString.GetLength(0))
            {
               while (l < arrayString.GetLength(1))
               {
                  // Сравниваем значения string используя метод CompareTo(string) с учетом регистра и текущей культуры
                  if (string.CompareOrdinal(arrayString[k, l], oldWord) == 0)
                  {
                     arrayString[k, l] = newWord;
                  }

                  // Сравниваем значения string используя метод Compare(string) регистрозависим
                  if (string.Compare(arrayString[k, l], oldWord) == 0)
                  {
                     arrayString[k, l] = newWord;
                  }

                  int result1 = string.CompareOrdinal(arrayString[k, l], oldWord); // с учетом регистра и текущей культуры
                  int result2 = string.Compare(arrayString[k, l], oldWord, StringComparison.OrdinalIgnoreCase); // игнорирование регистра
                  int result3 = string.Compare(arrayString[k, l], oldWord, CultureInfo.InvariantCulture, CompareOptions.IgnoreNonSpace); // с указанием культуры и опций


                  // Сравниваем значения string используя метод Compare(string) игнорирование регистра
                  //if (string.Compare(arrayString[k, l], oldWord, StringComparison.OrdinalIgnoreCase) == 0)
                  //{
                  //   arrayString[k, l] = newWord;
                  //}

                  // Сравниваем значения string используя метод Equals(string) регистрозависим
                  //if (Equals(arrayString[k, l], oldWord))
                  //{
                  //   arrayString[k, l] = newWord;
                  //}

                  // Сравниваем значения string используя метод Equals(string) игнорирование регистра
                  //if (string.Equals(arrayString[k, l], oldWord, StringComparison.OrdinalIgnoreCase))
                  //{
                  //   arrayString[k, l] = newWord;
                  //}

                  l++;
               }

               l = 0;
               k++;
            }

            Console.WriteLine();
         }

         return arrayString;
      }

      public static void InputArrayString(string[,] inputArray)
      {
         Console.WriteLine("Двумерный массив строк");
         int i = 0;
         while (i < inputArray.GetLength(0))
         {
            int j = 0;
            while (j < inputArray.GetLength(1))
            {
               if (j == inputArray.GetLength(1) - 1)
               {
                  Console.Write(inputArray[i, j]);
               }
               else
               {
                  Console.Write(inputArray[i, j] + " ");
               }

               j++;
            }

            i++;
            Console.WriteLine();
         }
      }

      public static void InputArrayString(string[] inputArray)
      {
         Console.WriteLine("Одномерный массив строк:");
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