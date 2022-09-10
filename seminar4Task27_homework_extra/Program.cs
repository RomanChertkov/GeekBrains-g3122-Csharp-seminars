//=============================================================================
//                       Задача 27* 
// Напишите программу, которая принимает на вход число 
// и выдаёт сумму цифр в числе.
//
// Cделать оценку времени алгоритма через вещественные числа и строки.
//=============================================================================

ProgramDescription(
    "Напишите программу, которая принимает на вход число " +
    "и выдаёт сумму цифр в числе. \n"
);

string number = ReadStringFromConsole("Введите число: ");


PrintResultToConsole(
   $"Решение через строки. " +
   $"Сумма цифр в числе {number} = {SumOfDigitsString(number)}"
);

PrintResultToConsole(
   "Решение через числа. " +
   $"Сумма цифр в числе {number} = {SumOfDigits(long.Parse(number))}"
);


// Метод с числами работает быстрее. Доказательства в тестах
SpeedTest(() => SumOfDigitsString(number), "Метод SumOfDigitsString");
SpeedTest(() => SumOfDigits(long.Parse(number)), "Метод SumOfDigits");


//Подсчет суммы чисел числа чеоез строки
int SumOfDigitsString(string number)
{
    char[] digitsArray = number.ToCharArray();
    int sum = 0;
    for (int i = 0; i < digitsArray.Length; i++)
    {
        sum += int.Parse(digitsArray[i].ToString());
    }

    return sum;
}

//Подсчет суммы чисел числа через числа.
// long выбран для увеличения размера числа для теста скорости
long SumOfDigits(long number)
{
    long num = number;
    long sum = 0;
    while (num > 0)
    {
        sum += (num % 10);
        num /= 10;
    }
    return sum;
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
    Console.WriteLine();
    Console.WriteLine(result);
}

void SpeedTest(Action function, string description)
{
    DateTime startTime = DateTime.Now;

    function();

    Console.WriteLine();
    Console.WriteLine(
        $"{description} отработал за  {DateTime.Now - startTime}"
    );
}
