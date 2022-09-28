// Задача 60:
// Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.
// Напишите программу, которая будет построчно выводить массив,
// добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 27(0,0,1) 25(0,1,0) 90(0,1,1)
// 34(1,0,0) 26(1,0,1) 41(1,1,0) 55(1,1,1)

int[] ArrayUniqRndInts(int size, int lowerNum, int upperNum)    // создает 1D массив уникальных чисел в диапазоне [lowerNum;upperNum]
{
    int initSize = upperNum - lowerNum + 1;
    int[] array = new int[initSize];
    int count = lowerNum;
    Random rnd = new Random();

    for (int i = 0; i < initSize; i++)  // создание исходного массива
    {
        array[i] = count;
        count++;
    }

    for (int i = 1; i < array.Length; i++)  // перемешивание исходного массива
    {
        int j = rnd.Next(i + 1);
        int temp = array[j];
        array[j] = array[i];
        array[i] = temp;
    }

    int[] arrayOutput = new int[size];

    for (int i = 0; i < size; i++)
    {
        arrayOutput[i] = array[i];
    }

    return arrayOutput;
}

// void PrintArray(int[] array)
// {
//     Console.Write("[");
//     for (int i = 0; i < array.Length; i++)
//     {
//         if (i < array.Length - 1) Console.Write($"{array[i]}, ");
//         else Console.Write($"{array[i]}");
//     }
//     Console.Write("]");
// }

int[,,] CreateMatrixHundredsInt(int rows, int columns, int depth, int minValue, int maxValue)  // создает 3D массив из чисел [10;99]
{
    int[,,] matrix = new int[rows, columns, depth];
    int[] rndArray = ArrayUniqRndInts(rows * columns * depth, minValue, maxValue);
    int count = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int k = 0; k < matrix.GetLength(2); k++)
            {
                matrix[i, j, k] = rndArray[count];
                count++;
            }
        }
    }
    return matrix;
}

void Print3DMatrixWithId(int[,,] matrix)     // вывод 3D массива в консоль с id
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        // Console.Write("[");
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int k = 0; k < matrix.GetLength(2); k++)
            {
                Console.Write($"{matrix[i, j, k]}({i},{j},{k}) ");
            }
        }
        // Console.WriteLine("]");
        Console.WriteLine();
    }
}

Console.Clear();
Console.WriteLine("Построчный вывод 3D массива неповторяющихся двухзначных чисел с индексами\n"
                + "-------------------------------------------------------------------------");
int[,,] array3D = CreateMatrixHundredsInt(2, 2, 2, 10, 99);
Print3DMatrixWithId(array3D);

// int[] arrayHudredRndInts = ArrayUniqRndInts(8, 10, 99);
// PrintArray(arrayHudredRndInts);
// Console.WriteLine();
