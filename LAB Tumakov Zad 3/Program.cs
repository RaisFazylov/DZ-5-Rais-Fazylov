using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Задание 3 Тумакова");
        /* Написать программу, вычисляющую среднюю температуру за год. Создать
        двумерный рандомный массив temperature[12,30], в котором будет храниться температура
        для каждого дня месяца (предполагается, что в каждом месяце 30 дней). Сгенерировать
        значения температур случайным образом. Для каждого месяца распечатать среднюю
        температуру. Для этого написать метод, который по массиву temperature [12,30] для каждого
        месяца вычисляет среднюю температуру в нем, и в качестве результата возвращает массив
        средних температур. Полученный массив средних температур отсортировать по
        возрастанию.
        */
        int[,] temperature = new int[12, 30];
        Random random = new Random();
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 30; j++)
            {
                temperature[i, j] = random.Next(-10, 36);
            }
        }
        double[] averageTemperatures = CalculateAverageTemperatures(temperature);
        Console.WriteLine("Средняя температура за год по месяцам:");
        for (int i = 0; i < averageTemperatures.Length; i++)
        {
            Console.WriteLine($"Месяц {i + 1}: {averageTemperatures[i]:F2}°C");
        }
        Array.Sort(averageTemperatures);
        Console.WriteLine("\nОтсортированные средние температуры по возрастанию:");
        for (int i = 0; i < averageTemperatures.Length; i++)
        {
            Console.WriteLine($"Месяц {i + 1}: {averageTemperatures[i]:F2}°C");
        }
    }
    static double[] CalculateAverageTemperatures(int[,] temperatures)
    {
        double[] averages = new double[12];

        for (int i = 0; i < 12; i++)
        {
            double sum = 0;

            for (int j = 0; j < 30; j++)
            {
                sum += temperatures[i, j];
            }
            averages[i] = sum / 30;
        }
        return averages;
    }
}
