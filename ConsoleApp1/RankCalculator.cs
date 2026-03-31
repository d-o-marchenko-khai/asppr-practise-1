namespace ConsoleApp1;

static class RankCalculator
{
    public static int Calculate(double[,] a, Protocol protocol)
    {
        int n = a.GetLength(0);
        int m = a.GetLength(1);
        double[,] matrix = (double[,])a.Clone();

        protocol.WriteTitle("Обчислення рангу матриці:");
        protocol.WriteInputMatrix("Вхідна матриця А:", a);
        protocol.WriteLine("Протокол обчислення:");

        int rank = 0;
        int steps = Math.Min(n, m);

        for (int i = 0; i < steps; i++)
        {
            if (Math.Abs(matrix[i, i]) < 1e-10)
            {
                protocol.WriteLine($"Крок #{i + 1}");
                protocol.WriteLine($"Елемент А[{i + 1}, {i + 1}] = 0,00 — пропуск");
                continue;
            }

            rank++;
            protocol.WriteStep(i + 1, i + 1, i + 1, matrix[i, i]);
            JordanElimination.Eliminate(matrix, i, i, n, 0, m);
            protocol.WriteMatrix("Матриця після виконання ЗЖВ:", matrix);
        }

        return rank;
    }
}
