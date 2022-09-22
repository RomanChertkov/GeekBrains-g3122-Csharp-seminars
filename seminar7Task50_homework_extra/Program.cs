//=============================================================================
//                       Задача 50*
// Заполнить матрицу числами Фиббоначи и выделить цветом найденную цифру
//=============================================================================


bool endApp = false;

while (!endApp)
{
    ProgramDescription(
        "Программа принимает позиции элемента в двумерном массиве, " +
        "элемента массива или же указание, " +
        "что такого элемента нет.\n"
    );


    Console.WriteLine("Определение размера матрицы");
    int matrixRows =
        ValidateIntNumber(
            ReadStringFromConsole("Введите количество строк в матрице : ")
        );
    int matrixColumns =
        ValidateIntNumber(
            ReadStringFromConsole("Введите количество столбцов в матрице: ")
        );

    // Console.WriteLine("\nОпределение диапазона для генерации случайных чисел");


    Console.WriteLine("\nИндексы искомого элемента в матрице (нумерация c 0)");
    int row =
        ValidateIntNumber(
            ReadStringFromConsole("Введите № строки: ")
        );
    int column =
        ValidateIntNumber(
            ReadStringFromConsole("Введите № столбца: ")
        );

    Console.WriteLine();

    double[,] matrix =
       FiboMatrix((matrixRows, matrixColumns));



    double findResult = FindElementInMatrix((row, column), matrix);

    if (findResult >= 0)
        PrintMatrixWithColoredElem((row, column), matrix);
    else
    {
        PrintMatrix(matrix);
        PrintResultToConsole(
            $"В матрице нет элемента с индексами ({row}, {column})"
        );
    }



    ContinueProgram();
}


// вывод матрицы с выделенным элементом
void PrintMatrixWithColoredElem(
    (int row, int column) element, double[,] matrix
)
{
    Console.ForegroundColor = ConsoleColor.DarkGreen;

    Console.WriteLine();

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (i == element.row && j == element.column)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(matrix[i, j] + "\t");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
            else
                Console.Write(matrix[i, j] + "\t");
        }
        Console.WriteLine();
    }

    Console.ResetColor();
}


// возвращает n-е число Фибонначи используя формулу Бине
double FiboElement(int number)
{
    double fiboElem =
       (Math.Pow(((1 + Math.Sqrt(5)) / 2), number)
       - Math.Pow(((1 - Math.Sqrt(5)) / 2), number)) / Math.Sqrt(5);

    return Math.Round(fiboElem);
}


// Массив чисел Фибоначчи
double[,] FiboMatrix((int rows, int columns) matrixSize)
{
    double[,] matrix = new double[matrixSize.rows, matrixSize.columns];

    int count = 1;
    for (int i = 0; i < matrixSize.rows; i++)
    {

        for (int j = 0; j < matrixSize.columns; j++)
        {
            matrix[i, j] = FiboElement(count);
            count++;
        }
    }
    return matrix;
}

//поиск элемента в матрице
double FindElementInMatrix((int row, int column) element, double[,] matrix)
{
    if (
        element.row < matrix.GetLength(0)
        && element.column < matrix.GetLength(1)
    )
    {
        return matrix[element.row, element.column];
    }
    else return -1;
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
            Console.Write(matrix[i, j] + "\t");
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
