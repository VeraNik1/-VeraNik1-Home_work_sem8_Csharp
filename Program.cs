/*Задача 54: Задайте двумерный массив. 
Напишите программу, которая упорядочит по 
убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2*/


int rowAr = new Random().Next(5, 10);
int columnAr = new Random().Next(5, 10);
Console.WriteLine("Сгенерированный массив: ");
int[,] array54 = GetArrayInt(rowAr, columnAr, 1, 10);
PrintArrayInt(array54);
Console.WriteLine();
Console.WriteLine("Массив с отсортированными строками: ");
PrintArrayInt(SortRowsToMin(array54));


// сортировка строк по убыванию
int[,] SortRowsToMin(int[,] arr){
     for (int i = 0; i < arr.GetLength(0); i++){
        for (int j = 0; j < arr.GetLength(1); j++){
            for(int k = j + 1; k < arr.GetLength(1); k++){
                if(arr[i, k] > arr[i, j]){
                    int temp = arr[i, j];
                    arr[i, j] = arr[i, k];
                    arr[i, k] = temp;
                }
            }
      }}
      return arr;
    
}
// создание и заполнение массива целыми числами
int[,] GetArrayInt(int n, int m, int minValue, int maxValue)
{
    int[,] result = new int[n, m];
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            result[i, j] = new Random().Next(minValue, maxValue + 1);
        }

    }
    return result;
}
// печать массива из целых чисел
void PrintArrayInt(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]} ");
        }
        Console.WriteLine();
    }
}
