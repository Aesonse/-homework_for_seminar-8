/*Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по возрастанию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2*/
using System;
using static System.Console;

Clear();

int row = DataInput("количество строк");
int col = DataInput("количество столбцов");
int[,] matrix = CreateIntMatrix(row, col, 1, 10);
PrintIntMatrix(matrix);
WriteLine();
SortMatrixRow(matrix);
PrintIntMatrix(matrix);

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

void SortMatrixRow(int[,] mtx)
{
    for (int i = 0; i < mtx.GetLength(0); i++)
    {
        for (int j = 0; j < mtx.GetLength(1) - 1; j++)
        {
            int kMax = j;
            for (int k = j + 1; k < mtx.GetLength(1); k++)
            {
                if (mtx[i, k] > mtx[i, kMax])
                    kMax = k;
            }
            int temp = mtx[i, j];
            mtx[i, j] = mtx[i, kMax];
            mtx[i, kMax] = temp;
        }
    }
}