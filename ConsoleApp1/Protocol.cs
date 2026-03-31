namespace ConsoleApp1;

class Protocol
{
    public void WriteTitle(string text) => Console.WriteLine(text);

    public void WriteLine(string text = "") => Console.WriteLine(text);

    public void WriteStep(int number, int row, int col, double pivot)
    {
        Console.WriteLine($"Крок #{number}");
        Console.WriteLine($"Розв'язувальний елемент: А[{row}, {col}] = {pivot:F2}");
    }

    public void WriteInputMatrix(string label, double[,] matrix)
    {
        Console.WriteLine(label);
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
                Console.Write($"{FormatClean(matrix[i, j]),8}");
            Console.WriteLine();
        }
    }

    public void WriteInputVector(string label, double[] vector)
    {
        Console.WriteLine(label);
        foreach (double v in vector)
            Console.WriteLine(FormatClean(v));
    }

    public void WriteMatrix(string label, double[,] matrix)
    {
        WriteMatrix(label, matrix, matrix.GetLength(0), 0, matrix.GetLength(1));
    }

    public void WriteMatrix(string label, double[,] matrix, int rows, int colStart, int colEnd)
    {
        Console.WriteLine(label);
        for (int i = 0; i < rows; i++)
        {
            for (int j = colStart; j < colEnd; j++)
                Console.Write($"{matrix[i, j],8:F2}");
            Console.WriteLine();
        }
    }

    private static string FormatClean(double value)
    {
        if (Math.Abs(value - Math.Round(value)) < 1e-10)
            return ((long)Math.Round(value)).ToString();
        return value.ToString("F2");
    }
}
