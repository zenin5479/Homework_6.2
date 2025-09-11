using System;
using System.IO;
using System.Text;

namespace Homework_6._2
{
   public class MethodsFor2DArray
   {
      public static int SizeRow()
      {
         int n;
         do
         {
            Console.WriteLine("Введите количество строк массива:");
            int.TryParse(Console.ReadLine(), out n);
            //n = Convert.ToInt32(Console.ReadLine());
            if (n <= 0 || n > 20)
            {
               Console.WriteLine("Введено неверное значение");
            }
         } while (n <= 0 || n > 20);

         return n;
      }

      public static int SizeColumn()
      {
         int m;
         do
         {
            Console.WriteLine("Введите количество столбцов массива:");
            int.TryParse(Console.ReadLine(), out m);
            //m = Convert.ToInt32(Console.ReadLine());
            if (m <= 0 || m > 20)
            {
               Console.WriteLine("Введено неверное значение");
            }
         } while (m <= 0 || m > 20);

         return m;
      }

      public static int MultipleElement()
      {
         int multiple;
         do
         {
            Console.WriteLine("Введите величину:");
            int.TryParse(Console.ReadLine(), out multiple);
            //multiple = Convert.ToInt32(Console.ReadLine());
            if (multiple <= 0 || multiple > 99)
            {
               Console.WriteLine("Введено неверное значение");
            }
         } while (multiple <= 0 || multiple > 99);

         return multiple;
      }

      public static int SizeRow(string nameArray)
      {
         int n;
         do
         {
            Console.WriteLine("Введите количество строк массива {0}:", nameArray);
            int.TryParse(Console.ReadLine(), out n);
            //n = Convert.ToInt32(Console.ReadLine());
            if (n <= 0 || n > 20)
            {
               Console.WriteLine("Введено неверное значение");
            }
         } while (n <= 0 || n > 20);

         return n;
      }

      public static int SizeColumn(string nameArray)
      {
         int m;
         do
         {
            Console.WriteLine("Введите количество столбцов массива {0}:", nameArray);
            int.TryParse(Console.ReadLine(), out m);
            //m = Convert.ToInt32(Console.ReadLine());
            if (m <= 0 || m > 20)
            {
               Console.WriteLine("Введено неверное значение");
            }
         } while (m <= 0 || m > 20);

         return m;
      }

      public static int SizeMatrix(string nameMatrix)
      {
         int n;
         do
         {
            Console.WriteLine("Введите размер матрицы {0}:", nameMatrix);
            int.TryParse(Console.ReadLine(), out n);
            //n = Convert.ToInt32(Console.ReadLine());
            if (n <= 0 || n > 20)
            {
               Console.WriteLine("Введено неверное значение");
            }
         } while (n <= 0 || n > 20);

         return n;
      }

      public static double[,] EnterArrayDouble(string path)
      {
         // Двумерный массив вещественных чисел
         double[,] arrayDouble = { };
         // Чтение файла за одну операцию
         string[] allLines = File.ReadAllLines(path);
         if (allLines == null)
         {
            Console.WriteLine("Ошибка при открытии файла для чтения");
         }
         else
         {
            //Console.WriteLine("Исходный массив строк");
            int indexLines = 0;
            while (indexLines < allLines.Length)
            {
               allLines[indexLines] = allLines[indexLines];
               //Console.WriteLine(allLines[indexLines]);
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
               //Console.WriteLine("В строке {0} количество столбцов {1}", countRow, countСolumn);
               countСolumn = 0;
               countRow++;
               countSymbol = 0;
            }

            // Разделение строки на подстроки по пробелу и конвертация подстрок в double
            //Console.WriteLine("Двухмерный числовой массив");
            StringBuilder stringModified = new StringBuilder();
            arrayDouble = new double[allLines.Length, sizeArray.Length];
            char spaceCharacter = ' ';
            int row = 0;
            int column = 0;
            int countCharacter = 0;
            while (row < arrayDouble.GetLength(0))
            {
               string line = allLines[row];
               while (column < sizeArray[row])
               {
                  while (countCharacter < line.Length)
                  {
                     if (spaceCharacter == line[countCharacter])
                     {
                        string subLine = stringModified.ToString();
                        arrayDouble[row, column] = Convert.ToDouble(subLine);
                        //Console.Write(arrayDouble[row, column] + " ");
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
                        arrayDouble[row, column] = Convert.ToDouble(subLine);
                        //Console.Write(arrayDouble[row, column]);
                        stringModified.Clear();
                        column++;
                     }

                     countCharacter++;
                  }

                  countCharacter = 0;
               }

               //Console.WriteLine();
               column = 0;
               row++;
            }
         }

         return arrayDouble;
      }

