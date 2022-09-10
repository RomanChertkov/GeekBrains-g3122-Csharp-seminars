//=============================================================================
//                       Задача 27
// Напишите программу, которая принимает на вход число 
// и выдаёт сумму цифр в числе.
//=============================================================================

ProgramDescription(
    "Напишите программу, которая принимает на вход число " +
    "и выдаёт сумму цифр в числе. \n"
);

string number = ReadStringFromConsole("Введите число: ");


PrintResultToConsole(
   $"Сумма цифр в числе {number} = {SumOfDigits(number)}"
);


// Подсчет суммы чсел числа
int SumOfDigits(string number)
{
    char[] digitsArray = number.ToCharArray();
    int sum = 0;
    for (int i = 0; i < digitsArray.Length; i++)
    {
        sum += int.Parse(digitsArray[i].ToString());
    }

    return sum;
}

//Очистка консоли и вывод описания работы программы
void ProgramDescription(string text)
{
    Console.Clear();
    Console.WriteLine(text);
}


// Получение строки из консоли
string ReadStringFromConsole(string call2ActionText)
{
    Console.Write(call2ActionText);
    return (Console.ReadLine() ?? "").Trim();
}

//Вывод результата работы программы
void PrintResultToConsole(string result)
{
    Console.WriteLine();
    Console.WriteLine(result);
}
