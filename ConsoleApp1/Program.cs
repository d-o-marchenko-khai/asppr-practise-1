using System.Globalization;
using System.Text;

namespace ConsoleApp1;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
        CultureInfo.CurrentCulture = new CultureInfo("uk-UA");

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("=== Звичайні жорданові виключення ===");
            Console.WriteLine("1. Пошук оберненої матриці");
            Console.WriteLine("2. Обчислення рангу матриці");
            Console.WriteLine("3. Розв'язання СЛАР (2-й спосіб)");
            Console.WriteLine("4. Тестові обчислення");
            Console.WriteLine("0. Вихід");
            Console.Write("Оберіть пункт меню: ");

            string? choice = Console.ReadLine()?.Trim();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    RunInverse();
                    break;
                case "2":
                    RunRank();
                    break;
                case "3":
                    RunSlae();
                    break;
                case "4":
                    TestRunner.RunAll();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Невірний вибір.");
                    break;
            }
        }
    }

    static void RunInverse()
    {
        int n = MatrixInput.ReadInt("Введіть розмірність матриці n: ");
        double[,] a = MatrixInput.ReadMatrix("Введіть матрицю А:", n, n);

        var protocol = new Protocol();
        double[,] result = InverseMatrixSolver.Solve(a, protocol);
        protocol.WriteMatrix("Обернена матриця С:", result);
    }

    static void RunRank()
    {
        int n = MatrixInput.ReadInt("Введіть кількість рядків n: ");
        int m = MatrixInput.ReadInt("Введіть кількість стовпців m: ");
        double[,] a = MatrixInput.ReadMatrix("Введіть матрицю А:", n, m);

        var protocol = new Protocol();
        int rank = RankCalculator.Calculate(a, protocol);
        protocol.WriteLine($"Ранг матриці: {rank}");
    }

    static void RunSlae()
    {
        int n = MatrixInput.ReadInt("Введіть розмірність системи n: ");
        double[,] a = MatrixInput.ReadMatrix("Введіть матрицю А:", n, n);
        double[] b = MatrixInput.ReadVector("Введіть вектор В:", n);

        var protocol = new Protocol();
        double[] x = SlaeSolver.Solve(a, b, protocol);

        protocol.WriteLine("Розв'язки:");
        for (int i = 0; i < x.Length; i++)
            protocol.WriteLine($"X[{i + 1}] = {x[i]:F2}");
    }
}
