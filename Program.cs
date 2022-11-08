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
int[,] array54 = GetArrayInt(rowAr, columnAr, 1, 9);
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

/*Задача 56: Задайте прямоугольный двумерный массив.
 Напишите программу, которая будет находить строку 
с наименьшей суммой элементов.

Например, задан массив:

1 4 7 2

5 9 2 3

8 4 2 4

5 2 6 7

Программа считает сумму элементов в каждой строке и выдаёт 
номер строки с наименьшей суммой элементов: 1 строка*/

int row56 = new Random().Next(3, 5);
int col56= new Random().Next(3, 5);
Console.WriteLine("Сгенерированный массив: ");
int[,] array56 = GetArrayInt(row56, col56, 1, 9);
PrintArrayInt(array56);
Console.WriteLine();
Console.WriteLine(FindRowMinSum(array56));


//метод нахождения столбца с минимальной суммой

string FindRowMinSum(int[,] arr){
    string result = "";
    int minsum = 10000000;
    for (int i = 0; i < arr.GetLength(0); i++){
        int total = 0;
        for (int j = 0; j < arr.GetLength(1); j++){
            total += arr[i, j];
        }
        //Console.WriteLine(total); // для контроля)
        if(total < minsum){
            minsum = total;
            result = $"{i + 1}";}
        else if(total == minsum){
            result += $", {i + 1}";

        }
        }
        return $"Минимальная сумма элементов в строке(ах) № {result}";
    }

/*Задача 58: Задайте две квадратные матрицы. 
Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18*/

int size = new Random().Next(3, 5);
Console.WriteLine("Первая матрица: ");
int[,] matrix1 = GetArrayInt(size, size, 1, 5);
PrintArrayInt(matrix1);
Console.WriteLine("Вторая матрица: ");
int[,] matrix2 = GetArrayInt(size, size, 1, 5);
PrintArrayInt(matrix2);
Console.WriteLine();
int[,] resultMatrix = MultiplySquareMatrix(matrix1, matrix2);
Console.WriteLine("Результат умножения матриц: ");
PrintArrayInt(resultMatrix);
Console.WriteLine();

// метод перемножения квадратных матриц

int[,] MultiplySquareMatrix(int [,] arr1, int [,] arr2){
    int[,] result = new int[arr1.GetLength(0), arr1.GetLength(0)];
    for (int i = 0; i < arr1.GetLength(0); i++){
        for (int j = 0; j < arr1.GetLength(0); j++){
            for (int k = 0; k < arr1.GetLength(0); k++){
                result[i, j] += arr1[i, k] * arr2[k, j]; }
        }
    }
    return result;

}

// Задача 60. ...Сформируйте трёхмерный массив из 
// неповторяющихся двузначных чисел. Напишите программу,
// которая будет построчно выводить массив, добавляя индексы 
// каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)


Console.WriteLine("Введите размеры трехмерного массива:");
Console.WriteLine("первый: ");
int x = int.Parse(Console.ReadLine()!);
Console.WriteLine("второй: ");
int y = int.Parse(Console.ReadLine()!);
Console.WriteLine("третий: ");
int z = int.Parse(Console.ReadLine()!);
int[,,] array60 = GetArrayThreeD(x, y, z);
PrintArrayInt3D(array60);


//получение 3-х мерного массива из двухзначных уникальных чисел
int[,,] GetArrayThreeD(int n, int m, int p){
    int[,,] result = new int[n, m, p];
    int[] Temparray = GetUniqeNum(n, m, p);
    if(Temparray[0] < 0){
        Console.WriteLine("Количество элементов массива превышает количество уникальных двухзначных чисел. Поробуйте уменьшить размеры массива");
        return new int[,,]{};}
    else{
    int index = 0;
    while(index < n*m*p){
        for (int i = 0; i < n; i++)
            {for (int j = 0; j < m; j++)
                {for (int k = 0; k < p; k++){
                    result[i, j, k] = Temparray[index];
                    index++;
            }
        }}}
        return result;}
        }
 // метод для получения уникальных двухзначных чисел    
 int[] GetUniqeNum(int n, int m, int p)
 {  int index = 0;
    int[] result = new int[n*m*p];
    if(m*n*p > 90){
        return new int[]{-1};
    }
    else{
    while(index < n*m*p){
    {int temp = new Random().Next(10, 100);
        if(Array.IndexOf(result, temp) == -1){
            result[index] = temp;
            index++;
        }
 }}}
 return result;}

//метод печати 3-х мерного массива
void PrintArrayInt3D(int[,,] array)
{
        for (int k = 0; k < array.GetLength(2); k++)
            {for (int i = 0; i < array.GetLength(0); i++)
                {for (int j = 0; j < array.GetLength(1); j++){
        
            Console.Write($"{array[i, j, k]}({i}, {j}, {k}) ");
            }
        Console.WriteLine();
    }
}
}
    

// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

PrintIntArrayAsString(GetArraySpiral(4,4));

int[,] GetArraySpiral(int n, int m){
    int size = n * m;
    int[,] result = new int[n, m];
    int row = 0;
    int col = 0;
    int dx = 1;
    int dy = 0;
    int ChangeDirection = 0;
    int count = m;
    
    for(int i = 0; i < size; i++){
        result[row, col] = i + 1;
        count--;
    if(count == 0){
        count = m * (ChangeDirection % 2) + n * ((ChangeDirection + 1) % 2) - (ChangeDirection / 2 + 1);
        int temp = dx;
        dx = -dy;
        dy = temp;
        ChangeDirection++;
    }
    col += dx;
    row += dy;
    }
    return result;
}
void PrintIntArrayAsString(int[,] array)
{   int size = array.GetLength(0)*array.GetLength(1);
    int lenSize = (size.ToString()).Length;

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if(array[i, j].ToString().Length < lenSize){
                int index = 0;
                while(index < lenSize - array[i, j].ToString().Length){
                    Console.Write($"0");
                    index++;
                }
            }
        Console.Write($"{array[i, j]} ");
        }
        Console.WriteLine();
    }
}

/*Задача 59: Отсортировать
 нечетные столбцы массива по возрастанию. 
 Вывести массив изначальный и массив с 
 отсортированными нечетными столбцами*/


int rowArr = new Random().Next(3, 10);
int columnArr = new Random().Next(3, 10);
Console.WriteLine("Сгенерированный массив: ");
int[,] array59 = GetArrayInt(rowArr, columnArr, 1, 9);
PrintArrayInt(array59);
Console.WriteLine();
Console.WriteLine("Массив с отстортированными нечетными столбцами: ");
int[,] array59sorted = SortOddColumns(array59);
PrintArrayInt(array59sorted);

int[,] SortOddColumns(int[,] arr){
     for (int j = 0; j < arr.GetLength(1); j+=2){
        for (int i = 0; i < arr.GetLength(0); i++){
            for(int k = i + 1; k < arr.GetLength(0); k++){
                if(arr[k, j] < arr[i, j]){
                    int temp = arr[i, j];
                    arr[i, j] = arr[k, j];
                    arr[k, j] = temp;
                }
            }
      }}
      return arr;
    
}
