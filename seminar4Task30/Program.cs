//=============================================================================
//                       Задача 30
// Напишите программу, которая выводит массив из 8 элементов, 
// заполненный нулями и единицами в случайном порядке.
//=============================================================================

ProgramDescription(
    "Напишите программу, которая выводит массив из 8 элементов, " +
    "заполненный нулями и единицами в случайном порядке. \n"
);

Console.WriteLine("Для заполнения массива нажмите любую клавишу");
Console.ReadKey(true);

PrintResultToConsole(
    "Массив из 8 случайных чисел (0 или 1) \n" +
    $"[{string.Join(",", GenerateRandomArray(8))}]");


// МЕТОДЫ

int[] GenerateRandomArray(int arrayLenght)
{
    int[] randomArray = new int[arrayLenght];
    Random randomNumber = new Random();

    for (int i = 0; i < arrayLenght; i++)
    {
        randomArray[i] = randomNumber.Next(0, 2);
    }

    return randomArray;
}



//Очистка консоли и вывод описания работы программы
void ProgramDescription(string text)
{
    Console.Clear();
    Console.WriteLine(text);
}

//Вывод результата работы программы
void PrintResultToConsole(string result)
{
    Console.WriteLine();
    Console.WriteLine(result);
}
