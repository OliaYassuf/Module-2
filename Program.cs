using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        //3------------------------------------------------------------------
        static string EncryptCaesar(string text, int shift)
        {
            string encryptedText = "";

            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    char shiftedChar = (char)(((c - 'a' + shift) % 26) + 'a');
                    encryptedText += shiftedChar;
                }
                else
                {
                    encryptedText += c; // Add non-letter characters unchanged
                }
            }

            return encryptedText;
        }

        static string DecryptCaesar(string text, int shift)
        {
            string decryptedText = "";

            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    char shiftedChar = (char)(((c - 'a' - shift + 26) % 26) + 'a');
                    decryptedText += shiftedChar;
                }
                else
                {
                    decryptedText += c;
                }
            }

            return decryptedText;
        }

        //4------------------------------------------------------------------
        static int[,] ReadMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];
            Console.WriteLine($"Enter {rows}x{cols} matrix elements:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"Element [{i},{j}]: ");
                    matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            return matrix;
        }

        static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static int[,] MultiplyByScalar(int[,] matrix, int scalar)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[,] result = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = matrix[i, j] * scalar;
                }
            }

            return result;
        }

        static int[,] AddMatrices(int[,] matrix1, int[,] matrix2)
        {
            int rows = matrix1.GetLength(0);
            int cols = matrix1.GetLength(1);
            int[,] result = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }

            return result;
        }

        static int[,] MultiplyMatrices(int[,] matrix1, int[,] matrix2)
        {
            int rows1 = matrix1.GetLength(0);
            int cols1 = matrix1.GetLength(1);
            int rows2 = matrix2.GetLength(0);
            int cols2 = matrix2.GetLength(1);
            int[,] result = new int[rows1, cols2];

            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols2; j++)
                {
                    for (int k = 0; k < cols1; k++)
                    {
                        result[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }

            return result;
        }


        static void Main(string[] args)
        {
            //Practice
            /*
            //1
            int[] numb = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 2, 4, 6, 8 };

            Console.WriteLine("Input array: " + string.Join(", ", numb));

            int evenCount = numb.Count(num => num % 2 == 0);
            Console.WriteLine("Number of even elements: " + evenCount);

            int oddCount = numb.Count(num => num % 2 != 0);
            Console.WriteLine("Number of odd elements: " + oddCount);

            int uniqueCount = numb.Distinct().Count();
            Console.WriteLine("Number of unique elements: " + uniqueCount);

            //2
            Console.WriteLine("Enter the size of the array:");
            int size = int.Parse(Console.ReadLine());

            int[] numbers = new int[size];

            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                numbers[i] = random.Next(1, 101);
            }

            Console.WriteLine("Array:");
            Console.WriteLine(string.Join(", ", numbers));

            Console.WriteLine("Enter the threshold value:");
            int threshold = int.Parse(Console.ReadLine());

            int count = 0;
            foreach (int num in numbers)
            {
                if (num < threshold)
                {
                    count++;
                }
            }

            Console.WriteLine($"Number of values less than {threshold}: {count}");

            //3
            Console.WriteLine("Enter three numbers:");
            int[] sequence = new int[3];
            for (int i = 0; i < 3; i++)
            {
                sequence[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Enter the array of numbers (separated by spaces):");
            string[] inputArray = Console.ReadLine().Split();

            int[] Num = Array.ConvertAll(inputArray, int.Parse);

            int Count = 0;
            for (int i = 0; i <= Num.Length - 3; i++)
            {
                if (Num[i] == sequence[0] && Num[i + 1] == sequence[1] && Num[i + 2] == sequence[2])
                {
                    Count++;
                }
            }

            Console.WriteLine($"Number of occurrences of the sequence: {Count}");

            //4
            int[] array1 = { 1, 2, 3, 4, 5 };
            int[] array2 = { 3, 4, 5, 6, 7 };

            int maxLength = array1.Length + array2.Length;
            int[] resultArray = new int[maxLength];

            int index = 0;

            foreach (int num in array1)
            {
                bool contains = false;
                for (int i = 0; i < index; i++)
                {
                    if (resultArray[i] == num)
                    {
                        contains = true;
                        break;
                    }
                }
                if (!contains)
                {
                    resultArray[index] = num;
                    index++;
                }
            }

            foreach (int num in array2)
            {
                bool contains = false;
                for (int i = 0; i < index; i++)
                {
                    if (resultArray[i] == num)
                    {
                        contains = true;
                        break;
                    }
                }
                if (!contains)
                {
                    resultArray[index] = num;
                    index++;
                }
            }

            Console.WriteLine("Result:");
            for (int i = 0; i < index; i++)
            {
                Console.Write(resultArray[i] + " ");
            }
            Console.WriteLine();

            //5
            int[,] array = { {1, 2, 3}, {4, 5, 6}, {7, 8, 9} };

            int min = array[0, 0];
            int max = array[0, 0];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] < min)
                    {
                        min = array[i, j];
                    }
                    if (array[i, j] > max)
                    {
                        max = array[i, j];
                    }
                }
            }

            Console.WriteLine("Min: " + min);
            Console.WriteLine("Max: " + max);

            //6
            Console.WriteLine("Enter a sentence:");
            string sent = Console.ReadLine();

            int wordCount = sent.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Length;

            Console.WriteLine("Number of words in the sentence: " + wordCount);

            //7
            Console.WriteLine("Enter a sentence:");
            string sentence = Console.ReadLine();

            string[] words = sentence.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
            {
                char[] charArray = words[i].ToCharArray();
                int left = 0;
                int right = charArray.Length - 1;

                while (left < right)
                {
                    char temp = charArray[left];
                    charArray[left] = charArray[right];
                    charArray[right] = temp;

                    left++;
                    right--;
                }

                words[i] = new string(charArray);
            }

            string reversedSentence = string.Join(" ", words);
            Console.WriteLine("After reversal: " + reversedSentence);

            //8
            Console.WriteLine("Enter a sentence:");
            string Sentence = Console.ReadLine();

            int vowelCount = 0;
            foreach (char c in Sentence)
            {
                if ("aeiouAEIOU".IndexOf(c) >= 0)
                {
                    vowelCount++;
                }
            }

            Console.WriteLine("Number of vowels in the sentence: " + vowelCount);

            //9
            Console.WriteLine("Enter the input string:");
            string inputString = Console.ReadLine();

            Console.WriteLine("Enter the substring to search for:");
            string searchString = Console.ReadLine();

            int count1 = 0;

            int ind = 0;

            while ((ind = inputString.IndexOf(searchString, ind)) != -1)
            {
                count1++;

                ind += searchString.Length;
            }

            Console.WriteLine("Occurrences of the substring: " + count1);
             
             */

            //HW
            //1
            int[] A = new int[5];
            double[,] B = new double[3, 4];

            Console.WriteLine("Enter 5 integers for array A:");
            for (int i = 0; i < A.Length; i++)
            {
                A[i] = int.Parse(Console.ReadLine());
            }

            Random rnd = new Random();
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    B[i, j] = rnd.NextDouble() * 100;
                }
            }

            Console.WriteLine("Array A:");
            foreach (int num in A)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Array B:");
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    Console.Write(B[i, j] + "\t");
                }
                Console.WriteLine();
            }

            int maxA = A[0];
            double maxB = B[0, 0];

            foreach (int num in A)
            {
                if (num > maxA)
                    maxA = num;
            }

            foreach (double num in B)
            {
                if (num > maxB)
                    maxB = num;
            }

            Console.WriteLine("Common maximum element in both arrays: " + Math.Max(maxA, maxB));

            int minA = A[0];
            double minB = B[0, 0];

            foreach (int num in A)
            {
                if (num < minA)
                    minA = num;
            }

            foreach (double num in B)
            {
                if (num < minB)
                    minB = num;
            }

            Console.WriteLine("Common minimum element in both arrays: " + Math.Min(minA, minB));

            int sumA = 0;
            double sumB = 0;

            foreach (int num in A)
            {
                sumA += num;
            }

            foreach (double num in B)
            {
                sumB += num;
            }

            Console.WriteLine("Common sum of all elements in both arrays: " + (sumA + sumB));

            int productA = 1;
            double productB = 1;

            foreach (int num in A)
            {
                productA *= num;
            }

            foreach (double num in B)
            {
                productB *= num;
            }

            Console.WriteLine("Common product of all elements in both arrays: " + (productA * productB));

            int evenSumA = 0;

            foreach (int num in A)
            {
                if (num % 2 == 0)
                    evenSumA += num;
            }

            Console.WriteLine("Sum of even elements in array A: " + evenSumA);

            double oddColumnsSumB = 0;

            for (int j = 0; j < B.GetLength(1); j++)
            {
                if (j % 2 != 0)
                {
                    for (int i = 0; i < B.GetLength(0); i++)
                    {
                        oddColumnsSumB += B[i, j];
                    }
                }
            }

            Console.WriteLine("Sum of elements in odd columns of array B: " + oddColumnsSumB);

            //2
            int[,] array = new int[5, 5];
            Random rand = new Random();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rand.Next(-100, 101);
                }
            }

            int min = array[0, 0];
            int max = array[0, 0];

            foreach (int num in array)
            {
                if (num < min)
                    min = num;

                if (num > max)
                    max = num;
            }

            int minRow = 0, minCol = 0, maxRow = 0, maxCol = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == min)
                    {
                        minRow = i;
                        minCol = j;
                    }

                    if (array[i, j] == max)
                    {
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }

            int sum = 0;
            int startRow = Math.Min(minRow, maxRow);
            int endRow = Math.Max(minRow, maxRow);
            int startCol = Math.Min(minCol, maxCol);
            int endCol = Math.Max(minCol, maxCol);

            for (int i = startRow; i <= endRow; i++)
            {
                for (int j = startCol; j <= endCol; j++)
                {
                    sum += array[i, j];
                }
            }

            Console.WriteLine("Array:");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Sum of elements between the minimum and maximum elements: " + sum);

            //3
            Console.WriteLine("Enter the text to encrypt:");
            string inputText = Console.ReadLine();

            Console.WriteLine("Enter the shift:");
            int shift = Convert.ToInt32(Console.ReadLine());

            string encryptedText = EncryptCaesar(inputText, shift);
            Console.WriteLine($"Encrypted text: {encryptedText}");

            string decryptedText = DecryptCaesar(encryptedText, shift);
            Console.WriteLine($"Decrypted text: {decryptedText}");

            //4
            Console.WriteLine("Enter dimensions of the first matrix:");
            Console.Write("Rows: ");
            int rows1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Columns: ");
            int cols1 = Convert.ToInt32(Console.ReadLine());

            int[,] matrix1 = ReadMatrix(rows1, cols1);

            Console.WriteLine("Enter dimensions of the second matrix:");
            Console.Write("Rows: ");
            int rows2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Columns: ");
            int cols2 = Convert.ToInt32(Console.ReadLine());

            int[,] matrix2 = ReadMatrix(rows2, cols2);

            Console.WriteLine("\nMatrix 1:");
            PrintMatrix(matrix1);

            Console.WriteLine("\nMatrix 2:");
            PrintMatrix(matrix2);

            Console.WriteLine("\n1. Multiply a matrix by a scalar");
            Console.WriteLine("2. Add two matrices");
            Console.WriteLine("3. Multiply two matrices");
            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter the scalar value: ");
                    int scalar = Convert.ToInt32(Console.ReadLine());
                    int[,] resultScalar = MultiplyByScalar(matrix1, scalar);
                    Console.WriteLine("\nResult of multiplying matrix 1 by scalar:");
                    PrintMatrix(resultScalar);
                    break;
                case 2:
                    int[,] resultAdd = AddMatrices(matrix1, matrix2);
                    Console.WriteLine("\nResult of adding two matrices:");
                    PrintMatrix(resultAdd);
                    break;
                case 3:
                    if (cols1 != rows2)
                    {
                        Console.WriteLine("Matrix multiplication is not possible due to incompatible dimensions.");
                        break;
                    }
                    int[,] resultMultiply = MultiplyMatrices(matrix1, matrix2);
                    Console.WriteLine("\nResult of multiplying two matrices:");
                    PrintMatrix(resultMultiply);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            //5
            Console.WriteLine("Enter an arithmetic expression using only + and - operators:");
            string expression = Console.ReadLine();

            double result = 0;
            char[] delimiters = { '+', '-' };
            string[] elements = expression.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            if (double.TryParse(elements[0], out result) == false)
            {
                Console.WriteLine("Invalid expression format.");
                return;
            }

            int index = 0;
            foreach (char op in expression)
            {
                if (op == '+' || op == '-')
                {
                    double number;
                    if (double.TryParse(elements[index + 1], out number) == false)
                    {
                        Console.WriteLine("Invalid expression format.");
                        return;
                    }

                    if (op == '+')
                        result += number;
                    else if (op == '-')
                        result -= number;

                    index++;
                }
            }

            Console.WriteLine($"Result: {result}");

            //6
            Console.WriteLine("Enter a text:");
            string inputText2 = Console.ReadLine();

            bool capitalizeNext = true;
            foreach (char c in inputText2)
            {
                if (capitalizeNext && char.IsLetter(c))
                {
                    Console.Write(char.ToUpper(c));
                    capitalizeNext = false;
                }
                else
                {
                    Console.Write(c);
                }

                if (c == '.' || c == '?' || c == '!')
                {
                    capitalizeNext = true;
                }
            }
            Console.WriteLine();

            //7
            Console.WriteLine("Enter a text:");
            string inputText1 = Console.ReadLine();

            Console.WriteLine("Enter the list of forbidden words separated by commas:");
            string forbiddenWordsInput = Console.ReadLine();

            string[] forbiddenWords = forbiddenWordsInput.Split(',');

            int totalReplacements = 0;

            foreach (string word in forbiddenWords)
            {
                string trimmedWord = word.Trim();

                int ind = inputText1.IndexOf(trimmedWord, StringComparison.OrdinalIgnoreCase);
                while (ind != -1)
                {
                    inputText1 = inputText1.Remove(ind, trimmedWord.Length).Insert(ind, new string('*', trimmedWord.Length));
                    totalReplacements++;
                    ind = inputText1.IndexOf(trimmedWord, ind + trimmedWord.Length, StringComparison.OrdinalIgnoreCase);
                }
            }

            Console.WriteLine("Result:");
            Console.WriteLine(inputText1);

            Console.WriteLine($"Statistics: {totalReplacements} replacements made.");
        }
    }
}
