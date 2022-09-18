//=============================================================================
//                       Задача 43*
// Найдите площадь треугольника образованного пересечением 3 прямых.
//=============================================================================

bool endApp = false;

while (!endApp)
{
    ProgramDescription(
        "Программа найдёт площадь треугольника " +
        "образованного пересечением 3 прямых.\n"
    );

    double[] line1 = GetLineData(1);
    double[] line2 = GetLineData(2);
    double[] line3 = GetLineData(3);

    //Если прямые имеют одинаковый  коэффициент k,
    // то они параллельны.
    if (
        line1[0] == line2[0] ||
        line2[0] == line3[0] ||
        line1[0] == line3[0]
    )
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("\nЕсть параллельные прямые!");
        ContinueProgram();
    }
    else
    {



        double[] point1 = CrossPoint(line1, line2);
        double[] point2 = CrossPoint(line2, line3);
        double[] point3 = CrossPoint(line1, line3);

        PrintResultToConsole(
            $"Точка пересечения  прямых 1 и 2 ({point1[0]};{point1[1]})\n" +
            $"Точка пересечения  прямых 2 и 3 ({point2[0]};{point2[1]})\n" +
            $"Точка пересечения  прямых 3 и 1 ({point3[0]};{point3[1]})"
        );

        double side1 = DistanceBetween2Points(point1, point2);
        double side2 = DistanceBetween2Points(point2, point3);
        double side3 = DistanceBetween2Points(point3, point1);

        double square = GetTriangleSquare(side1, side2, side3);

        PrintResultToConsole(
            "Площадь треугольника " +
            "образованного пересечением 3 прямых " +
            $"y={line1[0]}*x+{line1[1]}, y={line2[0]}*x+{line2[1]} и " +
            $"y={line3[0]}*x+{line3[1]} = {square}"
        );

        ContinueProgram();
    }
}

//Метод вычисляет площадь треугольника по формуле Герона (через полупериметр)
double GetTriangleSquare(double sideA, double sideB, double sideC)
{
    //полупериметр
    double p = 0.5 * (sideA + sideB + sideC);

    return Math.Sqrt(p * (p - sideA) * (p - sideB) * (p - sideC));
}


//Метод Запрашивает у пользоватедя коэффициенты для определениЯ прямой
// принимает порядковый номер прямой
// возвращает массив {k,b}
double[] GetLineData(int i)
{
    Console.WriteLine($"Введите к и b для прямой {i}:");

    return new double[2]{
            (double)ValidateIntNumber(ReadStringFromConsole("Введите k: ")),
            (double)ValidateIntNumber(ReadStringFromConsole("Введите b: "))
    };

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

//Метод вычисляет расстояния между 2 точками (округление до -х знаков)
double DistanceBetween2Points(double[] pointA, double[] pointB)
{

    double sum = 0;

    for (int i = 0; i < pointA.Length; i++)
    {
        sum += Math.Pow(pointB[i] - pointA[i], 2);
    }

    return Math.Round(Math.Sqrt(sum), 2);
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
