//=============================================================================
//                       Задача 25
// Написать калькулятор с операциями +, -, /, * и возведение в степень
//=============================================================================


using System.Text.RegularExpressions;

ProgramDescription(
    "Программа калькулятор с операциями +, -, /, * и возведение в степень(^)"
);



string firstNumber = ReadStringFromConsole("Введите число:    ");
NumberValidate(firstNumber);

string mathOperator = ReadStringFromConsole("Введите оператор: ");
mathOperatorValidate(mathOperator);

string secondNumber = ReadStringFromConsole("Введите число:    ");
NumberValidate(secondNumber);

// Меняем цвет вывода в консолиы
Console.ForegroundColor = ConsoleColor.DarkGreen;

double result =
    CalculateResult(
        double.Parse(firstNumber),
        double.Parse(secondNumber),
        mathOperator
    );

PrintResultToConsole(
   $"Результат =       " +
   $"{result}"
);



//Изменение цвета вывода в консоль 

// Метод возвращает результат согласно оператору
// По умолчанию операция сложения
double CalculateResult(
    double firstNumber,
    double secondNumber,
    string mathOperator
)
{
    switch (mathOperator)
    {
        case "-":
            return Minus(firstNumber, secondNumber);
        case "/":
            return Division(firstNumber, secondNumber);
        case "*":
            return Multiplication(firstNumber, secondNumber);
        case "^":
            return Pow(firstNumber, secondNumber);
        default:
            return Plus(firstNumber, secondNumber);
    }
}

//Метод выполняет сложение двух чисел
double Plus(double firstNumber, double secondNumber)
{
    return firstNumber + secondNumber;
}
//Метод выполняет вычитание второго числа из первого 
double Minus(double firstNumber, double secondNumber)
{
    return firstNumber - secondNumber;
}

//Метод выполняет деление первого числа на второе
double Division(double firstNumber, double secondNumber)
{
    return firstNumber / secondNumber;
}

//Метод выполняет умножение двух чисел
double Multiplication(double firstNumber, double secondNumber)
{
    return firstNumber * secondNumber;
}

//Метод выполняет возведение  перврго числа в степень второго
double Pow(double firstNumber, double secondNumber)
{
    return Math.Pow(firstNumber, secondNumber);
}

//Очистка консоли и вывод описания работы программы
void ProgramDescription(string text)
{
    Console.Clear();
    Console.WriteLine(text);
}

//Валидация числа. Если нет то выход из программы
void NumberValidate(string number)
{
    Regex regex = new Regex(@"^^[-]?((\d+[.\,]?\d*)|(\d+))$");
    MatchCollection matches = regex.Matches(number);
    if (matches.Count == 0)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("Ошибка ввода. Введите число!");
        Environment.Exit(0);
    }

}

//Валидация оператора. Если нет то выход из программы
void mathOperatorValidate(string mathOperator)
{
    Regex regex = new Regex(@"^[+,-,-,*,\/,\^]$");
    MatchCollection matches = regex.Matches(mathOperator);

    if (matches.Count == 0)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("Недопустимый оператор. Введите +,-,/,*,^");
        Environment.Exit(0);
    }

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
    //Console.WriteLine();
    Console.WriteLine(result);
}
