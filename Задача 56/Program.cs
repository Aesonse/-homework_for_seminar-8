/*Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка
*/

using System;
using static System.Console;

Clear();

int row = DataInput("количество строк");
int col = DataInput("количество столбцов");
int[,] matrix = CreateIntMatrix(row, col, 1, 10);
PrintIntMatrix(matrix);
WriteLine();
PrintMinSumRowNumber(matrix);


int DataInput(string message)
{
    Write("Введите " + message + ": ");
    int result = int.Parse(ReadLine());
    return result;
}

void PrintIntMatrix(int[,] mtx)
{
    for (int i = 0; i < mtx.GetLength(0); i++)
    {
        Write("[ ");
        for (int j = 0; j < mtx.GetLength(1); j++)
            Write($"{mtx[i, j]} ");
        WriteLine("]");
    }
}

int[,] CreateIntMatrix(int row, int col, int minValue, int maxValue)
{
    int[,] result = new int[row, col];
    for (int i = 0; i < row; i++)
        for (int j = 0; j < col; j++)
            result[i, j] = new Random().Next(minValue, maxValue);
    return result;
}

void PrintMinSumRowNumber(int[,] mtx)
{
    int[] Sum = new int[mtx.GetLength(0)];

    for (int i = 0; i < mtx.GetLength(0); i++)
    {
        for (int j = 0; j < mtx.GetLength(1); j++)
        {
            Sum[i] += mtx[i, j];
        }
    }
    int result = 0;
    for (int i = 1; i < mtx.GetLength(0); i++)
    {
        if (Sum[i] < Sum[result]) result = i;
    }
    WriteLine(result + 1 + " строка");
}