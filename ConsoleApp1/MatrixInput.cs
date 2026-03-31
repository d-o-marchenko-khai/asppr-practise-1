using System.Globalization;

namespace ConsoleApp1;

static class MatrixInput
{
    public static int ReadInt(string prompt)
    {
        Console.Write(prompt);
        return int.Parse(Console.ReadLine()!.Trim());
    }

    public static double[,] ReadMatrix(string prompt, int rows, int cols)
    {
        Console.WriteLine(prompt);
        double[,] matrix = new double[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            Console.Write($"  Рядок {i + 1}: ");
            string[] parts = Console.ReadLine()!.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < cols; j++)
                matrix[i, j] = ParseDouble(parts[j]);
        }
        return matrix;
    }

    public static double[] ReadVector(string prompt, int size)
    {
        Console.WriteLine(prompt);
        double[] vector = new double[size];
        for (int i = 0; i < size; i++)
        {
            Console.Write($"  b[{i + 1}]: ");
            vector[i] = ParseDouble(Console.ReadLine()!.Trim());
        }
        return vector;
    }

    private static double ParseDouble(string s)
    {
        return double.Parse(s.Replace(',', '.'), CultureInfo.InvariantCulture);
    }
}
