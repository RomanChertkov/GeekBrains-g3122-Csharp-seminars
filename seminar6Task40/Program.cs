//=============================================================================
//                       Задача 40
// Напишите программу, которая принимает на вход три числа и проверяет, 
// может ли существовать треугольник с сторонами такой длины.
//=============================================================================

bool endApp = false;

while (!endApp)
{
    ProgramDescription(
        "Программа проверяет  может ли существовать треугольник " +
        "со сторонами заданной длины. \n "
    );

    int sideA =
        ValidateIntNumber(ReadStringFromConsole("Введите сторону а: "));
    int sideB =
    ValidateIntNumber(ReadStringFromConsole("Введите сторону а: "));
    int sideC =
    ValidateIntNumber(ReadStringFromConsole("Введите сторону а: "));


    PrintResultToConsole(
        $"Треугольник со сторонами {sideA}, {sideB}, {sideC}" +
        $"{(IsTriangle(sideA, sideB, sideC) ? "" : " не")} может существовать \n"
    );

    ContinueProgram();
}

bool IsTriangle(int sideA, int sideB, int sideC)
{
    if (
        (sideA + sideB > sideC) &&
        (sideA + sideC > sideB) &&
        (sideB + sideC > sideA)
    ) return true;

    return false;
}


// Метод проверяет ввел ли пользователь в консоли число
// Если ввёл не число, то  метод просит ввести число
// Возвращает число
int ValidateIntNumber(string number)
{
    int cleanNumber = 0;
    while (!int.TryParse(number, out cleanNumber))
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;

        Console.WriteLine("Ошибка! Вы ввели не число.\n");

        Console.ResetColor();
        Console.Write("Введите целое число: ");

        number = Console.ReadLine() ?? "";
    }

    Console.ResetColor();

    return cleanNumber;

}


//Метод зпрашивает у пользователя разрешение на выход или продолжение
void ContinueProgram()
{
    //Изменение цвета вывода в консоль 
    Console.ForegroundColor = ConsoleColor.DarkYellow;

    Console.WriteLine();
    Console.WriteLine(
        "Для выхода из программы нажмите клавишу Escape (Esc). \n" +
        "Для повторного запуска нажмите любую клавишу."
    );

    if (Console.ReadKey().Key == ConsoleKey.Escape) endApp = true;

    Console.ResetColor();
    Console.WriteLine();
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
    Console.ForegroundColor = ConsoleColor.DarkGreen;

    Console.WriteLine();
    Console.WriteLine(result);

    Console.ResetColor();
}
