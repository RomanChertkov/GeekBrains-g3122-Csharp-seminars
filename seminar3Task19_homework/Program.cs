

//=============================================================================
//                       Задача 19
// Напишите программу, которая принимает на вход пятизначное число 
// и проверяет, является ли оно палиндромом.
//=============================================================================

ProgramDescription(
    "Программа принимает на вход пятизначное число " +
    "и проверяет, является ли оно палиндромом.\n"
);

int number = ReadNumberFromConsole("Введите введите пятизначное число: ");

//проверка на пятизначное число. 
if ((int)Math.Log10(number) != 4)
{
    PrintResultToConsole("Ошибка! Число должно быть пятизначным");
    Environment.Exit(0);
}

PrintResultToConsole(
   $"Число {number} {(IsPalindrome(number) ? "" : "не ")}" +
   "является палиндромом."
);

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

//Проверка на палиндром 5-го числа
bool IsPalindrome(int fiveDigitNumber)
{
    return (
        (fiveDigitNumber / 10000) == (fiveDigitNumber % 10) &&
        (fiveDigitNumber / 1000) % 10 == ((fiveDigitNumber % 100) / 10)
    ) ? true : false;
}


//Вывод результата работы программы
void PrintResultToConsole(string result)
{
    Console.WriteLine();
    Console.WriteLine(result);
}
