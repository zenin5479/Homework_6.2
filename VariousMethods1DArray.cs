using System;
using System.IO;
using System.Text;

namespace Homework_6._2
{
   public class MethodsFor1DArray
   {
      public static int EnterSetValue()
      {
         int v;
         do
         {
            Console.WriteLine("Введите значение элемента:");
            int.TryParse(Console.ReadLine(), out v);
            //v = Convert.ToInt32(Console.ReadLine());
            if (v <= -100 || v >= 100)
            {
               Console.WriteLine("Введено не верное значение");
            }
         } while (v <= -100 || v >= 100);

         return v;
      }

      public static int NumberArrayElements()
      {
         int n;
         do
         {
            Console.WriteLine("Введите количество элементов массива:");
            int.TryParse(Console.ReadLine(), out n);
            //n = Convert.ToInt32(Console.ReadLine());
            if (n <= 0 || n > 20)
            {
               Console.WriteLine("Введено не верное значение");
            }
         } while (n <= 0 || n > 20);

         return n;
      }

      public static int NumberArrayElements(string nameArray)
      {
         int n;
         do
         {
            Console.WriteLine("Введите количество элементов массива {0}:", nameArray);
            int.TryParse(Console.ReadLine(), out n);
            //n = Convert.ToInt32(Console.ReadLine());
            if (n <= 0 || n > 20)
            {
               Console.WriteLine("Введено не верное значение");
            }
         } while (n <= 0 || n > 20);

         return n;
      }

      public static int[] EnterArrayInt(string path)
      {
         string stroka = null;
         int[] arrayInt = { };
         FileStream filestream = File.Open(path, FileMode.Open, FileAccess.Read);
         if (filestream == null || filestream.Length == 0)
         {
            Console.WriteLine("Ошибка при открытии файла для чтения");
         }
         else
         {
            StreamReader streamReader = new StreamReader(filestream);
            while (streamReader.Peek() >= 0)
            {
               stroka = streamReader.ReadLine();
               //Console.WriteLine(stroka);
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
               //Console.WriteLine("Исходный строковый массив:");
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

               //Console.WriteLine("Количество столбцов {0}", сolumn);

               // Разделение строки на подстроки по пробелу и конвертация подстрок в int
               //Console.WriteLine("Одномерный целочисленный массив:");
               // Одномерный целочисленный массив
               arrayInt = new int[сolumn];
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
                     arrayInt[сolumn] = Convert.ToInt32(subLine);
                     //Console.Write(arrayInt[сolumn] + " ");
                     stringModified.Clear();
                     сolumn++;
                  }

                  if (symbolСount == stroka.Length - 1)
                  {
                     string subLine = stringModified.ToString();
                     arrayInt[сolumn] = Convert.ToInt32(subLine);
                     //Console.Write(arrayInt[сolumn]);
                     stringModified.Clear();
                     сolumn++;
                  }

                  symbolСount++;
               }
            }

            streamReader.Close();
            //Console.WriteLine();
         }