      public static double[,] EnterArrayDouble(string path, string nameFile)
      {
         // Двумерный массив вещественных чисел
         double[,] arrayDouble = { };
         // Чтение файла за одну операцию
         string[] allLines = File.ReadAllLines(path);
         if (allLines == null || allLines.Length == 0)
         {
            Console.WriteLine("Ошибка содержимого файла для чтения {0}", nameFile);
            //Console.WriteLine("Ошибка содержимого файла для чтения {0}. Файл пуст", nameFile);
         }
         else
         {
            int indexLines = 0;
            while (indexLines < allLines.Length)
            {
               allLines[indexLines] = allLines[indexLines];
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
               countСolumn = 0;
               countRow++;
               countSymbol = 0;
            }

            // Разделение строки на подстроки по пробелу и конвертация подстрок в double
            StringBuilder stringModified = new StringBuilder();
            arrayDouble = new double[allLines.Length, sizeArray.Length];
            char spaceCharacter = ' ';
            int row = 0;
            int column = 0;
            int countCharacter = 0;
            while (row < arrayDouble.GetLength(0))
            {
               string line = allLines[row];
               while (column < sizeArray[row])
               {
                  while (countCharacter < line.Length)
                  {
                     if (spaceCharacter == line[countCharacter])
                     {
                        string subLine = stringModified.ToString();
                        arrayDouble[row, column] = Convert.ToDouble(subLine);
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
                        arrayDouble[row, column] = Convert.ToDouble(subLine);
                        stringModified.Clear();
                        column++;
                     }

                     countCharacter++;
                  }

                  countCharacter = 0;
               }

               column = 0;
               row++;
            }
         }

         return arrayDouble;
      }

      public static int[,] EnterArrayInt(string path, string nameFile)
      {
         // Двумерный целочисленный массив 
         int[,] arrayDouble = { };
         // Чтение файла за одну операцию
         string[] allLines = File.ReadAllLines(path);
         if (allLines == null || allLines.Length == 0)
         {
            Console.WriteLine("Ошибка содержимого файла для чтения {0}", nameFile);
            //Console.WriteLine("Ошибка содержимого файла для чтения {0}. Файл пуст", nameFile);
         }
         else
         {
            int indexLines = 0;
            while (indexLines < allLines.Length)
            {
               allLines[indexLines] = allLines[indexLines];
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
               countСolumn = 0;
               countRow++;
               countSymbol = 0;
            }

            // Разделение строки на подстроки по пробелу и конвертация подстрок в int
            StringBuilder stringModified = new StringBuilder();
            arrayDouble = new int[allLines.Length, sizeArray.Length];
            char spaceCharacter = ' ';
            int row = 0;
            int column = 0;
            int countCharacter = 0;
            while (row < arrayDouble.GetLength(0))
            {
               string line = allLines[row];
               while (column < sizeArray[row])
               {
                  while (countCharacter < line.Length)
                  {
                     if (spaceCharacter == line[countCharacter])
                     {
                        string subLine = stringModified.ToString();
                        arrayDouble[row, column] = Convert.ToInt32(subLine);
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
                        arrayDouble[row, column] = Convert.ToInt32(subLine);
                        stringModified.Clear();
                        column++;
                     }

                     countCharacter++;
                  }

                  countCharacter = 0;
               }

               column = 0;
               row++;
            }
         }

         return arrayDouble;
      }

      public static double[,] InputArrayDouble(double[,] inputArray, int n, int m)
      {
         Console.WriteLine("Двумерный массив вещественных чисел");
         double[,] outputArray = new double[n, m];
         int i = 0;
         while (i < n)
         {
            int j = 0;
            while (j < m)
            {
               outputArray[i, j] = inputArray[i, j];
               //Console.Write("{0:f2} ", outputArray[i, j]);
               //Console.Write("{0:f} ", outputArray[i, j]);
               Console.Write("{0} ", outputArray[i, j]);
               j++;
            }

            i++;
            Console.WriteLine();
         }

         return outputArray;
      }

