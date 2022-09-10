//=============================================================================
//                       Задача 26
// Напишите программу, которая принимает на вход число 
// и выдаёт количество цифр в числе.
//=============================================================================

ProgramDescription(
    "Напишите программу, которая принимает на вход число " +
    "и выдаёт количество цифр в числе. \n"
);

string number = ReadStringFromConsole("Введите число: ");

//Словарь окончаний слова цифра для красивого вывода результата
Dictionary<int, char> theDigitWordEnds = new Dictionary<int, char>()
{
   {0, '\0'},
   {1, 'а'},
   {2, 'ы'},
   {3, 'ы'},
   {4, 'ы'},
   {5, '\0'},
   {6, '\0'},
   {7, '\0'},
   {8, '\0'},
   {9, '\0'},
   {10, '\0'},
   {11, '\0'},
   {12, '\0'},
   {13, '\0'},
   {14, '\0'},
   {15, '\0'},
   {16, '\0'},
   {17, '\0'},
   {18, '\0'},
   {19, '\0'},
};
int digitCount = CalculateDigitCount(number);

PrintResultToConsole(
   $"В числе {number} {digitCount} " +
   $"цифр{rightEndOfWord(digitCount, theDigitWordEnds)}"
);


//Метод принимает число и выдаёт количчество цифр в нём

int CalculateDigitCount(string number)
{
    return number.Length;
}

//Метод формирует правильное окончание слова "Цифра"

char rightEndOfWord(int number, Dictionary<int, char> dictionary)
{
    if (number > 19) return theDigitWordEnds[digitCount % 10];

    return theDigitWordEnds[digitCount];
}

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
    return (Console.ReadLine() ?? "").Trim();
}


//Вывод результата работы программы
void PrintResultToConsole(string result)
{
    Console.WriteLine();
    Console.WriteLine(result);
}