         return arrayInt;
      }

      public static double[] EnterArrayDouble(string path)
      {
         string stroka = null;
         double[] arrayDouble = { };
         FileStream filestream = File.Open(path, FileMode.Open, FileAccess.Read);
         if (filestream == null || filestream.Length == 0)
         {
            Console.WriteLine("Ошибка при открытии файла для чтения");
         }
         else
         {
            StreamReader streamReader = new StreamReader(filestream);
            while (streamReader.Peek() >= 0)
            {
               stroka = streamReader.ReadLine();
               //Console.WriteLine(stroka);
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
               Console.WriteLine("Исходный строковый массив:");
               Console.WriteLine(stroka);
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

               //Console.WriteLine("Количество столбцов {0}", сolumn);

               // Разделение строки на подстроки по пробелу и конвертация подстрок в double
               Console.WriteLine("Массив вещественных чисел:");
               // Одномерный массив вещественных чисел
               arrayDouble = new double[сolumn];
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
                     arrayDouble[сolumn] = Convert.ToDouble(subLine);
                     Console.Write(arrayDouble[сolumn] + " ");
                     stringModified.Clear();
                     сolumn++;
                  }

                  if (symbolСount == stroka.Length - 1)
                  {
                     string subLine = stringModified.ToString();
                     arrayDouble[сolumn] = Convert.ToDouble(subLine);
                     Console.Write(arrayDouble[сolumn]);
                     stringModified.Clear();
                     сolumn++;
                  }

                  symbolСount++;
               }
            }

            streamReader.Close();
            Console.WriteLine();
         }

         return arrayDouble;
      }

      public static double[] EnterArrayDouble(string path, string nameArray)
      {
         string stroka = null;
         double[] arrayDouble = { };
         FileStream filestream = File.Open(path, FileMode.Open, FileAccess.Read);
         if (filestream == null || filestream.Length == 0)
         {
            Console.WriteLine("Ошибка при открытии файла для чтения");
         }
         else
         {
            StreamReader streamReader = new StreamReader(filestream);
            while (streamReader.Peek() >= 0)
            {
               stroka = streamReader.ReadLine();
               //Console.WriteLine(stroka);
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
               arrayDouble = new double[сolumn];
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
                     arrayDouble[сolumn] = Convert.ToDouble(subLine);
                     //Console.Write(arrayDouble[сolumn] + " ");
                     stringModified.Clear();
                     сolumn++;
                  }

                  if (symbolСount == stroka.Length - 1)
                  {
                     string subLine = stringModified.ToString();
                     arrayDouble[сolumn] = Convert.ToDouble(subLine);
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

         return arrayDouble;
      }

      public static int[] InputArrayInt(int[] inputArray, int n)
      {
         Console.WriteLine("Одномерный целочисленный массив для проведения поиска:");
         int[] outputArray = new int[n];
         int i = 0;
         while (i < n)
         {
            outputArray[i] = inputArray[i];
            Console.Write("{0} ", outputArray[i]);
            i++;
         }

         Console.WriteLine();
         return outputArray;
      }

      public static double[] InputArrayDouble(double[] inputArray, int n)
      {
         Console.WriteLine("Массив вещественных чисел для проведения поиска:");
         double[] outputArray = new double[n];
         int i = 0;
         while (i < n)
         {
            outputArray[i] = inputArray[i];
            //Console.Write("{0:f2} ", outputArray[i]);
            //Console.Write("{0:f} ", outputArray[i]);
            Console.Write("{0} ", outputArray[i]);
            i++;
         }

         Console.WriteLine();
         return outputArray;
      }

      public static double[] InputArrayDouble(double[] inputArray, int n, string nameArray)
      {
         Console.WriteLine("Одномерный массив вещественных чисел {0}:", nameArray);
         double[] outputArray = new double[n];
         int i = 0;
         while (i < n)
         {
            outputArray[i] = inputArray[i];
            //Console.Write("{0:f2} ", outputArray[i]);
            //Console.Write("{0:f} ", outputArray[i]);
            Console.Write("{0} ", outputArray[i]);
            i++;
         }

         Console.WriteLine();
         return outputArray;
      }

      public static int FindMinNegativeArrayInt(int[] inputArray)
      {
         // Поиск минимального элемента массива среди отрицательных
         // Cчитаем, что минимум - это первый элемент массива
         int min = inputArray[0];
         int column = 0;
         while (column < inputArray.Length)
         {
            if (inputArray[column] < 0)
            {
               if (inputArray[column] < min)
               {
                  min = inputArray[column];
               }
            }

            column++;
         }

         Console.WriteLine("Минимальный элемент массива среди отрицательных: " + min);
         return min;
      }

      public static void FindMaxMinArrayInt(int[] inputArray, out int max, out int min)
      {
         // Поиск максимального и минимального элемента массива
         // Cчитаем, что максимум - это первый элемент массива
         max = inputArray[0];
         // Cчитаем, что минимум - это первый элемент массива
         min = inputArray[0];
         int column = 0;
         while (column < inputArray.Length)
         {
            if (max < inputArray[column])
            {
               max = inputArray[column];
            }

            if (min > inputArray[column])
            {
               min = inputArray[column];
            }

            column++;
         }
         //Console.WriteLine("Максимум равен: {0}", max);
         //Console.WriteLine("Минимум равен: {0}", min);
      }

      public static int FindMaxArrayInt(int[] inputArray)
      {
         // Поиск максимального элемента строки (без флагов bool)
         // Cчитаем, что максимум - это первый элемент строки
         int max = inputArray[0];
         int column = 0;
         while (column < inputArray.Length)
         {
            if (max < inputArray[column])
            {
               max = inputArray[column];
            }

            column++;
         }

         Console.WriteLine("Максимум в массиве равен: {0}", max);
         return max;
      }

      public static double FindMaxArrayDouble(double[] inputArray)
      {
         // Поиск максимального элемента строки (без флагов bool)
         // Cчитаем, что максимум - это первый элемент строки
         double max = inputArray[0];
         int column = 0;
         while (column < inputArray.Length)
         {
            if (max < inputArray[column])
            {
               max = inputArray[column];
            }

            column++;
         }

         Console.WriteLine("Максимум в массиве равен: {0}", max);
         //Console.WriteLine("Максимум в массиве равен: {0:f2}", max);
         return max;
      }

      public static double FindMaxArrayDouble(double[] inputArray, string nameArray)
      {
         // Поиск максимального элемента строки (без флагов bool)
         // Cчитаем, что максимум - это первый элемент строки
         double max = inputArray[0];
         int column = 0;
         while (column < inputArray.Length)
         {
            if (max < inputArray[column])
            {
               max = inputArray[column];
            }

            column++;
         }

         Console.WriteLine("Максимум в массиве {0} равен: {1}", nameArray, max);
         //Console.WriteLine("Максимум в массиве {0} равен: {1:f2}", nameArray, max);
         return max;
      }

      public static int[] ReplacingMaxInt(int[] inputArray, int max)
      {
         int[] outputArray = new int[inputArray.Length];
         int i = 0;
         while (i < inputArray.Length)
         {
            // Сравниваем значения int используя метод CompareTo(Int) 
            if (inputArray[i].CompareTo(max) == 0)
            {
               outputArray[i] = inputArray[i];
            }
            else
            {
               outputArray[i] = i;
            }

            // Сравниваем значения int используя метод Equals(Int)
            //if (inputArray[i].Equals(max))
            //{
            //   outputArray[i] = inputArray[i];
            //}
            //else
            //{
            //   outputArray[i] = i;
            //}

            // Сравниваем значения int используя оператор равенства ==
            //if (inputArray[i] == max)
            //{
            //   outputArray[i] = inputArray[i];
            //}
            //else
            //{
            //   outputArray[i] = i;
            //}

            i++;
         }

         return outputArray;
      }

      public static double[] ReplacingMaxDouble(double[] inputArray, double max)
      {
         double[] outputArray = new double[inputArray.Length];
         int i = 0;
         while (i < inputArray.Length)
         {
            // Сравниваем значения double используя метод CompareTo(Double) 
            if (inputArray[i].CompareTo(max) == 0)
            {
               outputArray[i] = inputArray[i];
            }
            else
            {
               outputArray[i] = i;
            }

            // Сравниваем значения double используя метод Equals(Double)
            //if (inputArray[i].Equals(max))
            //{
            //   outputArray[i] = inputArray[i];
            //}
            //else
            //{
            //   outputArray[i] = i;
            //}

            i++;
         }

         return outputArray;
      }

      public static bool FindZeroInt(int[] inputArray)
      {
         double numbercomparison = 0;
         bool flag = false;
         int i = 0;
         while (i < inputArray.Length && flag == false)
         {
            // Сравниваем значения int используя метод CompareTo(Int) 
            if (inputArray[i].CompareTo(numbercomparison) == 0)
            {
               flag = true;
            }

            // Сравниваем значения int используя оператор равенства ==
            //if (inputArray[i] == 0)
            //{
            //   flag = true;
            //}

            i++;
         }

         if (flag)
         {
            Console.WriteLine("В массиве имеется элемент равный нулю");
         }
         else
         {
            Console.WriteLine("В массиве отсутствует элемент равный нулю");
         }

         return flag;
      }

      public static bool FindZeroInt(int[] inputArray, string nameArray)
      {
         double numbercomparison = 0;
         bool flag = false;
         int i = 0;
         while (i < inputArray.Length && flag == false)
         {
            // Сравниваем значения int используя метод CompareTo(Int) 
            if (inputArray[i].CompareTo(numbercomparison) == 0)
            {
               flag = true;
            }

            // Сравниваем значения int используя оператор равенства ==
            //if (inputArray[i] == 0)
            //{
            //   flag = true;
            //}

            i++;
         }

         if (flag)
         {
            Console.WriteLine("В массиве {0} имеется элемент равный нулю", nameArray);
         }
         else
         {
            Console.WriteLine("В массиве {0} отсутствует элемент равный нулю", nameArray);
         }

         return flag;
      }

      public static bool FindZeroDouble(double[] inputArray)
      {
         double numbercomparison = 0;
         bool flag = false;
         int i = 0;
         while (i < inputArray.Length && flag == false)
         {
            // Сравниваем значения double используя метод CompareTo(Double) 
            if (inputArray[i].CompareTo(numbercomparison) == 0)
            {
               flag = true;
            }

            // Сравниваем значения double используя метод Equals(Double)
            //if (inputArray[i].Equals(numbercomparison))
            //{
            //   flag = true;
            //}

            // Сравниваем значения double используя оператор равенства ==
            //if (inputArray[i] == 0)
            //{
            //   flag = true;
            //}

            i++;
         }

         if (flag)
         {
            Console.WriteLine("В массиве имеется элемент равный нулю");
         }
         else
         {
            Console.WriteLine("В массиве отсутствует элемент равный нулю");
         }

         return flag;
      }

      public static bool FindZeroDouble(double[] inputArray, string nameArray)
      {
         double numbercomparison = 0;
         bool flag = false;
         int i = 0;
         while (i < inputArray.Length && flag == false)
         {
            // Сравниваем значения double используя метод CompareTo(Double) 
            if (inputArray[i].CompareTo(numbercomparison) == 0)
            {
               flag = true;
            }

            // Сравниваем значения double используя метод Equals(Double)
            //if (inputArray[i].Equals(numbercomparison))
            //{
            //   flag = true;
            //}

            // Сравниваем значения double используя оператор равенства ==
            //if (inputArray[i] == 0)
            //{
            //   flag = true;
            //}

            i++;
         }

         if (flag)
         {
            Console.WriteLine("В массиве {0} имеется элемент равный нулю", nameArray);
         }
         else
         {
            Console.WriteLine("В массиве {0} отсутствует элемент равный нулю", nameArray);
         }

         return flag;
      }

      public static int[] ReplacingZeroInt(int[] inputArray)
      {
         int numbercomparison = 0;
         int i = 0;
         while (i < inputArray.Length)
         {
            // Сравниваем значения int используя метод CompareTo(Int) 
            if (inputArray[i].CompareTo(numbercomparison) < 0)
            {
               inputArray[i] = i;
            }

            // Сравниваем значения int используя оператор равенства ==
            if (inputArray[i] == numbercomparison)
            {
               inputArray[i] = i;
            }

            i++;
         }

         return inputArray;
      }

      public static double[] ReplacingZeroDouble(double[] inputArray)
      {
         double numbercomparison = 0;
         int i = 0;
         while (i < inputArray.Length)
         {
            // Сравниваем значения double используя метод CompareTo(Double) 
            if (inputArray[i].CompareTo(numbercomparison) == 0)
            {
               inputArray[i] = i;
            }

            // Сравниваем значения double используя оператор равенства ==
            //if (inputArray[i] == numbercomparison)
            //{
            //   inputArray[i] = i;
            //}

            i++;
         }

         return inputArray;
      }

      public static bool CheckSetValue(int[] inputArray, int setValue)
      {
         // Проверка наличия элемента в массиве
         int i = 0;
         bool fl = true;
         while (i < inputArray.Length && fl)
         {
            if (inputArray[i] == setValue)
            {
               fl = false;
            }
            else
            {
               i++;
            }
         }
         return fl;
      }

      public static int SearchingLastSetValue(int[] inputArray, int setValue)
      {
         // Поиск элемента строки обход массива с последнего элемента
         int i = inputArray.Length - 1;
         while (i >= 0)
         {
            // Сравниваем значения int используя оператор равенства ==
            if (inputArray[i] == setValue)
            {
               Console.WriteLine("В массиве найден элемент {0} по индексу: {1}", setValue, i);
               return i;
            }

            i--;
         }

         Console.WriteLine("В массиве отсутствует элемент: {0}", setValue);
         return -1;
      }

      public static int SearchingNullInt(int[] inputArray)
      {
         double numbercomparison = 0;
         int count = 0;
         int i = 0;
         while (i < inputArray.Length)
         {
            // Сравниваем значения int используя метод CompareTo(Int) 
            if (inputArray[i].CompareTo(numbercomparison) == 0)
            {
               count++;
            }

            // Сравниваем значения int используя оператор равенства ==
            //if (inputArray[i] == 0)
            //{
            //   count++;
            //}

            i++;
         }

         if (count != 0)
         {
            Console.WriteLine("В массиве элементов равных нулю: {0}", count);
         }
         else
         {
            Console.WriteLine("В массиве нет элементов равных нулю");
         }

         return count;
      }

      public static int SearchingNullDouble(double[] inputArray)
      {
         double numbercomparison = 0;
         int count = 0;
         int i = 0;
         while (i < inputArray.Length)
         {
            // Сравниваем значения double используя метод CompareTo(Double) 
            if (inputArray[i].CompareTo(numbercomparison) == 0)
            {
               count++;
            }

            // Сравниваем значения double используя метод Equals(Double)
            //if (inputArray[i].Equals(numbercomparison))
            //{
            //   count++;
            //}

            // Сравниваем значения double используя оператор равенства ==
            //if (inputArray[i] == 0)
            //{
            //   count++;
            //}

            i++;
         }

         if (count != 0)
         {
            Console.WriteLine("В массиве элементов равных нулю: {0}", count);
         }
         else
         {
            Console.WriteLine("В массиве нет элементов равных нулю");
         }

         return count;
      }

      public static int SearchingNullInt(int[] inputArray, string nameArray)
      {
         double numbercomparison = 0;
         int count = 0;
         int i = 0;
         while (i < inputArray.Length)
         {
            // Сравниваем значения int используя метод CompareTo(Int) 
            if (inputArray[i].CompareTo(numbercomparison) == 0)
            {
               count++;
            }

            // Сравниваем значения int используя оператор равенства ==
            //if (inputArray[i] == 0)
            //{
            //   count++;
            //}

            i++;
         }

         if (count != 0)
         {
            Console.WriteLine("В массиве {0} элементов равных нулю: {1}", nameArray, count);
         }
         else
         {
            Console.WriteLine("В массиве {0} нет элементов равных нулю", nameArray);
         }

         return count;
      }

      public static int SearchingNullDouble(double[] inputArray, string nameArray)
      {
         double numbercomparison = 0;
         int count = 0;
         int i = 0;
         while (i < inputArray.Length)
         {
            // Сравниваем значения double используя метод CompareTo(Double) 
            if (inputArray[i].CompareTo(numbercomparison) == 0)
            {
               count++;
            }

            // Сравниваем значения double используя метод Equals(Double)
            //if (inputArray[i].Equals(numbercomparison))
            //{
            //   count++;
            //}

            // Сравниваем значения double используя оператор равенства ==
            //if (inputArray[i] == 0)
            //{
            //   count++;
            //}

            i++;
         }

         if (count != 0)
         {
            Console.WriteLine("В массиве {0} элементов равных нулю: {1}", nameArray, count);
         }
         else
         {
            Console.WriteLine("В массиве {0} нет элементов равных нулю", nameArray);
         }

         return count;
      }

      public static void ComparisonNull(int a, int b, int c)
      {
         string[] name = { "A", "B", "C" };
         int[] arr = { a, b, c };
         // Поиск минимального элемента строки (без флагов bool)
         int min = arr[0];
         int counter = 0;
         while (counter < arr.Length)
         {
            // Cчитаем, что минимум - это первый элемент строки
            if (arr[counter] < min)
            {
               min = arr[counter];
            }

            counter++;
         }
         Console.WriteLine("Минимум  равен: {0}", min);

         // Проверка массивов на минимум элементов
         counter = 0;
         while (counter < arr.Length)
         {
            // Cчитаем, что минимум - это первый элемент строки
            if (arr[counter] == min)
            {
               Console.WriteLine("В массиве {0} минимальное количество элементов равных нулю: {1}", name[counter], min);
            }

            counter++;
         }
      }

      public static void ComparisonNegative(int a, int b, int c)
      {
         string[] name = { "A", "B", "C" };
         int[] arr = { a, b, c };
         // Поиск минимального элемента строки (без флагов bool)
         int min = arr[0];
         int counter = 0;
         while (counter < arr.Length)
         {
            // Cчитаем, что минимум - это первый элемент строки
            if (arr[counter] < min)
            {
               min = arr[counter];
            }

            counter++;
         }
         Console.WriteLine("Наименьшее количество отрицательных элементов в массивах {0}, {1}, {2} равно: {3}", name[0], name[1], name[2], min);

         // Проверка массивов на минимум элементов
         counter = 0;
         while (counter < arr.Length)
         {
            // Cчитаем, что минимум - это первый элемент строки
            if (arr[counter] == min)
            {
               Console.WriteLine("В массиве {0} наименьшее количество отрицательных элементов", name[counter]);
            }

            counter++;
         }
      }

      public static void ComparisonValue(int a, int b, int c)
      {
         if (a == b && a == c)
         {
            Console.WriteLine("Отрицательных элементов в массивах A, В, С равное количество");
         }
         if (a < b && a < c)
         {
            Console.WriteLine("Отрицательных элементов меньше в массиве A");
         }
         if (b < a && b < c)
         {
            Console.WriteLine("Отрицательных элементов меньше в массиве B");
         }
         if (c < a && c < b)
         {
            Console.WriteLine("Отрицательных элементов меньше в массиве C");
         }
      }

      public static int SearchingNegativeInt(int[] inputArray)
      {
         int count = 0;
         int i = 0;
         while (i < inputArray.Length)
         {
            if (inputArray[i] < 0)
            {
               count++;
            }

            i++;
         }

         Console.WriteLine("В массиве отрицательных элементов: {0}", count);
         if (count == 0)
         {
            Console.WriteLine("В массиве нет отрицательных элементов");
         }

         return count;
      }

      public static int SearchingNegativeDouble(double[] inputArray)
      {
         int count = 0;
         int i = 0;
         while (i < inputArray.Length)
         {
            if (inputArray[i] < 0)
            {
               count++;
            }

            i++;
         }

         Console.WriteLine("В массиве отрицательных элементов: {0}", count);
         if (count == 0)
         {
            Console.WriteLine("В массиве нет отрицательных элементов");
         }

         return count;
      }

      public static int SearchingNegativeDouble(double[] inputArray, string nameArray)
      {
         int count = 0;
         int i = 0;
         while (i < inputArray.Length)
         {
            if (inputArray[i] < 0)
            {
               count++;
            }

            i++;
         }

         Console.WriteLine("В одномерном массиве {0} отрицательных элементов: {1}", nameArray, count);
         if (count == 0)
         {
            Console.WriteLine("В одномерном массиве {0} нет отрицательных элементов", nameArray);
         }

         return count;
      }

      public static bool ComparisonNegativeDouble(double negativeOne, double negativeTwo)
      {
         return negativeOne > negativeTwo;
      }

      public static int SearchingNegativeInt(int[] inputArray, string nameArray)
      {
         int count = 0;
         int i = 0;
         while (i < inputArray.Length)
         {
            if (inputArray[i] < 0)
            {
               count++;
            }

            i++;
         }

         Console.WriteLine("В массиве {0} отрицательных элементов: {1}", nameArray, count);
         if (count == 0)
         {
            Console.WriteLine("В массиве {0} нет отрицательных элементов", nameArray);
         }

         return count;
      }

      public static string[] OutputStringArrayInt(int[] inputArray)
      {
         // Объединение одномерного массива int[]
         // в одномерный массив строк string[] для записи в файл (в одну строку массива)
         Console.WriteLine("Одномерный массив строк");
         StringBuilder stringModified = new StringBuilder();
         int row = 0;
         while (row < inputArray.Length)
         {
            if (row != inputArray.Length - 1)
            {
               stringModified.Append(inputArray[row] + " ");
            }
            else
            {
               stringModified.Append(inputArray[row]);
            }

            row++;
         }

         Console.WriteLine(stringModified);
         string[] stringArray = { stringModified.ToString() };
         return stringArray;
      }

      public static string[] OutputStringArrayDouble(double[] inputArray)
      {
         // Объединение одномерного массива максимальных значений строк double[]
         // в одномерный массив строк string[] для записи в файл (в одну строку массива)
         Console.WriteLine("Одномерный массив строк");
         StringBuilder stringModified = new StringBuilder();
         int row = 0;
         while (row < inputArray.Length)
         {
            if (row != inputArray.Length - 1)
            {
               stringModified.Append(inputArray[row] + " ");
            }
            else
            {
               stringModified.Append(inputArray[row]);
            }

            row++;
         }

         Console.WriteLine(stringModified);
         string[] stringArray = { stringModified.ToString() };
         return stringArray;
      }

      public static string[] OutputArrayStringInt(int[] inputArray)
      {
         // Объединение одномерного массива int[]
         // в одномерный массив строк string[] для записи в файл
         Console.WriteLine("Одномерный массив строк");
         StringBuilder stringModified = new StringBuilder();
         string[] arrayString = new string[inputArray.Length];
         int row = 0;
         while (row < inputArray.Length)
         {
            stringModified.Append(inputArray[row]);
            string subLine = stringModified.ToString();
            arrayString[row] = subLine;
            Console.WriteLine(subLine);
            stringModified.Clear();
            row++;
         }

         return arrayString;
      }

      public static string[] OutputArrayStringDouble(double[] inputArray)
      {
         // Объединение одномерного массива максимальных значений строк double[]
         // в одномерный массив строк string[] для записи в файл
         Console.WriteLine("Одномерный массив строк");
         StringBuilder stringModified = new StringBuilder();
         string[] arrayString = new string[inputArray.Length];
         int row = 0;
         while (row < inputArray.Length)
         {
            stringModified.Append(inputArray[row]);
            string subLine = stringModified.ToString();
            arrayString[row] = subLine;
            Console.WriteLine(subLine);
            stringModified.Clear();
            row++;
         }

         return arrayString;
      }

      public static void FileAppendString(string line, string nameFile)
      {
         Console.WriteLine("Запись массива строк в файл {0}", nameFile);
         // Создание одномерного массива строк string[] для записи в файл строки
         string[] stringArray = { line };
         // Добавление массива строк в файл
         string filePath = AppContext.BaseDirectory + nameFile;
         File.AppendAllLines(filePath, stringArray);
      }

      public static void FileAppendStringArray(string[] stringArray, string nameFile)
      {
         Console.WriteLine("Запись массива строк в файл {0}", nameFile);
         // Добавление массива строк в файл
         string filePath = AppContext.BaseDirectory + nameFile;
         File.AppendAllLines(filePath, stringArray);
      }

      public static void FileWriteString(string line, string nameFile)
      {
         Console.WriteLine("Запись массива строк в файл {0}", nameFile);
         // Создание одномерного массива строк string[] для записи в файл строки
         string[] stringArray = { line };
         // Запись массива строк в файл
         string filePath = AppContext.BaseDirectory + nameFile;
         File.WriteAllLines(filePath, stringArray);
      }

      public static void FileWriteArrayString(string[] arrayString, string nameFile)
      {
         // Запись массива строк в файл
         Console.WriteLine("Запись массива строк в файл {0}", nameFile);
         string filePath = AppContext.BaseDirectory + nameFile;
         File.WriteAllLines(filePath, arrayString);
      }
   }
}