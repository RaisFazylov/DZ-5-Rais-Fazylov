using System;

class Program
{
    static void Main()
    {
        onsole.WriteLine("Задание 2 Тумакова");
        /* Написать программу, реализующую умножению двух матриц, заданных в
        виде двумерного массива. В программе предусмотреть два метода: метод печати матрицы,
        метод умножения матриц (на вход две матрицы, возвращаемое значение – матрица).
        */
        int[,] matrixA = {
            { 1, 2, 3 },
            { 4, 5, 6 }
        };
        int[,] matrixB = {
            { 7, 8 },
            { 9, 10 },
            { 11, 12 }
        };
        int[,] resultMatrix = MultiplyMatrices(matrixA, matrixB);
        Console.WriteLine("Матрица A:");
        PrintMatrix(matrixA);
        Console.WriteLine("Матрица B:");
        PrintMatrix(matrixB);
        Console.WriteLine("Результат A * B:");
        PrintMatrix(resultMatrix);
    }
    static void PrintMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
    static int[,] MultiplyMatrices(int[,] matrixA, int[,] matrixB)
    {
        int aRows = matrixA.GetLength(0);
        int aCols = matrixA.GetLength(1);
        int bRows = matrixB.GetLength(0);
        int bCols = matrixB.GetLength(1);
        if (aCols != bRows)
        {
            throw new ArgumentException("Количество столбцов первой матрицы должно быть равно количеству строк второй матрицы.");
        }
        int[,] result = new int[aRows, bCols];
        for (int i = 0; i < aRows; i++)
        {
            for (int j = 0; j < bCols; j++)
            {
                for (int k = 0; k < aCols; k++)
                {
                    result[i, j] += matrixA[i, k] * matrixB[k, j];
                }
            }
        }
        return result;
    }
}
