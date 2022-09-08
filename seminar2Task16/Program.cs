//=============================================================================
//                       Задача 16
// Напишите программу, которая принимает на вход два числа 
// и проверяет, является ли одно число квадратом другого.
//=============================================================================

ProgramDescription(
    "Программа принимает на вход два числа, " +
     "и проверяет, является ли одно число квадратом другого.\n"
);

int firstNumber = ReadNumberFromConsole("Введите первое число: ");
int secondNumber = ReadNumberFromConsole("Введите второе число: ");

PrintResultToConsole(
    $"Число {firstNumber} {(isSquare(firstNumber, secondNumber) ? "" : "не")}"
    + $" является квадратом числа {secondNumber}"
);

PrintResultToConsole(
    $"Число {secondNumber} {(isSquare(secondNumber, firstNumber) ? "" : "не")}"
    + $" является квадратом числа {firstNumber}"
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


//Является ли 1-е  число квадратом 2-го
bool isSquare(int firstNumber, int secondNumber)
{
    if (firstNumber == Math.Pow(secondNumber, 2))
        return true;
    else
        return false;
}

//Вывод результата работы программы
void PrintResultToConsole(string result)
{
    Console.WriteLine(result);
}
