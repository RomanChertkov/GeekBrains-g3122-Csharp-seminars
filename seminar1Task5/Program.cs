﻿//=============================================================================
//Напишите программу, которая на вход принимает одно число (N), 
//а на выходе показывает все целые числа в промежутке от -N до N.
//=============================================================================

Console.WriteLine("Вывести все целые числа от -N до N");

Console.Write("Введите число N: ");
int number = int.Parse(Console.ReadLine() ?? "");

for ( int i = (-1)* number; i< number; i++) {
    Console.Write(i+", ");
}

Console.WriteLine(number);
