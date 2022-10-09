namespace KrammerMethod
{
    internal class Program
    {

        public static double[,] GetMinor(double[,] matrix, int row, int column)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                throw new Exception(" Число строк в матрице не совпадает с числом столбцов");
            }

            double[,] buf = new double[matrix.GetLength(0) - 1, matrix.GetLength(0) - 1];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((i != row) || (j != column))
                    {
                        if (i > row && j < column)
                        {
                            buf[i - 1, j] = matrix[i, j];
                        }
                        if (i < row && j > column)
                        {
                            buf[i, j - 1] = matrix[i, j];
                        }
                        if (i > row && j > column)
                        {
                            buf[i - 1, j - 1] = matrix[i, j];
                        }
                        if (i < row && j < column)
                        {
                            buf[i, j] = matrix[i, j];
                        }
                    }
                }
            }
            return buf;
        }

        public static double Determ(double[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                throw new Exception(" Число строк в матрице не совпадает с числом столбцов");
            }

            double det = 0;

            int Rank = matrix.GetLength(0);

            if (Rank == 1)
            {
                det = matrix[0, 0];
            }
            if (Rank == 2)
            {
                det = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }
            if (Rank > 2)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    det += Math.Pow(-1, 0 + j) * matrix[0, j] * Determ(GetMinor(matrix, 0, j));
                }
            }
            return det;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Insert matrix size");
            int n = int.Parse(Console.ReadLine());
            double[,] matrix = new double[n, n];
            double[] freedigits = new double[n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("Matrix[" + i + ", " + j + "] = ");
                    matrix[i, j] = double.Parse(Console.ReadLine());
                }
            }

            double det = Determ(matrix);

            Console.WriteLine("Determinant of matrix = " + Math.Round(det, 3));

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}