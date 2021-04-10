﻿using System;

namespace ArrayTasksApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.Write("Enter the namber task: ");
                    int nuberTask = Int32.Parse(Console.ReadLine());
                    MethodSelection(nuberTask);

                }
                catch(Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: {e.Message}");
                    Console.ResetColor();
                }

                Console.Write("\nPlease click ESC to exit ");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    return;
                }
            }
        }

        static void MethodSelection(int numberTask)//choose a task 
        {
            Description(numberTask);

            switch (numberTask)
            {
                case 1:
                    MethodNamber_1();
                    break;
                case 2:
                    MethodNamber_2();
                    break;
                case 3:
                    MethodNamber_3();
                    break;
                case 4:
                    MethodNamber_4();
                    break;
                case 5:
                    MethodNamber_5();
                    break;
                case 6:
                    MethodNamber_6();
                    break;
                case 7:
                    MethodNamber_7();
                    break;
                case 8:
                    MethodNamber_8();
                    break;
                case 9:
                    MethodNamber_9();
                    break;
                case 10:
                    MethodNamber_10();
                    break;
                default:
                    throw new Exception("There is no such task !");
            }
        }

        static void Description(int numberTask)//choice of description
        {
            Console.ForegroundColor = ConsoleColor.Green;

            switch (numberTask)
            {
                case 1:
                    Console.WriteLine("Write a program in C# Sharp to store elements in an array and print it. \n\n");
                    break;
                case 2:
                    Console.WriteLine("Write a program in C# Sharp to read n number of values in an array and display it in reverse order.\n\n");
                    break;
                case 3:
                    Console.WriteLine("Write a program in C# Sharp to find the sum of all elements of the array.\n\n");
                    break;
                case 4:
                    Console.WriteLine("Write a program in C# Sharp to copy the elements one array into another array.\n\n");
                    break;
                case 5:
                    Console.WriteLine("Write a program in C# Sharp to count a total number of duplicate elements in an array.\n\n");
                    break;
                case 6:
                    Console.WriteLine("Write a program in C# Sharp to print all unique elements in an array.\n\n");
                    break;
                case 7:
                    Console.WriteLine("Write a program in C# Sharp to merge two arrays of same size sorted in ascending order.\n\n");
                    break;
                case 8:
                    Console.WriteLine("Write a program in C# Sharp to count the frequency of each element of an array.\n\n");
                    break;
                case 9:
                    Console.WriteLine("Write a program in C# Sharp to find maximum and minimum element in an array.\n\n");
                    break;
                case 10:
                    Console.WriteLine("Write a programin C# Sharp to separate odd and even integers in separate arrays.\n\n");
                    break;
                default:
                    throw new Exception("There is no such task !");
            }

            Console.ResetColor();
        }

        static void MethodNamber_1()
        {
            int[] array = EnterArray(GetLength());

            Console.WriteLine("\nElements in array are:");
            PrintArray(array);
        }

        static void MethodNamber_2()
        {
            int[] array = EnterArray(GetLength());

            Console.WriteLine("\nThe values store into the array are:");
            PrintArray(array);
            Console.WriteLine("\nThe values store into the array in reverse are :");
            PrintArrayReverse(array, "ReverseArray");
        }

        static void MethodNamber_3()
        {
            int[] array = EnterArray(GetLength());

            Console.WriteLine($"\nSum of all elements of the array: {GetSumArray(array)}");
        }

        static void MethodNamber_4()
        {
            int[] firstArray = EnterArray(GetLength());
            int[] secondArray = new int[firstArray.Length];

            for (int i = 0; i < firstArray.Length; i++)
            {
                secondArray[i] = firstArray[i];
            }

            Console.WriteLine("\nThe elements stored in the first array are :");
            PrintArray(firstArray, "FirstArray");
            Console.WriteLine("\nThe elements copied into the second array are :");
            PrintArray(secondArray, "SecondArray");
        }

        static void MethodNamber_5()
        {
            int[] array = EnterArray(GetLength());

            Console.WriteLine($"\nTotal number of duplicate elements found in the array is : {GetCountDuplicate(array)}");
        }

        static void MethodNamber_6()
        {
            int[] array = EnterArray(GetLength());
            bool[] arrayBool = new bool[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                arrayBool[i] = true;
            }
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] == array[j])
                    {
                        arrayBool[i] = false;
                        arrayBool[j] = false;
                    }
                }
            }

            Console.WriteLine("\nThe unique elements found in the array are :");
            PrintCheckedArray(array, arrayBool);
        }

        static void MethodNamber_7()
        {
            int[] firstArray = EnterArray(GetLength("FirstArray"),"FirstArray");
            int[] secondArray = EnterArray(GetLength("SecondArray"), "SecondArray");
            int[] array = AddArray(firstArray, secondArray);
            SortArray(array);

            Console.WriteLine("\nThe merged array in ascending order is :");
            PrintArray(array);
        }

        static void MethodNamber_8()
        {
            int[] array = EnterArray(GetLength());
            bool[] arrayBool = new bool[array.Length];
            int[] arrayChecked = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                arrayBool[i] = true;
                arrayChecked[i] = 1;
            }

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] == array[j] && arrayBool[i])
                    {
                        arrayBool[j] = false;
                        arrayChecked[i]++;
                    }
                }
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (arrayBool[i])
                {
                    Console.WriteLine($"{array[i]}  occurs {arrayChecked[i]} times");
                }
            }
        }

        static void MethodNamber_9()
        {
            int[] array = EnterArray(GetLength());

            Console.WriteLine($"\nMaximum element is : {GetMaxElement(array)}");
            Console.WriteLine($"Minimum element is : {GetMinElement(array)}");
        }

        static void MethodNamber_10()
        {
            int[] array = EnterArray(GetLength());

            Console.WriteLine("\nThe Even elements are:");
            PrintArray(GetEvenArray(array), "EvenArray");
            Console.WriteLine("\nThe Odd elements are:");
            PrintArray(GetOddArray(array), "OddArray");
        }

        static int GetLength(string nameArray = "Array") //input of the number of array elements 
        {
            Console.Write($"Enter the namber of {nameArray}: ");
            return Int32.Parse(Console.ReadLine().Trim());
        }

        static int[] EnterArray(int length, string nameArray = "Array")//input array elements 
        {
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                Console.Write($"{nameArray}[{i}] ");
                array[i] = Int32.Parse(Console.ReadLine().Trim());
            }
            return array;
        }

        static void PrintArray(int[] array, string nameArray = "Array")//output array elements 
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"{nameArray}[{i}] = {array[i]} ");
            }
        }

        static void PrintArrayReverse(int[] array, string nameArray = "Array")//reverse output array elements 
        {
            for (int i = array.Length-1; i >=0; i--)
            {
                Console.WriteLine($"{nameArray}[{i}] = {array[i]} ");
            }
        }

        static int GetSumArray(int[] array)// calculating the sum of array elements 
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }

        static int GetCountDuplicate(int[] array)//found number of duplicate elements
        {
            int countDuplicate = 0;

            for (int i = 0; i < array.Length - 1; i++)
            {
                bool isNotFound = true;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] == array[j] && isNotFound)
                    {
                        bool repeated = false;
                        for (int k = 0; k < i; k++)
                        {
                            if (array[i] == array[k])
                            {
                                repeated = true;
                            }
                        }
                        if (!repeated)
                        {
                            countDuplicate++;
                            isNotFound = false;
                        }
                    }
                }
            }

            return countDuplicate;
        }

        static void PrintCheckedArray(int[] array, bool[] checkArray, string nameArray = "Array")//output array elements with check array
        {
            if(array.Length == checkArray.Length)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (checkArray[i])
                    {
                        Console.WriteLine($"{nameArray}[{i}] = {array[i]} ");
                    }
                }
            }
            else
            {
                throw new Exception("The length of the array does not match the length of the reference array !");
            }

            
        }

        static int[] AddArray(int[] array1, int[] array2)//addition of arrays 
        {
            int[] array = new int[array1.Length+ array2.Length];

            for (int i = 0; i < array1.Length; i++)
            {
                array[i] = array1[i];
            }
            for (int i = 0; i < array2.Length; i++)
            {
                array[array1.Length+i] = array2[i];
            }
            return array;
        }

        static void SortArray (int[] array)// sorted in ascending order
        {
            /*
             * it could have been like that 
             * Array.Sort(array);
            */

            int temp;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        static int GetMaxElement(int[] array)// return max value of array
        {
            int max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            return max;
        }

        static int GetMinElement(int[] array)// return min value of array
        {
            int min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }
            return min;
        }

        static int[] GetEvenArray(int[] array)//return even elements
        {
            int[] evenArray = new int[array.Length];
            int index = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if(array[i]%2 == 0)
                {
                    evenArray[index++] = array[i];
                }
            }
            Array.Resize(ref evenArray, index);
            return evenArray;
        }

        static int[] GetOddArray(int[] array)//return odd elements
        {
            int[] oddArray = new int[array.Length];
            int index = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    oddArray[index++] = array[i];
                }
            }
            Array.Resize(ref oddArray, index);
            return oddArray;
        }

    }
}