      public static double[,] InputMatrixDouble(double[,] inputArray, int n, string nameArray)
      {
         Console.WriteLine("Двумерный массив (матрица) вещественных чисел {0}:", nameArray);
         double[,] outputArray = new double[n, n];
         int i = 0;
         while (i < n)
         {
            int j = 0;
            while (j < n)
            {
               outputArray[i, j] = inputArray[i, j];
               //Console.Write("{0:f2} ", outputArray[i, j]);
               //Console.Write("{0:f} ", outputArray[i, j]);
               Console.Write("{0} ", outputArray[i, j]);
               j++;
            }

            i++;
            Console.WriteLine();
         }

         return outputArray;
      }

      public static double[,] InputArrayDouble(int[,] inputArray, int n, int m, string nameArray)
      {
         Console.WriteLine("Двумерный массив вещественных чисел {0}:", nameArray);
         double[,] outputArray = new double[n, m];
         int i = 0;
         while (i < n)
         {
            int j = 0;
            while (j < m)
            {
               outputArray[i, j] = inputArray[i, j];
               Console.Write("{0} ", outputArray[i, j]);
               //Console.Write("{0:f2} ", outputArray[i, j]);
               //Console.Write("{0:f} ", outputArray[i, j]);
               j++;
            }

            i++;
            Console.WriteLine();
         }

         return outputArray;
      }

      public static int[,] InputArrayInt(int[,] inputArray, int n, int m)
      {
         Console.WriteLine("Двумерный целочисленный массив:");
         int[,] outputArray = new int[n, m];
         int i = 0;
         while (i < n)
         {
            int j = 0;
            while (j < m)
            {
               outputArray[i, j] = inputArray[i, j];
               Console.Write("{0} ", outputArray[i, j]);
               j++;
            }

            i++;
            Console.WriteLine();
         }

         return outputArray;
      }

      public static int[,] InputArrayInt(int[,] inputArray, int n, int m, string nameArray)
      {
         Console.WriteLine("Двумерный целочисленный массив {0}:", nameArray);
         int[,] outputArray = new int[n, m];
         int i = 0;
         while (i < n)
         {
            int j = 0;
            while (j < m)
            {
               outputArray[i, j] = inputArray[i, j];
               Console.Write("{0} ", outputArray[i, j]);
               j++;
            }

            i++;
            Console.WriteLine();
         }

         return outputArray;
      }

      public static void PrintingArrayDouble(double[,] inputArray)
      {
         Console.WriteLine("Двумерный числовой массив");
         int i = 0;
         while (i < inputArray.GetLength(0))
         {
            int j = 0;
            while (j < inputArray.GetLength(1))
            {
               if (j == inputArray.GetLength(1) - 1)
               {
                  Console.Write(inputArray[i, j]);
                  //Console.Write("{0:f}", inputArray[i, j]);
                  //Console.Write("{0:f2}", inputArray[i, j]);
               }
               else
               {
                  Console.Write(inputArray[i, j] + " ");
                  //Console.Write("{0:f} ", inputArray[i, j]);
                  //Console.Write("{0:f2} ", inputArray[i, j]);
               }

               j++;
            }

            i++;
            Console.WriteLine();
         }
      }

      public static void PrintingArrayDouble(double[] inputArray)
      {
         Console.WriteLine("Одномерный числовой массив");
         int i = 0;
         while (i < inputArray.Length)
         {
            if (i == inputArray.Length - 1)
            {
               //Console.Write(inputArray[i]);
               Console.Write("{0:f}", inputArray[i]);
               //Console.Write("{0:f2}", inputArray[i]);
            }
            else
            {
               //Console.Write(inputArray[i] + " ");
               Console.Write("{0:f} ", inputArray[i]);
               //Console.Write("{0:f2} ", inputArray[i]);
            }

            i++;
         }
      }

      public static double[] SumRowElements(double[,] inputArray)
      {
         Console.WriteLine("Одномерный массив сумм элементов строк двумерного массива");
         double[] sumArray = new double[inputArray.GetLength(0)];
         int i = 0;
         while (i < inputArray.GetLength(0))
         {
            double sum = 0;
            int j = 0;
            while (j < inputArray.GetLength(1))
            {
               sum += inputArray[i, j];
               j++;
            }

            sumArray[i] = sum;

            i++;
         }

         int k = 0;
         while (k < sumArray.Length)
         {
            if (k == sumArray.Length - 1)
            {
               //Console.Write(sumArray[k]);
               Console.Write("{0:f}", sumArray[k]);
               //Console.Write("{0:f2}", sumArray[k]);
            }
            else
            {
               //Console.Write(sumArray[k] + " ");
               Console.Write("{0:f} ", sumArray[k]);
               //Console.Write("{0:f2} ", sumArray[k]);
            }

            k++;
         }

         Console.WriteLine();
         return sumArray;
      }

