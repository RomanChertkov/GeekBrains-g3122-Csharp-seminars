//=============================================================================
//                       Задача 54
// Задайте двумерный массив. Напишите программу, 
// которая упорядочит по убыванию элементы каждой строки двумерного массива.
//=============================================================================


bool endApp = false;

while (!endApp)
{
    ProgramDescription(
        "Программа упорядочит по убыванию элементы каждой "
        + "строки двумерного массива.\n"
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
    int[,] randomMatrix =
        GenerateRandomMatrix((matrixRow, matrixColumn), (startRange, endRange));

    Console.WriteLine("Исходная матрица");
    PrintMatrix(randomMatrix);

    Console.WriteLine("\nПосле Сортировки:");
    SortedMatrix(randomMatrix);

    PrintMatrix(randomMatrix);

    ContinueProgram();
}


//сортировка строки
void SortMatrixRow(int row, int[,] matrix)
{
    List<int> sortedRow = new List<int>();

    int columns = matrix.GetLength(1);

    for (int j = 0; j < columns; j++)
    {
        sortedRow.Add(matrix[row, j]);
    }

    sortedRow.Sort();

    for (int j = 0; j < columns; j++)
    {
        //заполняем в обратном порядке
        matrix[row, columns - 1 - j] = sortedRow[j];
    }
}


// Сортировка матрицы
void SortedMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        SortMatrixRow(i, matrix);
    }
}

//генерирует 2D массив
int[,] GenerateRandomMatrix(
    (int rows, int columns) matrixSize,
    (int rangeStart, int rangeEnd) valuesRange

    )
{

    int[,] matrix = new int[matrixSize.rows, matrixSize.columns];

    for (int i = 0; i < matrixSize.rows; i++)
    {
        List<int> sortedRow = new List<int>();

        for (int j = 0; j < matrixSize.columns; j++)
        {
            matrix[i, j] = new Random()
                    .Next(valuesRange.rangeStart, valuesRange.rangeEnd + 1);
        }
    }
    return matrix;
}


// Вывод матрицы в консоль
void PrintMatrix<T>(T[,] matrix)
{
    Console.ForegroundColor = ConsoleColor.DarkGreen;

    Console.WriteLine();

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write(matrix[i, j] + "  ");
        }
        Console.WriteLine();
    }

    Console.ResetColor();
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
