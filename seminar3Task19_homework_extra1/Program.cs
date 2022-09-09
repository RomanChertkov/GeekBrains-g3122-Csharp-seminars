//=============================================================================
//                       Задача 19 * (для любого числа)
// Напишите программу, которая принимает на вход произвольное число 
// и проверяет, является ли оно палиндромом.
//=============================================================================

ProgramDescription(
    "Программа принимает на вход произвольное число" +
    "и проверяет, является ли оно палиндромом.\n"
);

string number = ReadStringFromConsole("Введите введите число: ");

PrintResultToConsole(
   $"Число {number} {(IsPalindrome(number) ? "" : "не ")}является палиндромом."
);

//Очистка консоли и вывод описания работы программы
void ProgramDescription(string text)
{
    Console.Clear();
    Console.WriteLine(text);
}


// Получение числа из консоли
string ReadStringFromConsole(string call2ActionText)
{
    Console.Write(call2ActionText);
    return Console.ReadLine() ?? "0";
}

//Проверка на палиндром для любого числа
bool IsPalindrome(string number)
{
    int lenght = number.Length;
    int centerPosition = lenght / 2;

    for (int i = 0; i <= centerPosition; i++)
    {
        if (number[i] != number[lenght - 1 - i]) return false;
    }

    return true;

}


//Вывод результата работы программы
void PrintResultToConsole(string result)
{
    Console.WriteLine();
    Console.WriteLine(result);
}
