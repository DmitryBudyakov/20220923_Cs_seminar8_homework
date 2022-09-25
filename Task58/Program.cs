// Задача 58:
// Задайте две матрицы. 
// Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

// Правило умножения матриц:
// (1) Матрицу A можно умножить на матрицу B только в том случае,
// если число столбцов матрицы A равняется числу строк матрицы B.
// (2) Произведение матрицы A размера m × n и матрицы B размера n × k —
// это матрица C размера m × k, в которой
// элемент Cij ​равен сумме произведений элементов i cтроки матрицы A на
// соответствующие элементы j столбца матрицы B​.


const int printFieldWidth = 2;

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
            if (j < matrix.GetLength(1) - 1) Console.Write($"{matrix[i, j],printFieldWidth} ");
            else Console.Write($"{matrix[i, j],printFieldWidth}");
        }
        // Console.WriteLine("]");
        Console.WriteLine();
    }
}

int[,] MultiplyArray2D(int[,] matrixA, int[,] matrixB) // перемножает две 2D матрицы
{
    int[,] matrixResult = new int[matrixA.GetLength(0), matrixB.GetLength(1)];
    int arrayAcolumns = matrixA.GetLength(1);
    int arrayBrows = matrixB.GetLength(0);

    for (int i = 0; i < matrixResult.GetLength(0); i++)
    {
        for (int j = 0; j < matrixResult.GetLength(1); j++)
        {
            int sumInRow = 0;
            int l = 0;
            for (int k = 0; k < arrayAcolumns; k++)
            {
                sumInRow += matrixA[i, k] * matrixB[l, j];
                // Console.WriteLine($"i:{i}, j:{j}, k:{k}, l:{l}, matrixA[{i},{k}]:{matrixA[i, k]}, matrixB[{l},{j}]:{matrixB[l, j]}, sumInRow: {sumInRow}");  // проверка
                if (l != arrayBrows - 1) l++;
                else l = 0;
            }
            matrixResult[i, j] = sumInRow;
            // Console.WriteLine($"i:{i}, j:{j}, sumInRow:{sumInRow}"); // проверка
        }
    }
    return matrixResult;
}


Console.Clear();
int matrixSizeMin = 2;
int matrixSizeMax = 3;
int matrixElemMin = 1;
int matrixElemMax = 4;
int matrixRows;
int matrixCols;
// while (true)    // для прямоугольной матрицы
// {
//     matrixRows = GeneratorRandomInt(matrixSizeMin, matrixSizeMax);
//     matrixCols = GeneratorRandomInt(matrixSizeMin, matrixSizeMax);
//     if (matrixRows != matrixCols) break;
// }

matrixRows = GeneratorRandomInt(matrixSizeMin, matrixSizeMax);
matrixCols = GeneratorRandomInt(matrixSizeMin, matrixSizeMax);
int[,] arrayA = CreateMatrixRndInt(matrixRows, matrixCols, matrixElemMin, matrixElemMax);
int[,] arrayB = CreateMatrixRndInt(matrixRows, matrixCols, matrixElemMin, matrixElemMax);

// тестовые массивы
// int[,] arrayA = {
//     {2,4},
//     {3,2},
//     // {1,2},
//     };

// int[,] arrayB = {
//     {3,4},
//     {3,3},
//     };


Console.Clear();
Console.WriteLine("-----------------");
Console.WriteLine("Умножение матриц:");
Console.WriteLine("-----------------");
Console.WriteLine("Матрица A:");
PrintMatrix(arrayA);
Console.WriteLine("Матрица B:");
PrintMatrix(arrayB);
Console.WriteLine();

if (arrayA.GetLength(0) == arrayB.GetLength(1))

{
    int[,] arrayC = MultiplyArray2D(arrayA, arrayB);
    Console.WriteLine("Матрица C:");
    PrintMatrix(arrayC);
}
else
{
    string errorMsg = "Матрицу A можно умножить на матрицу B только в том случае,"
                    + "если число столбцов матрицы A равняется числу строк матрицы B.";
    Console.WriteLine("Матрицы нельзя перемножить.");
    Console.WriteLine("Условие умножения матриц:");
    Console.WriteLine(errorMsg);
}
