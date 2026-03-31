namespace ConsoleApp1;

static class TestRunner
{
    public static void RunAll()
    {
        TestInverse();
        TestRank();
        TestSlae();
    }

    private static void TestInverse()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("  ТЕСТ: Пошук оберненої матриці");
        Console.WriteLine("========================================\n");

        var p1 = new Protocol();
        double[,] a1 = { { 1, 1, 1 }, { 1, -1, 1 }, { 1, 1, -1 } };
        double[,] c1 = InverseMatrixSolver.Solve(a1, p1);
        p1.WriteMatrix("Обернена матриця С:", c1);

        Console.WriteLine();

        var p2 = new Protocol();
        double[,] a2 = { { 1, -1, 1 }, { 2, 1, -1 }, { 1, 3, -2 } };
        double[,] c2 = InverseMatrixSolver.Solve(a2, p2);
        p2.WriteMatrix("Обернена матриця С:", c2);
    }

    private static void TestRank()
    {
        Console.WriteLine("\n========================================");
        Console.WriteLine("  ТЕСТ: Обчислення рангу матриці");
        Console.WriteLine("========================================\n");

        var p1 = new Protocol();
        double[,] a1 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        int r1 = RankCalculator.Calculate(a1, p1);
        p1.WriteLine($"Ранг матриці: {r1}");

        Console.WriteLine();

        var p2 = new Protocol();
        double[,] a2 = { { 2, -1, 3 }, { 4, -2, 6 }, { 1, 3, -1 } };
        int r2 = RankCalculator.Calculate(a2, p2);
        p2.WriteLine($"Ранг матриці: {r2}");
    }

    private static void TestSlae()
    {
        Console.WriteLine("\n========================================");
        Console.WriteLine("  ТЕСТ: Розв'язання СЛАР (2-й спосіб)");
        Console.WriteLine("========================================\n");

        var p1 = new Protocol();
        double[,] a1 = { { 6, 2, 5 }, { -3, 4, -1 }, { 1, 4, 3 } };
        double[] b1 = { 1, 6, 6 };
        double[] x1 = SlaeSolver.Solve(a1, b1, p1);
        PrintSolution(p1, x1);

        Console.WriteLine();

        var p2 = new Protocol();
        double[,] a2 = { { 5, -3, 7 }, { -1, 4, 3 }, { 6, -2, 5 } };
        double[] b2 = { 13, 13, 12 };
        double[] x2 = SlaeSolver.Solve(a2, b2, p2);
        PrintSolution(p2, x2);

        Console.WriteLine();

        var p3 = new Protocol();
        double[,] a3 = { { 3, 5, 1 }, { -2, 2, -3 }, { 1, 3, -2 } };
        double[] b3 = { 1, 7, 4 };
        double[] x3 = SlaeSolver.Solve(a3, b3, p3);
        PrintSolution(p3, x3);
    }

    private static void PrintSolution(Protocol protocol, double[] x)
    {
        protocol.WriteLine("Розв'язки:");
        for (int i = 0; i < x.Length; i++)
            protocol.WriteLine($"X[{i + 1}] = {x[i]:F2}");
    }
}
