namespace ConsoleApp1;

static class SlaeSolver
{
    public static double[] Solve(double[,] a, double[] b, Protocol protocol)
    {
        int n = a.GetLength(0);

        // Формування розширеної матриці [A | -B]
        double[,] matrix = new double[n, n + 1];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
                matrix[i, j] = a[i, j];
            matrix[i, n] = -b[i];
        }

        protocol.WriteTitle("Знаходження розв'язків СЛАУ 2-м методом:");
        protocol.WriteInputMatrix("Вхідна матриця А:", a);
        protocol.WriteInputVector("Вхідна матриця В:", b);
        protocol.WriteLine("Протокол обчислення:");
        protocol.WriteInputMatrix("Переписана система:", matrix);

        int colStart = 0;

        for (int step = 0; step < n; step++)
        {
            protocol.WriteStep(step + 1, step + 1, 1, matrix[step, colStart]);

            JordanElimination.Eliminate(matrix, step, colStart, n, colStart, n + 1);

            // Зміна знаку елементів розв'язувального рядка (крім стовпця, що викреслюється)
            for (int j = colStart + 1; j <= n; j++)
                matrix[step, j] = -matrix[step, j];

            colStart++;

            protocol.WriteMatrix("Матриця після виконання ЗЖВ:", matrix, n, colStart, n + 1);
        }

        double[] x = new double[n];
        for (int i = 0; i < n; i++)
            x[i] = matrix[i, n];

        return x;
    }
}
