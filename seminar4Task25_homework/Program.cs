//=============================================================================
//                       Задача 25
// Напишите цикл, который принимает на вход два числа (A и B) 
// и возводит число A в натуральную степень B.
//=============================================================================

ProgramDescription(
    "Напишите цикл, который принимает на вход два числа (A и B) " +
    "и возводит число A в натуральную степень B. \n"
);

int number = ReadNumberFromConsole("Введите число: ");
int numberPow = ReadNumberFromConsole("Введите степень числа: ");

PrintResultToConsole(
   $"Число {number} в степени {numberPow} = {Pow(number, numberPow)}"
);


// МЕТОДЫ

long Pow(int number, int numberPow)
{
    long num = 1;
    for (int i = 0; i < numberPow; i++)
    {
        num *= number;
    }
    return num;
}

//Очистка консоли и вывод описания работы программы
void ProgramDescription(string text)
{
    Console.Clear();
    Console.WriteLine(text);
}

// Получение числа из консоли
int ReadNumberFromConsole(string call2ActionText)
{
    Console.Write(call2ActionText);
    return int.Parse(Console.ReadLine() ?? "0");
}

//Вывод результата работы программы
void PrintResultToConsole(string result)
{
    Console.WriteLine();
    Console.WriteLine(result);
}
