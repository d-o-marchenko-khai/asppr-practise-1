namespace ConsoleApp1;

static class InverseMatrixSolver
{
    public static double[,] Solve(double[,] a, Protocol protocol)
    {
        int n = a.GetLength(0);
        double[,] matrix = (double[,])a.Clone();

        protocol.WriteTitle("Пошук оберненої матриці:");
        protocol.WriteInputMatrix("Вхідна матриця А:", a);
        protocol.WriteLine("Протокол обчислення:");

        for (int i = 0; i < n; i++)
        {
            protocol.WriteStep(i + 1, i + 1, i + 1, matrix[i, i]);
            JordanElimination.Eliminate(matrix, i, i, n, 0, n);
            protocol.WriteMatrix("Матриця після виконання ЗЖВ:", matrix);
        }

        return matrix;
    }
}
