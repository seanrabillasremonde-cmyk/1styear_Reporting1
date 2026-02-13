using System;

namespace MainMenu
{
    class Program
    {
        static void Main()
        {
            const int LIMIT = 10;

            while (true)
            {
                Console.WriteLine("\n==== MAIN MENU ====");
                Console.WriteLine("1. Bubble Sort");
                Console.WriteLine("2. Selection Sort");
                Console.WriteLine("3. Insertion Sort");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                //application for the input 
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.Write("Invalid input. Enter numeric choice: ");
                }

                switch (choice)
                {
                    case 1:
                        int[] bubbleArr = EnterNumbers(LIMIT);
                        BubbleSort(bubbleArr);
                        Console.WriteLine("Sorted using Bubble Sort:");
                        Console.WriteLine(string.Join(", ", bubbleArr));
                        break;

                    case 2:
                        int[] selectionArr = EnterNumbers(LIMIT);
                        SelectionSort(selectionArr);
                        Console.WriteLine("Sorted using Selection Sort:");
                        Console.WriteLine(string.Join(", ", selectionArr));
                        break;

                    case 3:
                        int[] insertionArr = EnterNumbers(LIMIT);
                        InsertionSort(insertionArr);
                        Console.WriteLine("Sorted using Insertion Sort:");
                        Console.WriteLine(string.Join(", ", insertionArr));
                        break;

                    case 4:
                        Console.WriteLine("Exiting program...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        // ✅ Enter Numbers with negative number validation
        static int[] EnterNumbers(int limit)
        {
            int[] arr = new int[limit];

            Console.WriteLine($"\nEnter {limit} non-negative numbers:");

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"Enter number {i + 1}: ");

                while (true)
                {
                    if (!int.TryParse(Console.ReadLine(), out arr[i]))
                    {
                        Console.Write("Invalid input. Enter a valid number: ");
                    }
                    else if (arr[i] < 0)
                    {
                        Console.Write("Negative numbers are not allowed. Enter again: ");
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return arr;
        }

        // 🔵 Bubble Sort
        static void BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        // 🟢 Selection Sort
        static void SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }

                int temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;
            }
        }

        // 🟡 Insertion Sort
        static void InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int key = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = key;
            }
        }
    }
}