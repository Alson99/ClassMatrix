using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixClass
{
    
        class MainProgram
        {

            public static void PrintMatrix(Matrix matrix)
            {
            for (int i = 0; i < matrix.M; ++i)
            {
                for (int j = 0; j < matrix.N; ++j)
                {
                    Console.Write(matrix.Mass[i, j] + "\t");
                }
                Console.WriteLine();
                }
            Console.WriteLine();

            }
           
        static void Main(string[] args)
            {
                double[,] mass1 = new double[2, 2] { { 1, 2}, { 3, 4,} };
                double[,] mass2 = new double[2, 2] { { 3, 2 }, { 2, 5 } };
            
                SquareMatrix test1 = new SquareMatrix(mass1);
                SquareMatrix test2 = new SquareMatrix(mass2);
                //SquareMatrix test3 = new SquareMatrix(mass3);
                Matrix t1 = new Matrix(mass1);
                Matrix t2 = new Matrix(mass2);
                InverseMatrix F1 = new InverseMatrix(mass1);
                InverseMatrix F2 = new InverseMatrix(mass2);
                Console.WriteLine("The matrix A is equal: ");
                PrintMatrix(test1);
                Console.WriteLine("The Determinant of matrix A is: ");
                Console.WriteLine(test1.CalculateDeterminant());
                Console.WriteLine("The matrix B is equal: ");
                PrintMatrix(test2);
                Console.WriteLine("The Determinant of matrix B is: ");
                Console.WriteLine(test2.CalculateDeterminant());
                Console.WriteLine("The inverse of matrix A is: ");    
                InverseMatrix inverseOfMatrixA = new InverseMatrix(mass1);
                PrintMatrix(inverseOfMatrixA.Inverse1());

                Console.WriteLine("The inverse of matrix B is: ");
                InverseMatrix InverseOfMatrixB = new InverseMatrix(mass2);
                PrintMatrix(InverseOfMatrixB.Inverse2());
        }

        }
}