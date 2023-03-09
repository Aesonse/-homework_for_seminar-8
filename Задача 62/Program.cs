/*Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07*/


using System;
using static System.Console;

Clear();

int row = DataInput("количество строк");
int col = DataInput("количество столбцов");
int[,] matrix = CreateSpiralIntMatrix(row, col);
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

int[,] CreateSpiralIntMatrix(int row, int col)
{
    int[,] result = new int[row, col];
    int rowStart = 0;
    int colStart = 0;
    int rowEnd = row-1;
    int colEnd = col-1;
    int num = 1;
    int i = 0;
    int j = 0;
    int direction = 0;
    while (rowStart != rowEnd || colStart != colEnd)
    {
        result[i, j] = num;
        num++;
        switch (direction)
        {
            case 0:
                if (j == colEnd)
                {
                    i++;
                    rowStart++;
                    direction = (direction + 1) % 4;
                }
                else j++;
                break;
            case 1:
                if (i == rowEnd)
                {
                    j--;
                    colEnd--;
                    direction = (direction + 1) % 4;
                }
                else i++;
                break;
            case 2:
                if (j == colStart)
                {
                    i--;
                    rowEnd--;
                    direction = (direction + 1) % 4;
                }
                else j--;
                break;
            case 3:
                if (i == rowStart)
                {
                    j++;
                    colStart++;
                    direction = (direction + 1) % 4;
                }
                else i--;
                break;
        }
        result[i, j] = num;
    }
    return result;
}
