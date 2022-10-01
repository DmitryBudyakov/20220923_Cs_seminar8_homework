// Задача 56:
// Задайте прямоугольный двумерный массив. 
// Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке
// и выдаёт номер строки с наименьшей суммой элементов: 1 строка

int GeneratorRandomInt(int minValue, int maxValue)  // генератор Random int в диапазоне [min,max]
{
    Random rnd = new Random();
    return rnd.Next(minValue, maxValue + 1);
}

int[,] CreateMatrixRndInt(int rows, int columns, int min, int max)  // создает массив
{
    int[,] matrix = new int[rows, columns];
    Random rnd = new Random();

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            // matrix[i, j] = GeneratorRandomInt(min, max);
            matrix[i, j] = rnd.Next(min, max + 1);
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
            if (j < matrix.GetLength(1) - 1) Console.Write($"{matrix[i, j]} ");
            else Console.Write($"{matrix[i, j]}");
        }
        // Console.WriteLine("]");
        Console.WriteLine();
    }
}

int SearchMinRowInArray2D(int[,] matrix) // находит Row с min суммой элементов в 2D массиве
{
    int minRow = 0;
    int minSum = 0;

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        int tempSum = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            tempSum += matrix[i, j];

        }
        // Console.WriteLine($"row: {i}, tempSum: {tempSum}");
        if (i == 0) minSum = tempSum;
        else
        {
            if (tempSum < minSum)
            {
                minSum = tempSum;
                minRow = i;
            }
        }
        // Console.WriteLine($"row: {i}, minSum: {minSum}");   // проверка
    }
    return minRow + 1;
}


Console.Clear();
string title = "Нахождение строки с наименьшей суммой элементов\n"
             + "-----------------------------------------------";
Console.WriteLine(title);

int matrixSizeMin = 3;
int matrixSizeMax = 4;
int matrixElemMin = 0;
int matrixElemMax = 9;
int matrixRows;
int matrixCols;
while (true)
{
    matrixRows = GeneratorRandomInt(matrixSizeMin, matrixSizeMax);
    matrixCols = GeneratorRandomInt(matrixSizeMin, matrixSizeMax);
    if (matrixRows != matrixCols) break;
}

int[,] array2D = CreateMatrixRndInt(matrixRows, matrixCols, matrixElemMin, matrixElemMax);

// тестовый массив
// int[,] array2D = {
//     {10,3,2},
//     {5,11,5},
//     {6,1,3}
//     };

Console.WriteLine("Массив:");
PrintMatrix(array2D);
Console.WriteLine();

int minRowNum = SearchMinRowInArray2D(array2D);
Console.WriteLine($"Строка с минимальной суммой: {minRowNum}");
