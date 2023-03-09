/*Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,0,1)
34(0,1,0) 41(0,1,1)
27(1,0,0) 90(1,0,1)
26(1,1,0) 55(1,1,1)*/


using System;
using static System.Console;

Clear();

int len1 = DataInput("глубину трехмерного массива");
int len2 = DataInput("ширину трехмерного массива");
int len3 = DataInput("длину трехмерного массива (количество элементов в строке)");

int[,,] array = Create3dUnicIntArray(len1, len2, len3, 10, 100);
Print3DIntArray(array);


int DataInput(string message)
{
    Write("Введите " + message + ": ");
    int result = int.Parse(ReadLine());
    return result;
}

void Print3DIntArray(int[,,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            for (int k = 0; k < arr.GetLength(2); k++)
                Write($"{arr[i, j, k]}({i},{j},{k}) ");
            WriteLine();
        }
    }
}

int[,,] Create3dUnicIntArray(int len1, int len2, int len3, int minValue, int maxValue)
{
    int[] unicElements = new int[len1*len2*len3];
    for (int i = 0; i < len1*len2*len3; i++)
    {
        unicElements[i] = new Random().Next(minValue, maxValue);
        for (int j = 0; j < i; j++)
        {
            if (unicElements[i] == unicElements[j])
            {
                i--;
                break;
            }
        }
    }
    int[,,] result = new int[len1, len2, len3];
    for (int i = 0; i < len1; i++)
        for (int j = 0; j < len2; j++)
            for (int k = 0; k < len3; k++)
                result[i, j, k] = unicElements[(i * len2 + j) * len3 + k];
    return result;
}
