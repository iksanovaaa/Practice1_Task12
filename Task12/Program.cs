using System;

namespace Task12
{
    public class Program
    {
        public static int[] descOrder, ascOrder, array, descOrder2, ascOrder2, array2; // упорядоченный по убыванию, по возрастанию, неупорядоченный массивы
        public static int length, removes, compares;
        public static Random rnd = new Random();

        static void Main(string[] args)
        {
            bool end = false;
            do
            {
                length = rnd.Next(9, 21);

                CreateArrayRnd();
                CreateOrderedAsc();
                CreateOrderedDesc();

                PrintMessage("Исходные массивы: ");
                PrintArr(array);
                PrintArr(descOrder);
                PrintArr(ascOrder);

                PrintMessage("Массивы после сортировки Шелла: ");
                ShellSort(array);
                PrintInfo();
                PrintArr(array);
                ShellSort(descOrder);
                PrintInfo();
                PrintArr(descOrder);
                ShellSort(ascOrder);
                PrintInfo();
                PrintArr(ascOrder);

                compares = 0;
                removes = 0;
                PrintMessage("Массивы после быстрой сортировки: ");
                QuickSort(array2, 0, array.Length - 1);
                PrintInfo();
                PrintArr(array2);
                compares = 0;
                removes = 0;
                QuickSort(descOrder2, 0, array.Length - 1);
                PrintInfo();
                PrintArr(descOrder2);
                compares = 0;
                removes = 0;
                QuickSort(ascOrder2, 0, array.Length - 1);
                PrintInfo();
                PrintArr(ascOrder2);
                end = CheckKey();
            } while (!end);
        }
        public static void PrintMessage(string str)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(str);
            Console.ResetColor();
        }
        public static void PrintInfo()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Количество сравнений: {0}\nКоличество пересылок: {1}", compares, removes);
            Console.ResetColor();
        }

        //формирование массивов
        public static void CreateArrayRnd() //неотсортированный массив
        {
            array = new int[length];
            array2 = new int[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = rnd.Next(100);
                array2[i] = array[i];
            }
        }

        public static void CreateOrderedDesc() //отсортированный в порядке убывания массив
        {
            descOrder = new int[length];
            descOrder2 = new int[length];
            for (int i = 0; i < length; i++)
            {
                descOrder[i] = length - i;
                descOrder2[i] = length - i;
            }
        }

        public static void CreateOrderedAsc() //отсортированный в порядке возрастания массив
        {
            ascOrder = new int[length];
            ascOrder2 = new int[length];
            for (int i = 0; i < length; i++)
            {
                ascOrder[i] = i + 1;
                ascOrder2[i] = i + 1;
            }
        }
        public static void PrintArr(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        //сортировка Шелла
        public static void ShellSort(int[] arr)
        {
            compares = 0;
            removes = 0;
            int step = arr.Length / 2;
            while (step > 0)
            {
                int i, j;
                for (i = step; i < arr.Length; i++)
                {
                    int value = arr[i];
                    for (j = i - step; (j >= 0) && CompareSh(arr[j], value); j -= step)
                    {
                        arr[j + step] = arr[j];
                        removes++;
                    }
                    arr[j + step] = value;
                }
                step /= 2;
            }
        }
        public static bool CompareSh(int el, int val)
        {
            compares++;
            return (el > val);
        }

        //Быстрая сортировка
        public static void QuickSort(int[] arr, int first, int last)
        {
            int p = arr[(last - first) / 2 + first];
            int temp;
            int i = first, j = last;
            while (i <= j)
            {
                while (CompareQ(arr[i], p, true) && i <= last)
                {
                    ++i;
                }
                while (CompareQ(arr[j], p, false) && j >= first)
                {
                    --j;
                }
                if (i <= j)
                {
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    if (i != j) removes++;
                    ++i;
                    --j;
                }
            }
            if (j > first) QuickSort(arr, first, j);
            if (i < last) QuickSort(arr, i, last);
        }

        public static bool CompareQ(int el, int val, bool less)
        {
            bool res = false;
            compares++;
            if (less) res = (el < val);
            else res = (el > val);
            return res;
        }

        //выход из программы или формирование новой последоватльности
        public static bool CheckKey()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            bool next, end = false;
            int keyNum;
            Console.WriteLine("Для выхода из программы нажмите Esc, для генерации других массивов нажмите Enter.");
            do
            {
                keyNum = Console.ReadKey().KeyChar;
                next = (keyNum == 27) || (keyNum == 13);
            } while (!next);
            if (keyNum == 27) end = true;
            Console.Clear();
            Console.ResetColor();
            return end;
        }
    }
}