      public static double[,] BubbleSortArray(double[,] inputArray, double[] data)
      {
         Console.WriteLine("Пузырьковая сортировка по сумме элементов строк двумерного массива");
         int i = 0;
         while (i < data.Length)
         {
            int j = i + 1;
            while (j < data.Length)
            {
               if (data[i] < data[j])
               {
                  double tеmpData = data[i];
                  data[i] = data[j];
                  data[j] = tеmpData;

                  int k = 0;
                  while (k < inputArray.GetLength(1))
                  {
                     double tempArray = inputArray[i, k];
                     inputArray[i, k] = inputArray[j, k];
                     inputArray[j, k] = tempArray;
                     k++;
                  }
               }

               j++;
            }

            i++;
         }

         int l = 0;
         while (l < inputArray.GetLength(0))
         {
            int m = 0;
            while (m < inputArray.GetLength(1))
            {
               if (m == inputArray.GetLength(1) - 1)
               {
                  //Console.Write(inputArray[l, m]);
                  Console.Write("{0:f}", inputArray[l, m]);
                  //Console.Write("{0:f2}", inputArray[l, m]);
               }
               else
               {
                  //Console.Write(inputArray[l, m] + " ");
                  Console.Write("{0:f} ", inputArray[l, m]);
                  //Console.Write("{0:f2} ", inputArray[l, m]);
               }

               m++;
            }

            l++;
            Console.WriteLine();
         }

         return inputArray;
      }

      public static void BubbleSortArray(double[] inputArray)
      {
         Console.WriteLine("Пузырьковая сортировка одномерного числового массива");
         int i = 0;
         while (i < inputArray.Length)
         {
            int j = i + 1;
            while (j < inputArray.Length)
            {
               if (inputArray[i] < inputArray[j])
               {
                  double tmp = inputArray[i];
                  inputArray[i] = inputArray[j];
                  inputArray[j] = tmp;
               }

               j++;
            }

            i++;
         }

         int k = 0;
         while (k < inputArray.Length)
         {
            if (k == inputArray.Length - 1)
            {
               //Console.Write(inputArray[k]);
               Console.Write("{0:f}", inputArray[k]);
               //Console.Write("{0:f2}", inputArray[k]);
            }
            else
            {
               //Console.Write(inputArray[k] + " ");
               Console.Write("{0:f} ", inputArray[k]);
               //Console.Write("{0:f2} ", inputArray[k]);
            }

            k++;
         }
      }

      public static int[] BubbleSortArray(int[] inputArray)
      {
         int n = inputArray.Length;
         int i = 0;
         while (i < n - 1)
         {
            int j = 0;
            while (j < n - 1 - i)
            {
               if (inputArray[j] > inputArray[j + 1])
               {
                  int tempVar = inputArray[j];
                  inputArray[j] = inputArray[j + 1];
                  inputArray[j + 1] = tempVar;
               }

               j++;
            }

            i++;
         }

         int k = 0;
         while (k < inputArray.Length)
         {
            if (k == inputArray.Length - 1)
            {
               Console.Write(inputArray[k]);
            }
            else
            {
               Console.Write(inputArray[k] + " ");
            }

            k++;
         }

         return inputArray;
      }

      public static int[] BubbleSortArrayOptimized(int[] inputArray)
      {
         int n = inputArray.Length;
         int i = 0;
         while (i < n - 1)
         {
            bool swapRequired = false;
            int j = 0;
            while (j < n - 1 - i)
            {
               if (inputArray[j] > inputArray[j + 1])
               {
                  int tempVar = inputArray[j];
                  inputArray[j] = inputArray[j + 1];
                  inputArray[j + 1] = tempVar;
                  swapRequired = true;
               }

               j++;
            }

            if (swapRequired == false)
            {
               break;
            }

            i++;
         }

         int k = 0;
         while (k < inputArray.Length)
         {
            if (k == inputArray.Length - 1)
            {
               Console.Write(inputArray[k]);
            }
            else
            {
               Console.Write(inputArray[k] + " ");
            }

            k++;
         }

         return inputArray;
      }

