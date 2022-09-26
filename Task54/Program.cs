// Задача 54: 
// Задайте двумерный массив. Напишите программу, 
// которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

int GeneratorRandomInt(int minValue, int maxValue)  // генератор Random int в диапазоне [min,max]
{
    Random rnd = new Random();
    return rnd.Next(minValue, maxValue + 1);
}

int[,] CreateMatrixRndInt(int rows, int columns, int min, int max)  // создает массив
{
    int[,] matrix = new int[rows, columns];

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = GeneratorRandomInt(min, max);
        }
    }
    return matrix;
}

void PrintMatrix(int[,] matrix)     // вывод 2D массива в консоль
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        // Console.Write("[");
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (j < matrix.GetLength(1) - 1) Console.Write($"{matrix[i, j],2} ");
            else Console.Write($"{matrix[i, j],2}");
        }
        // Console.WriteLine("]");
        Console.WriteLine();
    }
}

void SortRowsMaxToMinInArray2D(int[,] matrix) // сортировка элементов в строке 2D массива от max к min
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            int maxPosition = j;
            for (int k = j + 1; k < matrix.GetLength(1); k++)
            {
                if (matrix[i, k] > matrix[i, maxPosition]) maxPosition = k;
            }
            int temporary = matrix[i, j];
            matrix[i, j] = matrix[i, maxPosition];
            matrix[i, maxPosition] = temporary;
        }
    }
}


Console.Clear();
int matrixSizeMin = 3;
int matrixSizeMax = 4;
int matrixElemMin = -9;
int matrixElemMax = 9;
int matrixRows;
int matrixCols;
// while (true) // для прямоугольной матрицы
// {
//     matrixRows = GeneratorRandomInt(matrixSizeMin, matrixSizeMax);
//     matrixCols = GeneratorRandomInt(matrixSizeMin, matrixSizeMax);
//     if (matrixRows != matrixCols) break;
// }

matrixRows = GeneratorRandomInt(matrixSizeMin, matrixSizeMax);
matrixCols = GeneratorRandomInt(matrixSizeMin, matrixSizeMax);
int[,] array2D = CreateMatrixRndInt(matrixRows, matrixCols, matrixElemMin, matrixElemMax);

// тестовый массив
// int[,] array2D = {
//     {0,1,2},
//     {5,7,5},
//     {6,1,8}
//     };

Console.WriteLine("Исходный массив:");
PrintMatrix(array2D);
Console.WriteLine();

SortRowsMaxToMinInArray2D(array2D);
Console.WriteLine("Отсортированный массив:");
PrintMatrix(array2D);
