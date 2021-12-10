using System;
using System.Text;

namespace MatrixClass
{
    class Matrix
    {
        // Скрытые поля
         //private int n;

        private double[,] mass;
        public int N
        {
            get => mass.GetLength(1);
        }
        public int M
        {
            get => mass.GetLength(0);
        }

        public double[,] Mass => (double[,])mass.Clone();

        // Создаем конструкторы матрицы
        public Matrix() { }
       

        // Задаем аксессоры для работы с полями вне класса Matrix
        public Matrix(int m, int n)
        {
           // this.n = n;
            mass = new double[m, n];
        }

        public Matrix (double[,] mass)
        {
            this.mass = mass;
        }

        // La copie de la matrice avec un constructeur
        public Matrix (Matrix copy)
        {
            this.mass = (double[,])copy.mass.Clone();
        }
        public double this[int i, int j]
        {
            get
            {
                return mass[i, j];
            }
            set
            {
                mass[i, j] = value;
            }
        }

        /*// Ввод матрицы с клавиатуры
        public void ReadMat()
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.WriteLine("Введите элемент матрицы {0}:{1}", i + 1, j + 1);
                    mass[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }*/

        // Вывод матрицы с клавиатуры
       /* public void WriteMat()
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(mass[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }*/


        // Проверка матрицы А на единичность
   /*     public void oneMat(Matrix a)
        {
            int count = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (a[i, j] == 1 && i == j)
                    {
                        count++;
                    }
                }

            }
            if (count == a.N)
            {
                Console.WriteLine("Единичная");
            }
            else Console.WriteLine("Не единичная");
        }*/

        // Умножение матрицы А на число
        public static Matrix operator *(Matrix a, double ch)
        {
            Matrix resMass = new Matrix(a.M, a.N);
            for (int i = 0; i < a.M; i++)
            {
                for (int j = 0; j < a.N; j++)
                {
                    resMass[i, j] = a[i, j] * ch;
                }
            }
            return resMass;
        }

        // Умножение матрицы А на матрицу Б
        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.N != b.M)
                throw new Exception("There is an error");
            Matrix resMass = new Matrix(a.M, a.N);
            for (int i = 0; i < a.M; i++)
                for (int j = 0; j < b.N; j++)
                    for (int k = 0; k < b.N; k++)
                        resMass[i, j] += a[i, k] * b[k, j];

            return resMass;
        }


        /*
        // перегрузка оператора умножения
        public static Matrix operator *(Matrix a, Matrix b)
        {
            return Matrix.times(a, b);
        }

        public static Matrix operator *(Matrix a, int b)
        {
            return Matrix.times1(a, b);
        }
        */

        // Метод вычитания матрицы Б из матрицы А
        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.N != b.N || a.M != b.M)
                throw new Exception(" There is an error");
            Matrix resMass = new Matrix(a.M, a.N);
            for (int i = 0; i < a.M; i++)
            {
                for (int j = 0; j < b.N; j++)
                {
                    resMass[i, j] = a[i, j] - b[i, j];
                }
            }
            return resMass;
        }

        // Перегрузка оператора вычитания
        /*public static Matrix operator -(Matrix a, Matrix b)
        {
            return Matrix.minus(a, b);
        }*/
        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.N != b.N || a.M != b.M)
                throw new Exception(" There is an error");
            Matrix resMass = new Matrix(a.M, a.N);
            for (int i = 0; i < a.M; i++)
            {
                for (int j = 0; j < b.N; j++)
                {
                    resMass[i, j] = a[i, j] + b[i, j];
                }
            }
            return resMass;
        }
        /*
        // Перегрузка сложения
        public static Matrix operator +(Matrix a, Matrix b)
        {
            return Matrix.Sum(a, b);
        } */
/*
        public static Matrix Division(Matrix a, Matrix b)
        {

            int row = a.mass.GetLength(0);
            int col = a.mass.GetLength(1);
            double[,] newMatrix = new double[row, col];
            for (int i = 0; i < row; i++)
                for (int j = 0; j < col; j++)
                    newMatrix[i, j] = a[i, j] / b[i,j];
            return new Matrix();

        }

        public static Matrix operator /(Matrix a, Matrix b)
        {
            return Matrix.Division(a, b);
        }*/

        //Let's create the function to calculate the transpose of matrix
        public static Matrix operator ~(Matrix a)
        {
            Matrix temp = new Matrix(a.M, a.N);
            for (int i = 0; i < a.M; i++)
            {
                for (int j = 0; j < a.N; j++)
                {
                    temp[j, i] = a[i, j];
                }
            }
            return temp;
        }

        internal Matrix CreateMatrixWithoutColumn(int column)
        {
            if (column < 0 || column >= this.N)
                throw new Exception("Invalid column index");
            var matrix = new Matrix(this.M, this.N - 1);
            for (int i = 0; i < this.M; ++i)
                for (int j = 0; j < this.N - 1; ++j)
                    matrix[i, j] = j < column ? this.mass[i, j] : this.mass[i, j + 1];
            return matrix;
        }

        internal Matrix CreateMatrixWithoutRow(int row)
        {
            if (row < 0 || row >= this.M)
                throw new Exception("Invalid column index");
            var matrix = new Matrix(this.M - 1, this.N);
            for (int i = 0; i < this.M - 1; ++i)
                for (int j = 0; j < this.N; ++j)
                    matrix[i, j] = i < row ? this.mass[i, j] : this.mass[i + 1, j];
            return matrix;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("N=" + N.ToString() + "M=" + M.ToString() + ",Data= ");
            for(int i= 0; i< N; i++)
            {
                for (int j = 0; j < M; j++) sb.AppendFormat("{0:G17}", mass[i,j] + " " );
                sb.Append( " | " );
            }
            return base.ToString();
        }
    }
 
}
