/*Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18*/

using System;
using static System.Console;

Clear();

int row1 = DataInput("количество строк в первой матрице");
int col1 = DataInput("количество столбцов в первой матрице (и количество строк во второй)");
int row2 = col1;
int col2 = DataInput("количество столбцов во второй матрице");

int[,] matrix1 = CreateIntMatrix(row1, col1, 1, 10);
int[,] matrix2 = CreateIntMatrix(row2, col2, 1, 10);
PrintIntMatrix(matrix1);
WriteLine("*");
PrintIntMatrix(matrix2);
WriteLine("=");
PrintIntMatrix(MultMatrix(matrix1, matrix2));


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

int[,] MultMatrix(int[,] mtx1, int[,] mtx2)
{
    int[,] result = new int[mtx1.GetLength(0), mtx2.GetLength(1)];

    for (int i = 0; i < mtx1.GetLength(0); i++)
    {
        for (int j = 0; j < mtx2.GetLength(1); j++)
        {
            for (int k = 0; k < mtx2.GetLength(0); k++)
            {
                result[i, j] += mtx1[i, k] * mtx2[k, j];
            }
        }
    }
    return result;
}