      public static void BubbleSortColumns(double[,] inputArray)
      {
         Console.WriteLine("Пузырьковая сортировка по столбцам двумерного массива");
         int i = 0;
         while (i < inputArray.GetLength(0))
         {
            int j = 0;
            while (j < inputArray.GetLength(1) - 1)
            {
               int k = 0;
               while (k < inputArray.GetLength(1) - j - 1)
               {
                  if (inputArray[i, k] > inputArray[i, k + 1])
                  {
                     double temp = inputArray[i, k];
                     inputArray[i, k] = inputArray[i, k + 1];
                     inputArray[i, k + 1] = temp;
                  }

                  k++;
               }

               j++;
            }

            i++;
         }

         int l = 0;
         while (l < inputArray.GetLength(0))
         {
            int m = 0;
            while (m < inputArray.GetLength(1))
            {
               if (m == inputArray.GetLength(1) - 1)
               {
                  Console.Write(inputArray[l, m]);
                  //Console.Write("{0:f}", inputArray[l, m]);
                  //Console.Write("{0:f2}", inputArray[l, m]);
               }
               else
               {
                  Console.Write(inputArray[l, m] + " ");
                  //Console.Write("{0:f} ", inputArray[l, m]);
                  //Console.Write("{0:f2} ", inputArray[l, m]);
               }

               m++;
            }

            l++;
            Console.WriteLine();
         }
      }

      public static double[,] SwapLastLine(double[,] inputArray)
      {
         Console.WriteLine("Замена первой строки двумерного массива последней");
         int i = 0;
         int j = inputArray.GetLength(0) - 1;
         int k = 0;
         while (k < inputArray.GetLength(1))
         {
            inputArray[i, k] = inputArray[j, k];
            k++;
         }

         int l = 0;
         while (l < inputArray.GetLength(0))
         {
            int m = 0;
            while (m < inputArray.GetLength(1))
            {
               if (m == inputArray.GetLength(1) - 1)
               {
                  //Console.Write(inputArray[l, m]);
                  Console.Write("{0:f}", inputArray[l, m]);
                  //Console.Write("{0:f2}", inputArray[l, m]);
               }
               else
               {
                  //Console.Write(inputArray[l, m] + " ");
                  Console.Write("{0:f} ", inputArray[l, m]);
                  //Console.Write("{0:f2} ", inputArray[l, m]);
               }

               m++;
            }

            l++;
            Console.WriteLine();
         }

         return inputArray;
      }

      public static double[] FindMaxDouble(double[,] inputArray)
      {
         // Поиск максимального элемента строки (без флагов bool)
         double[] arrayMax = new double[inputArray.GetLength(0)];
         int rowOut = 0;
         int columnOut = 0;
         while (rowOut < inputArray.GetLength(0))
         {
            // Cчитаем, что максимум - это первый элемент строки
            double maxOut = inputArray[rowOut, 0];
            while (columnOut < inputArray.GetLength(1))
            {
               if (maxOut < inputArray[rowOut, columnOut])
               {
                  maxOut = inputArray[rowOut, columnOut];
               }

               columnOut++;
            }

            arrayMax[rowOut] = maxOut;
            //Console.WriteLine("Максимум в строке {0} равен: {1}", rowOut, maxOut);
            columnOut = 0;
            rowOut++;
         }

         Console.WriteLine("Массив максимальных значений строк");
         int indexMax = 0;
         while (indexMax < arrayMax.Length)
         {
            Console.Write("{0} ", arrayMax[indexMax]);
            indexMax++;
         }

         Console.WriteLine();
         return arrayMax;
      }

      public static int[] FindMaxInt(int[,] inputArray)
      {
         // Поиск максимального элемента строки (без флагов bool)
         int[] arrayMax = new int[inputArray.GetLength(0)];
         int rowOut = 0;
         int columnOut = 0;
         while (rowOut < inputArray.GetLength(0))
         {
            // Cчитаем, что максимум - это первый элемент строки
            int maxOut = inputArray[rowOut, 0];
            while (columnOut < inputArray.GetLength(1))
            {
               if (maxOut < inputArray[rowOut, columnOut])
               {
                  maxOut = inputArray[rowOut, columnOut];
               }

               columnOut++;
            }

            arrayMax[rowOut] = maxOut;
            //Console.WriteLine("Максимум в строке {0} равен: {1}", rowOut, maxOut);
            columnOut = 0;
            rowOut++;
         }

         Console.WriteLine("Массив максимальных значений строк");
         int indexMax = 0;
         while (indexMax < arrayMax.Length)
         {
            Console.Write("{0} ", arrayMax[indexMax]);
            indexMax++;
         }

         Console.WriteLine();
         return arrayMax;
      }

