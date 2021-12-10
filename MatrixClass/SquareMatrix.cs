using System;

namespace MatrixClass
{
    class SquareMatrix: Matrix
    {
        public SquareMatrix(int n) : base(n, n) {}
        
        public SquareMatrix(double[,] mass) : base(mass) 
        {
            if (mass.GetLength(0) != mass.GetLength(1))
                throw new Exception("Your matrix is not square !");
        }

        public SquareMatrix(Matrix matrix) : base (matrix)
        {
            if (matrix.N != matrix.M)
                throw new Exception("The matrix has different columns! ");
        }

        /*public static double[,] FindMinor(double[,] matrix, int row, int column)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1)) throw new Exception(" Число строк в матрице не совпадает с числом столбцов");
            double[,] buf = new double[matrix.GetLength(0) - 1, matrix.GetLength(0) - 1];
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((i != row) || (j != column))
                    {
                        if (i > row && j < column) buf[i - 1, j] = matrix[i, j];
                        if (i < row && j > column) buf[i, j - 1] = matrix[i, j];
                        if (i > row && j > column) buf[i - 1, j - 1] = matrix[i, j];
                        if (i < row && j < column) buf[i, j] = matrix[i, j];
                    }
                }
            return buf;
        }*/

     /*   public double Determ(double[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1)) throw new Exception(" Число строк в матрице не совпадает с числом столбцов");
            double det = 0;
            int Rank = matrix.GetLength(0);
            if (Rank == 1) det = matrix[0, 0];
            if (Rank == 2) det = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            if (Rank > 2)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    det += Math.Pow(-1, 0 + j) * matrix[0, j] * Determ(FindMinor(matrix, 0, j));
                }
            }
            return det;
        }*/

        public double CalculateDeterminant()
        {
            if (this.N == 1) return Mass[0, 0];
            if (this.N == 2) return Mass[0, 0] * Mass[1, 1] - Mass[1, 0] * Mass[0, 1];
            double result = 0;
            for (int j = 0; j < this.N; ++j)
            {
                SquareMatrix M = new SquareMatrix(this.CreateMatrixWithoutColumn(j).CreateMatrixWithoutRow(1));
                result += (j % 2 == 1 ? 1 : -1) * Mass[1, j] * M.CalculateDeterminant();
            }
            return result;
        }

    }
}
