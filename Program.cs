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

         string stroka = null;
         string[] arrayString = { };
         FileStream filestream = File.Open(path, FileMode.Open, FileAccess.Read);
         if (filestream == null || filestream.Length == 0)
         {
            Console.WriteLine("Ошибка при открытии файла для чтения");
         }
         else
         {
            StreamReader streamReader = new StreamReader(filestream, Encoding.UTF8);
            while (streamReader.Peek() >= 0)
            {
               stroka = streamReader.ReadLine();
               Console.WriteLine(stroka);
            }

            // Определение количества столбцов в строке разделением строки на подстроки по пробелу
            // Символ пробела
            char symbolSpace = ' ';
            // Счетчик символов
            int symbolСount = 0;
            // Количество столбцов в строке
            int сolumn = 0;
            if (stroka != null)
            {
               //Console.WriteLine("Исходный строковый массив {0}:", nameArray);
               //Console.WriteLine(stroka);
               while (symbolСount < stroka.Length)
               {
                  if (symbolSpace == stroka[symbolСount])
                  {
                     сolumn++;
                  }

                  if (symbolСount == stroka.Length - 1)
                  {
                     сolumn++;
                  }

                  symbolСount++;
               }

               //Console.WriteLine("Количество столбцов {0}:", сolumn);

               // Разделение строки на подстроки по пробелу и конвертация подстрок в double
               //Console.WriteLine("Массив вещественных чисел {0}:", nameArray);
               // Одномерный массив вещественных чисел
               arrayString = new string[сolumn];
               // Построитель строк
               StringBuilder stringModified = new StringBuilder();
               // Счетчик символов обнуляем
               symbolСount = 0;
               // Количество столбцов в строке обнуляем
               сolumn = 0;
               while (symbolСount < stroka.Length)
               {
                  if (symbolSpace != stroka[symbolСount])
                  {
                     stringModified.Append(stroka[symbolСount]);
                  }
                  else
                  {
                     string subLine = stringModified.ToString();
                     arrayString[сolumn] = subLine;
                     //Console.Write(arrayDouble[сolumn] + " ");
                     stringModified.Clear();
                     сolumn++;
                  }

                  if (symbolСount == stroka.Length - 1)
                  {
                     string subLine = stringModified.ToString();
                     arrayString[сolumn] = subLine;
                     //Console.Write(arrayDouble[сolumn]);
                     stringModified.Clear();
                     сolumn++;
                  }

                  symbolСount++;
               }
            }

            streamReader.Close();
            //Console.WriteLine();
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