using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Dictionary<string, int[]> temperatureData = CreateTemperatureData();
        double[] averageTemperatures = CalculateAverageTemperatures(temperatureData);
        Console.WriteLine("Средняя температура по месяцам:");
        foreach (var entry in temperatureData)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value.Average():F2}°C");
        }
        Array.Sort(averageTemperatures);
        Console.WriteLine("\nОтсортированные средние температуры по возрастанию:");
        foreach (var average in averageTemperatures)
        {
            Console.WriteLine($"{average:F2}°C");
        }
    }
    static Dictionary<string, int[]> CreateTemperatureData()
    {
        string[] months = {
            "Январь", "Февраль", "Март", "Апрель",
            "Май", "Июнь", "Июль", "Август",
            "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"
        };
        Dictionary<string, int[]> temperatureData = new Dictionary<string, int[]>();
        Random random = new Random();
        foreach (var month in months)
        {
            int[] temperatures = new int[30];
            for (int day = 0; day < 30; day++)
            {
                temperatures[day] = random.Next(-10, 36);
            }
            temperatureData[month] = temperatures;
        }
        return temperatureData;
    }
    static double[] CalculateAverageTemperatures(Dictionary<string, int[]> temperatureData)
    {
        double[] averages = new double[temperatureData.Count];
        int index = 0;
        foreach (var temperatures in temperatureData.Values)
        {
            averages[index++] = temperatures.Average();
        }
        return averages;
    }
}
