//=============================================================================
//                       Задача 17
// Напишите программу, которая по заданному номеру четверти, 
// показывает диапазон возможных координат точек в этой четверти (x и y). 
// Пример. I четверть -> x>0, y>0
//=============================================================================

ProgramDescription(
    "Программа принимает на вход номеру четверти и " +
    "показывает диапазон возможных координат точек в этой четверти (x и y)\n"
);

int coordinateQuarter =
    ReadNumberFromConsole("Введите номер координатной четверти: ");

PrintResultToConsole(
    $"Все точки с {getCoordinateQuarterLimits(coordinateQuarter)} " +
    $"принадлежат {coordinateQuarter} координатной четверти "
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

//Определение диапазона возможных координат
string getCoordinateQuarterLimits(int quarter)
{
    switch (quarter)
    {
        case 1:
            return "x > 0 и y > 0";
        case 2:
            return "x < 0 и y > 0";
        case 3:
            return "x < 0 и y < 0";
        case 4:
            return "x > 0 и y < 0";
        default:
            return string.Empty;
    }
}


//Вывод результата работы программы
void PrintResultToConsole(string result)
{
    Console.WriteLine();
    Console.WriteLine(result);
}
