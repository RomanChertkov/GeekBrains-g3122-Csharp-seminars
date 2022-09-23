//=============================================================================
//                       Задача 52*
// Задайте двумерный массив из целых чисел. 
// Найдите среднее арифметическое элементов в каждом столбце.
//
// *Дополнительно вывести среднее арифметическое по диагоналям 
//  и диагональ выделить разным цветом.
//=============================================================================


bool endApp = false;

while (!endApp)
{
    ProgramDescription(
        "Программа выводит двумерный массив размером m×n, "
        + "заполненный целыми числами и "
        + "находит среднее арифметическое элементов в каждом столбце "
        + "и по диагоналям.\n"
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

    Console.WriteLine("\nМатрица индексов диагоналей:");
    DiagonalIndexesMatrix(randomMatrix);

    Console.WriteLine("\nИсходная матрица:");
    PrintColoredMatrix(randomMatrix);


    Console.WriteLine("\nСреднее арифметическое элементов:");

    PrintAverigeResult(
        ColumnAverige(randomMatrix),
        "в столбце"

    );

    PrintAverigeResult(
        DiagonalAverige(randomMatrix),
        "в диагонали"

    );

    ContinueProgram();
}

//Вывод результата работы программы
void PrintAverigeResult(double[] array, string text)
{
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine();
    for (int i = 0; i < array.Length; i++)
    {

        Console.WriteLine($"{text} {i} = {array[i]}");

    }
    Console.ResetColor();
}

//
void PrintColoredMatrix(int[,] matrix)
{
    ConsoleColor[] col = new ConsoleColor[]
   {
        ConsoleColor.Magenta,ConsoleColor.Red,ConsoleColor.White,
        ConsoleColor.DarkGreen,ConsoleColor.DarkMagenta,ConsoleColor.DarkRed,
        ConsoleColor.Black,ConsoleColor.Blue,ConsoleColor.Cyan,
        ConsoleColor.DarkBlue,ConsoleColor.DarkCyan,ConsoleColor.DarkGray,
        ConsoleColor.DarkYellow,ConsoleColor.Gray,ConsoleColor.Green,
        ConsoleColor.Yellow
   };


    Console.WriteLine();

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            // позволяет использовать цвета для матрицы > 16  на 16
            int ind = Math.Abs((i - j) - ((i - j) / col.Length) * col.Length);

            Console.ForegroundColor = col[ind];

            Console.Write(matrix[i, j] + "  ");
            Console.ResetColor();
        }

        Console.WriteLine();
    }

}



//// Посчет среднего арифметического элементов в столбце
void DiagonalIndexesMatrix(int[,] matrix)
{

    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{Math.Min(rows, columns) - 1 - (i - j)}" + "  ");
        }
        Console.WriteLine();
    }
}

// Посчет среднего арифметического элементов в диагонали
double[] DiagonalAverige(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);

    int diagonalsCount = rows + columns - 1;

    int[][] diagonalsArray = new int[diagonalsCount][];

    double[] averigeValues = new double[diagonalsCount];

    //Заполняем 0
    for (int i = 0; i < diagonalsCount; i++)
    {
        diagonalsArray[i] = new int[2];
    }

    for (int j = 0; j < columns; j++)
    {


        for (int i = 0; i < rows; i++)
        {
            int diagonalIndex = Math.Min(rows, columns) - 1 - (i - j);

            //сумма элементов диагонали
            diagonalsArray[diagonalIndex][0] += matrix[i, j];

            //количество элементов диагонали
            diagonalsArray[diagonalIndex][1]++;
        }

    }

    for (int k = 0; k < diagonalsCount; k++)
    {

        averigeValues[k] =
            Math.Round((double)diagonalsArray[k][0] / diagonalsArray[k][1], 2);
    }

    return averigeValues;
}



// Посчет среднего арифметического эт-ов в столбце
double[] ColumnAverige(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);

    double[] averigeValues = new double[columns];

    for (int j = 0; j < columns; j++)
    {
        int sum = 0;

        for (int i = 0; i < rows; i++)
        {
            sum += matrix[i, j];
        }

        averigeValues[j] = Math.Round((double)sum / rows, 2);
    }

    return averigeValues;
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
        for (int j = 0; j < matrixSize.columns; j++)
        {
            matrix[i, j] = new Random()
                    .Next(valuesRange.rangeStart, valuesRange.rangeEnd + 1);
        }
    }
    return matrix;
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
