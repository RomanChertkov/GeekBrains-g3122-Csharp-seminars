//=============================================================================
//                       Задача 60
// Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
// Напишите программу, которая будет построчно выводить массив, 
// добавляя индексы каждого элемента. 
//=============================================================================


bool endApp = false;

while (!endApp)
{
    ProgramDescription(
        "Программа будет построчно выводить 3D массив, "
        + "добавляя индексы каждого элемента.\n"
    );

    Console.WriteLine($"Определение размера матрицы ");
    int len1 =
        ValidateIntNumber(
            ReadStringFromConsole("Введите измерение 1 : ")
        );
    int len2 =
        ValidateIntNumber(
            ReadStringFromConsole("Введите измерение 2: ")
        );

    int len3 =
        ValidateIntNumber(
            ReadStringFromConsole("Введите измерение 3: ")
        );

    if (len1 * len2 * len3 > 90)
    {
        PrintError(
            "Ошибка! Матрицу невозможно заполнить уникальными двухзначными "
            + "числами. 3D массив должен быть меньше"
        );
    }
    else
        Print3DArray(Generate3DArray(len1, len2, len3));

    ContinueProgram();
}


// Вывод ошибки в консоль
void PrintError(string errorText)
{
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.WriteLine();
    Console.WriteLine(errorText);
    Console.ResetColor();
}


//Печать 3D массива
void Print3DArray(int[,,] array)
{
    for (int k = 0; k < array.GetLength(2); k++)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write("{0}({1},{2},{3}) ", array[i, j, k], i, j, k);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}




//генерирует 3D массив
int[,,] Generate3DArray(int len1, int len2, int len3)
{

    int[,,] array = new int[len1, len2, len3];

    int number = 10;

    for (int i = 0; i < len1; i++)
    {
        for (int j = 0; j < len2; j++)
        {
            for (int k = 0; k < len3; k++)
            {
                array[i, j, k] = number;
                number++;
            }
        }
    }
    return array;
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
