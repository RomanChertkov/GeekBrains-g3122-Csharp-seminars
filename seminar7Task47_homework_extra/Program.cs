//=============================================================================
//                       Задача 47*
// Задайте двумерный массив. Найдите элементы, 
// у которых оба индекса чётные, и замените эти элементы на их квадраты.
// При выводе матрицы показывать каждую цифру разного цвета(цветов всего 16)
//=============================================================================



bool endApp = false;

while (!endApp)
{
    ProgramDescription(
        "Программа задаёт двумерный массив размером m×n, "
        + "заполненный случайными вещественными числами \n"
    );

    Console.WriteLine("Определение размера матрицы");
    int matrixRow =
        ValidateIntNumber(
            ReadStringFromConsole("Введите количество строк в матрице : ")
        );
    int matrixColumn =
        ValidateIntNumber(
            ReadStringFromConsole("Введите количество столбцов в матрице: ")
        );

    Console.WriteLine("\nОпределение диапазона для генерации случайных чисел");

    int startRange =
        ValidateIntNumber(ReadStringFromConsole("Введите начало диапазона : "));
    int endRange =
        ValidateRangeEnd(
            startRange,
            ValidateIntNumber(
                ReadStringFromConsole("Введите конец диапазона: ")
            )
    );

    Console.WriteLine();

    double[,] matrix =
        GenerateRandomMatrix((matrixRow, matrixColumn), (startRange, endRange));

    PrintColoredNumbersMatrix(matrix);

    ContinueProgram();
}



//генерирует 2D массив
double[,] GenerateRandomMatrix(
    (int rows, int columns) matrixSize,
    (int rangeStart, int rangeEnd) valuesRange

    )
{

    double[,] matrix = new double[matrixSize.rows, matrixSize.columns];

    for (int i = 0; i < matrixSize.rows; i++)
    {
        for (int j = 0; j < matrixSize.columns; j++)
        {
            matrix[i, j] = Math.Round(
                new Random()
                    .Next(valuesRange.rangeStart, valuesRange.rangeEnd + 1)
                    + new Random().NextDouble()
                , 2
            );
        }
    }
    return matrix;
}


// Вывод матрицы в консоль
void PrintColoredNumbersMatrix(double[,] matrix)
{
    Console.ForegroundColor = ConsoleColor.DarkGreen;

    Console.WriteLine();

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            ColoredNumber(matrix[i, j]);
            Console.Write("\t");
        }
        Console.WriteLine();
    }

    Console.ResetColor();
}


void ColoredNumber(double number)
{
    ConsoleColor[] col = new ConsoleColor[]
    {
        ConsoleColor.Black,ConsoleColor.Blue,ConsoleColor.Cyan,
        ConsoleColor.DarkBlue,ConsoleColor.DarkCyan,ConsoleColor.DarkGray,
        ConsoleColor.DarkGreen,ConsoleColor.DarkMagenta,ConsoleColor.DarkRed,
        ConsoleColor.DarkYellow,ConsoleColor.Gray,ConsoleColor.Green,
        ConsoleColor.Magenta,ConsoleColor.Red,ConsoleColor.White,
        ConsoleColor.Yellow
    };
    string numberToString = number.ToString();
    for (int i = 0; i < numberToString.Length; i++)
    {

        if (numberToString[i] == ',')
        {
            Console.ResetColor();

        }
        else
            Console.ForegroundColor = col[i];

        Console.Write(numberToString[i]);
    }
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


//валидация диапазона
int ValidateRangeEnd(int startRange, int endRange)
{

    while (startRange > endRange)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(
            "Ошибка! " +
            $"Конец диапазона должен быть больше начала ( > {startRange}).\n"
        );

        Console.ResetColor();
        Console.Write("Введите конец диапазона ещё раз: ");

        endRange =
            ValidateIntNumber(ReadStringFromConsole(""));
        Console.ResetColor();
    }
    return endRange;
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
