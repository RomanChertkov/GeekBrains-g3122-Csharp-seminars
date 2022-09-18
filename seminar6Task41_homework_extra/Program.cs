//=============================================================================
//                       Задача 41*
// Пользователь вводит число нажатий, затем программа следит за нажатиями и
// выдает сколько чисел больше 0 было введено.
//=============================================================================


using System.Text.RegularExpressions;
bool endApp = false;
Console.Clear();
while (!endApp)
{
    ProgramDescription(
        "Программа найдёт сколько чисел больше 0 ввёл пользователь.\n"
    );

    int number =
       ValidateIntNumber(ReadStringFromConsole("Введите количество нажатий: "));

    string inputString = KeyPressInput(number);

    PrintResultToConsole(
        $"Количество чисел > 0 = {CountPositiveNumbers(inputString)}"
    );

    ContinueProgram();
}


// Метод подсчитывает коичество чисел >0
// принимает строку

int CountPositiveNumbers(string inputString)
{
    Regex regex = new Regex(@"[-]{0,}\d+");
    MatchCollection matches = regex.Matches(inputString);
    int count = 0;
    if (matches.Count > 0)
    {

        Console.Write("Числа в строке: ");

        foreach (Match match in matches)
        {
            Console.Write(match.Value + " ");
            if (match.Value[0] != '-') count++;
        }
    }

    return count;
}


// Метод позволяет ввести строку без нажатия Enter
// как только количество нажатий равно number
// ввод строки прекращается
// возвращает строку с набранными символами
string KeyPressInput(int number)
{
    Console.WriteLine("Начните вводить символы:");

    char[] input = new char[number];

    for (int i = 0; i < number; i++)
    {

        input[i] = Console.ReadKey().KeyChar;
    }

    Console.WriteLine(
        $"\nЗакончен ввод {(number == 1 ? "символа" : "символов")}."
    );

    return new string(input);
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
        "Для повторного запуска нажмите Enter."
    );

    if (Console.ReadKey().Key == ConsoleKey.Escape) endApp = true;
    else
    {
        // улучнение диалога с пользователем после завершения программы 
        // т.к. пользователь вводит строку без Enter нужно предотвратить
        // случайный повторный запуск программы при быстром наборе символов 
        while (Console.ReadKey().Key != ConsoleKey.Enter)
        {
            Console.WriteLine(
            "\nДля выхода из программы нажмите клавишу Escape (Esc). \n" +
            "Для повторного запуска нажмите Enter."
            );
            if (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                endApp = true;
                break;
            }
        }


    }

    Console.ResetColor();
    Console.WriteLine();
}


//Очистка консоли и вывод описания работы программы
void ProgramDescription(string text)
{
    //Console.Clear();
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
