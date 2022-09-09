//=============================================================================
//                       Задача 19* (решение через Dictionary)
// Напишите программу, которая принимает на вход пятизначное число 
// и проверяет, является ли оно палиндромом.
//=============================================================================

ProgramDescription(
    "Программа принимает на вход пятизначное число " +
    "и проверяет, является ли оно палиндромом.\n"
);

string number = ReadStringFromConsole("Введите введите пятизначное число: ");
Dictionary<string, string> dictionary = FillDictionary();

//проверка на пятизначное число. 
if (number.Length != 5)
{
    PrintResultToConsole("Ошибка! Число должно быть пятизначным");
    Environment.Exit(0);
}

PrintResultToConsole(
   $"Число {number} {(IsPalindrome(number, dictionary) ? "" : "не ")}" +
   "является палиндромом."
);

//Очистка консоли и вывод описания работы программы
void ProgramDescription(string text)
{
    Console.Clear();
    Console.WriteLine(text);
}


// Получение числа из консоли
string ReadStringFromConsole(string call2ActionText)
{
    Console.Write(call2ActionText);
    return Console.ReadLine() ?? "";
}

//Заполнение словаря четырёхзначными палиндромами
Dictionary<string, string> FillDictionary()
{
    Dictionary<string, string> dictionary =
        new Dictionary<string, string>();
    for (int i = 10; i < 100; i++)
    {

        string key = i.ToString();
        string value = $"{key[1]}{key[0]}";

        dictionary.Add(key + value, string.Empty);
    }
    return dictionary;
}

//Проверка на палиндром 5-го числа через словарь
bool IsPalindrome(
    string fiveDigitNumber,
    Dictionary<string, string> palindromeDictionary
)
{
    // убитраем один ценральный символ. 
    // У него индекс 2 в строке из 5-ти элементов
    string newNumber = fiveDigitNumber.Remove(2, 1);

    return (
        palindromeDictionary.ContainsKey(newNumber)
    ) ? true : false;
}


//Вывод результата работы программы
void PrintResultToConsole(string result)
{
    Console.WriteLine();
    Console.WriteLine(result);
}