      public static int SearchingNegativeDouble(double[,] inputArray)
      {
         int count = 0;
         int i = 0;
         while (i < inputArray.GetLength(0))
         {
            int j = 0;
            while (j < inputArray.GetLength(1))
            {
               if (inputArray[i, j] < 0)
               {
                  count++;
               }

               j++;
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

      public static int SearchingNegativeDouble(double[,] inputArray, string nameArray)
      {
         int count = 0;
         int i = 0;
         while (i < inputArray.GetLength(0))
         {
            int j = 0;
            while (j < inputArray.GetLength(1))
            {
               if (inputArray[i, j] < 0)
               {
                  count++;
               }

               j++;
            }

            i++;
         }

         Console.WriteLine("В двумерном массиве {0} отрицательных элементов: {1}", nameArray, count);
         if (count == 0)
         {
            Console.WriteLine("В двумерном массиве нет отрицательных элементов");
         }

         return count;
      }

      public static bool SearchingPositivDouble(double[,] search)
      {
         bool fl = true;
         int i = 0;
         while (i < search.GetLength(0) && fl)
         {
            int j = 0;
            while (j < search.GetLength(1) && fl)
            {
               if (search[i, j] > 0)
               {
                  fl = false;
               }
               else
               {
                  j++;
               }
            }

            i++;
         }

         return fl;
      }

      public static bool SearchingPositivInt(int[,] search)
      {
         bool fl = true;
         int i = 0;
         while (i < search.GetLength(0) && fl)
         {
            int j = 0;
            while (j < search.GetLength(1) && fl)
            {
               if (search[i, j] > 0)
               {
                  fl = false;
               }
               else
               {
                  j++;
               }
            }

            i++;
         }

         return fl;
      }

      public static double SearchingMinPositivDouble(double[,] search, string nameArray)
      {
         double min = search[0, 0];
         int i = 0;
         while (i < search.GetLength(0))
         {
            int j = 0;
            while (j < search.GetLength(1))
            {
               if (min < 0 && search[i, j] > min)
               {
                  min = search[i, j];
               }

               if (search[i, j] > 0 && search[i, j] < min)
               {
                  min = search[i, j];
               }

               j++;
            }

            i++;
         }

         Console.WriteLine("Минимальное значение среди положительных элементов двумерного массива {0}: {1}", nameArray, min);
         //Console.WriteLine("Минимальное значение среди положительных элементов двумерного массива {0}: {1:f2}", nameArray, min);
         //Console.WriteLine("Минимальное значение среди положительных элементов двумерного массива {0}: {1:f}", nameArray, min);
         return min;
      }

      public static int SearchingMinPositivInt(int[,] search, string nameArray)
      {
         int min = search[0, 0];
         int i = 0;
         while (i < search.GetLength(0))
         {
            int j = 0;
            while (j < search.GetLength(1))
            {
               if (min < 0 && search[i, j] > min)
               {
                  min = search[i, j];
               }

               if (search[i, j] > 0 && search[i, j] < min)
               {
                  min = search[i, j];
               }

               j++;
            }

            i++;
         }

         Console.WriteLine("Минимальное значение среди положительных элементов двумерного массива {0}: {1}", nameArray, min);
         return min;
      }

      public static bool ComparisonNegativeDouble(double negativeOne, double negativeTwo)
      {
         return negativeOne > negativeTwo;
      }

      public static double CalculatingValueDouble(double minOne, double minTwo, double minThree)
      {
         return minOne * minTwo - minThree;
      }

      public static int CalculatingValueInt(int minOne, int minTwo, int minThree)
      {
         return minOne * minTwo - minThree;
      }

      public static void SplittingLines(int[,] input, int multiple, string nameFile)
      {
         int counterMultiple = 0;
         int[] lines = new int[input.GetLength(1)];
         int i = 0;
         while (i < input.GetLength(0))
         {
            int j = 0;
            while (j < input.GetLength(1))
            {
               lines[j] = input[i, j];
               j++;
            }

            if (SearchingMultiple(lines, multiple))
            {
               string lineFound = "В массиве найдена строка " + (i + 1) + " с элементом, кратным " + multiple;
               Console.WriteLine(lineFound);
               FileAppendStringArray(lineFound, nameFile);
               counterMultiple++;
            }

            Array.Clear(lines, 0, lines.Length);
            i++;
         }

         if (counterMultiple == 0)
         {
            string lineNotFound = "В массиве не найдено строк с элементом, кратным " + multiple;
            Console.WriteLine(lineNotFound);
            FileAppendStringArray(lineNotFound, nameFile);
         }
      }

      public static bool SearchingMultiple(int[] lines, int multiple)
      {
         int i = 0;
         while (i < lines.Length)
         {
            if (lines[i] % multiple == 0)
            {
               return true;
            }

            i++;
         }

         return false;
      }

      public static string[] OutputStringDouble(double input)
      {
         // Конвертация double в одномерный массив строк string[] для записи в файл (в одну строку массива)
         Console.WriteLine("Одномерный массив строк");
         StringBuilder stringModified = new StringBuilder();
         stringModified.Append(input);
         string line = stringModified.ToString();
         Console.WriteLine(line);
         string[] stringArray = { line };
         return stringArray;
      }

      public static string[] OutputStringInt(int input)
      {
         // Конвертация int в одномерный массив строк string[] для записи в файл (в одну строку массива)
         Console.WriteLine("Одномерный массив строк");
         StringBuilder stringModified = new StringBuilder();
         stringModified.Append(input);
         string line = stringModified.ToString();
         Console.WriteLine(line);
         string[] stringArray = { line };
         return stringArray;
      }

      public static string[] OutputStringDouble(double[] inputArray)
      {
         // Объединение одномерного массива double[]
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

      public static string[] OutputStringInt(int[] inputArray)
      {
         // Объединение одномерного массива int[]
         // в одномерный массив строк string[] для записи в файл (в одну строку массива)
         Console.WriteLine("Одномерный массив строк");
         StringBuilder stringModified = new StringBuilder();
         int row = 0;
         while (row < inputArray.Length)
         {
            if (row == inputArray.Length - 1)
            {
               stringModified.Append(inputArray[row]);
            }
            else
            {
               stringModified.Append(inputArray[row] + " ");
            }

            row++;
         }

         Console.WriteLine(stringModified);
         string[] stringArray = { stringModified.ToString() };
         return stringArray;
      }

      public static string[] OutputArrayString(double[] inputArray)
      {
         // Объединение одномерного массива double[]
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

      public static string[] OutputArrayString(double[,] inputArray)
      {
         // Объединение двумерного массива double[]
         // в одномерный массив строк string[] для записи в файл
         //Console.WriteLine("Одномерный массив строк");
         StringBuilder stringModified = new StringBuilder();
         string[] arrayString = new string[inputArray.GetLength(0)];
         string subLine;
         int row = 0;
         while (row < inputArray.GetLength(0))
         {
            int column = 0;
            while (column < inputArray.GetLength(1))
            {
               if (column == inputArray.GetLength(1) - 1)
               {
                  stringModified.Append(inputArray[row, column]);
                  subLine = stringModified.ToString();
                  arrayString[row] = subLine;
               }
               else
               {
                  stringModified.Append(inputArray[row, column] + " ");
                  subLine = stringModified.ToString();
                  arrayString[row] = subLine;
               }

               column++;
            }

            //Console.WriteLine(subLine);
            stringModified.Clear();
            row++;
         }

         return arrayString;
      }

      public static void FileWriteArrayString(string[] arrayString, string nameFile)
      {
         // Запись массива строк в файл
         Console.WriteLine("Запись массива строк в файл {0}", nameFile);
         string filePath = AppContext.BaseDirectory + nameFile;
         File.WriteAllLines(filePath, arrayString);
      }

      public static void FileAppendStringArray(string line, string nameFile)
      {
         // Создание одномерного массива строк string[] для записи в файл строки
         string[] stringArray = { line };
         // Добавление массива строк в файл
         string filePath = AppContext.BaseDirectory + nameFile;
         File.AppendAllLines(filePath, stringArray);
      }
   }
}