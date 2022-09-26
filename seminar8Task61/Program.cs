//=============================================================================
//                       Задача 61
// Вывести первые N строк треугольника Паскаля. 
// Сделать вывод в виде равнобедренного треугольника
//=============================================================================


bool endApp = false;

while (!endApp)
{
    ProgramDescription(
        "Программа выводит первые N строк треугольника Паскаля.\n"
    );

    int triangleStringCount =
        ValidateIntNumber(
            ReadStringFromConsole("Введите количество строк треугольника : ")
        );

    PrintPascalTriangle(triangleStringCount);


    ContinueProgram();
}


// Печать треугольника Паскаля
void PrintPascalTriangle(int stringCount)
{
    for (int i = 0; i < stringCount; i++)
    {
        //отступы
        Console.Write(new String(' ', (stringCount - i)));

        for (int j = 0; j <= i; j++)
        {
            Console.Write(TriangleElement(i, j) + " ");
        }

        Console.WriteLine();
    }


}


//Вычисление элемента треугольника
double TriangleElement(int stringCount, int numbersCount)
{
    return
        Factorial(stringCount)
        / (Factorial(numbersCount) * Factorial(stringCount - numbersCount));
}



//Факториал
long Factorial(int number)
{
    long result = 1;

    if (number == 0) return 1;

    for (int i = 1; i <= number; i++)
    {
        result *= i;
    }


    return result;
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
