using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Задание 5 Тумакова");
        // Упражнение 2 выполнить с помощью коллекций LinkedList<LinkedList<T>>.
        LinkedList<LinkedList<int>> matrixA = CreateMatrix(new int[,] { { 1, 2, 3 }, { 4, 5, 6 } });
        LinkedList<LinkedList<int>> matrixB = CreateMatrix(new int[,] { { 7, 8 }, { 9, 10 }, { 11, 12 } });
        LinkedList<LinkedList<int>> resultMatrix = MultiplyMatrices(matrixA, matrixB);
        Console.WriteLine("Матрица A:");
        PrintMatrix(matrixA);
        Console.WriteLine("Матрица B:");
        PrintMatrix(matrixB);
        Console.WriteLine("Результат A * B:");
        PrintMatrix(resultMatrix);
    }
    static LinkedList<LinkedList<int>> CreateMatrix(int[,] array)
    {
        var matrix = new LinkedList<LinkedList<int>>();

        for (int i = 0; i < array.GetLength(0); i++)
        {
            var row = new LinkedList<int>();
            for (int j = 0; j < array.GetLength(1); j++)
            {
                row.AddLast(array[i, j]);
            }
            matrix.AddLast(row);
        }

        return matrix;
    }
    static void PrintMatrix(LinkedList<LinkedList<int>> matrix)
    {
        foreach (var row in matrix)
        {
            foreach (var value in row)
            {
                Console.Write(value + "\t");
            }
            Console.WriteLine();
        }
    }
    static LinkedList<LinkedList<int>> MultiplyMatrices(LinkedList<LinkedList<int>> matrixA, LinkedList<LinkedList<int>> matrixB)
    {
        int rowsA = matrixA.Count;
        int colsA = matrixA.First.Value.Count;
        int rowsB = matrixB.Count;
        int colsB = matrixB.First.Value.Count;
        if (colsA != rowsB)
        {
            throw new ArgumentException("Количество столбцов первой матрицы должно быть равно количеству строк второй матрицы.");
        }
        var result = new LinkedList<LinkedList<int>>();
        for (int i = 0; i < rowsA; i++)
        {
            var row = new LinkedList<int>();
            for (int j = 0; j < colsB; j++)
            {
                int sum = 0;
                var currentRowA = matrixA.First;
                for (int k = 0; k < colsA; k++)
                {
                    sum += currentRowA.Value.ElementAt(k) * matrixB.ElementAt(k).ElementAt(j);
                    currentRowA = currentRowA.Next;
                }
                row.AddLast(sum);
            }
            result.AddLast(row);
        }
        return result;
    }
}
