//=============================================================================
//                       Задача 43
// Напишите программу, которая найдёт точку пересечения двух прямых, 
// заданных уравнениями y = k1 * x + b1, y = k2 * x + b2; 
// значения b1, k1, b2 и k2 задаются пользователем.
//=============================================================================

bool endApp = false;

while (!endApp)
{
    ProgramDescription(
        "Программа найдёт точку пересечения двух прямых, " +
        "заданных уравнениями y = k1 * x + b1, y = k2 * x + b2 \n"
    );

    double[] line1 = new double[2]{
        ValidateIntNumber(ReadStringFromConsole("Введите k1: ")),
        ValidateIntNumber(ReadStringFromConsole("Введите b1: "))
    };

    double[] line2 = new double[2] {
        ValidateIntNumber(ReadStringFromConsole("Введите k2: ")),
        ValidateIntNumber(ReadStringFromConsole("Введите b2: "))
    };


    double[] point = CrossPoint(line1, line2);


    PrintResultToConsole(
        "Точка пересечения прямых " +
        $"y={line1[0]}*x+{line1[1]} и  y={line2[0]}*x+{line2[1]} " +
        $"({point[0]},{point[1]})"
    );

    ContinueProgram();
}


// Метод находит точку пересечения 2-х прямых
// прямая задана массивом line[k,b]
// где к и b - это  коэффициенты y = k*x+b
double[] CrossPoint(double[] line1, double[] line2)
{
    //x из решения системы 2-х уравнений
    double x = (line2[1] - line1[1]) / (line1[0] - line2[0]);
    //любая из 2-х заданных прямых
    double y = line1[0] * x + line1[1];

    return new double[2] { x, y };
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
