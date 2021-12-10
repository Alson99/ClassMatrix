using System;
namespace MatrixClass
{
    class InverseMatrix: SquareMatrix 
    {
        public InverseMatrix(double[,] mass) : base(mass) 
        {
            SquareMatrix square = new SquareMatrix(mass);
            if (square.CalculateDeterminant() == 0)
                throw new Exception("The determinant is equal to 0 ");
        }

        public InverseMatrix(Matrix m) : base(m)
        {
            if (CalculateDeterminant() != 0)
                throw new Exception("The matrix has different columns! ");
        }
        public InverseMatrix(int n) : base(n) { }

        // Метод вычисления обратной матрицы Гаусса-Жордана
        /*  public  int[,] GaussJordan(int[,] Matrix)
           {
               int n = Matrix.GetLength(0); //Размерность начальной матрицы

               int[,] xirtaM = new int[n, n]; //Единичная матрица (искомая обратная матрица)
               for (int i = 0; i < n; i++)
                   xirtaM[i, i] = 1;

               int[,] Matrix_Big = new int[n, 2 * n]; //Общая матрица, получаемая скреплением Начальной матрицы и единичной
               for (int i = 0; i < n; i++)
                   for (int j = 0; j < n; j++)
                   {
                       Matrix_Big[i, j] = Matrix[i, j];
                       Matrix_Big[i, j + n] = xirtaM[i, j];
                   }

               //Прямой ход (Зануление нижнего левого угла)
               for (int k = 0; k < n; k++) //k-номер строки
               {
                   for (int i = 0; i < 2 * n; i++) //i-номер столбца
                       Matrix_Big[k, i] = Matrix_Big[k, i] / Matrix[k, k]; //Деление k-строки на первый член !=0 для преобразования его в единицу
                   for (int i = k + 1; i < n; i++) //i-номер следующей строки после k
                   {
                       int K = Matrix_Big[i, k] / Matrix_Big[k, k]; //Коэффициент
                       for (int j = 0; j < 2 * n; j++) //j-номер столбца следующей строки после k
                           Matrix_Big[i, j] = Matrix_Big[i, j] - Matrix_Big[k, j] * K; //Зануление элементов матрицы ниже первого члена, преобразованного в единицу
                   }
                   for (int i = 0; i < n; i++) //Обновление, внесение изменений в начальную матрицу
                       for (int j = 0; j < n; j++)
                           Matrix[i, j] = Matrix_Big[i, j];
               }

               //Обратный ход (Зануление верхнего правого угла)
               for (int k = n - 1; k > -1; k--) //k-номер строки
               {
                   for (int i = 2 * n - 1; i > -1; i--) //i-номер столбца
                       Matrix_Big[k, i] = Matrix_Big[k, i] / Matrix[k, k];
                   for (int i = k - 1; i > -1; i--) //i-номер следующей строки после k
                   {
                       int K = Matrix_Big[i, k] / Matrix_Big[k, k];
                       for (int j = 2 * n - 1; j > -1; j--) //j-номер столбца следующей строки после k
                           Matrix_Big[i, j] = Matrix_Big[i, j] - Matrix_Big[k, j] * K;
                   }
               }

               //Отделяем от общей матрицы
               for (int i = 0; i < n; i++)
                   for (int j = 0; j < n; j++)
                       xirtaM[i, j] = Matrix_Big[i, j + n];

               return xirtaM;
           }
*/
       /* public InverseMatrix(Matrix m) : base(m)
        {
            
        }*/

        public InverseMatrix Inverse1()
        {
            double det = this.CalculateDeterminant();
            double[,] res = new double[this.M, this.M];
            for (int i = 0; i < this.M; ++i)
                for (int j = 0; j < this.M; ++j)
                {
                    var temp =  this.CreateMatrixWithoutRow(i).CreateMatrixWithoutColumn(j);
                    SquareMatrix sm = new SquareMatrix(temp);
                    var A = ((i+j)%2 == 0? 1 : -1) * sm.CalculateDeterminant();
                    res[i, j] = A;
                }
                Matrix m = new Matrix(res);
                InverseMatrix answer = new InverseMatrix((~m)*(double)(-0.5));
                return answer;
        }

        public InverseMatrix Inverse2()
        {
            double det = this.CalculateDeterminant();
            double[,] res = new double[this.M, this.M];
            for (int i = 0; i < this.M; ++i)
                for (int j = 0; j < this.M; ++j)
                {
                    var temp = this.CreateMatrixWithoutRow(i).CreateMatrixWithoutColumn(j);
                    SquareMatrix sm = new SquareMatrix(temp);
                    var A = ((i + j) % 2 == 0 ? 1 : -1) * sm.CalculateDeterminant();
                    res[i, j] = A;
                }
                Matrix m = new Matrix(res);
                InverseMatrix answer = new InverseMatrix((~m) * (double)(0.9));
                return answer;
        }

    }
}
