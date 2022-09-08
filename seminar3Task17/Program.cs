//=============================================================================
//                       Задача 17
// Напишите программу, которая принимает на вход координаты точки (X и Y), 
// причём X ≠ 0 и Y ≠ 0 и выдаёт номер четверти плоскости, 
// в которой находится эта точка.
//=============================================================================

ProgramDescription(
    "принимает на вход координаты точки (X и Y), " +
    "причём X ≠ 0 и Y ≠ 0 и выдаёт номер четверти плоскости" +
    "в которой находится эта точка..\n"
);

int coordinateX = ReadNumberFromConsole("Введите координату X: ");
int coordinateY = ReadNumberFromConsole("Введите координату Y: ");

PrintResultToConsole(
    $"Точка находится в {getCoordinateQuarter(coordinateX, coordinateY)}" +
    " координатной четверти"
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

//Определение координатной четверти
string getCoordinateQuarter(int x, int y)
{
    if (x > 0 && y > 0) return "I";
    if (x < 0 && y > 0) return "II";
    if (x < 0 && y < 0) return "III";
    if (x > 0 && y < 0) return "IV";

    // Обработка случая когда x или y = 0
    return string.Empty;
}

//Вывод результата работы программы
void PrintResultToConsole(string result)
{
    Console.WriteLine();
    Console.WriteLine(result);
}
