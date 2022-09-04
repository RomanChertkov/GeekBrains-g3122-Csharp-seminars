//=============================================================================
//                                     Задача 14
// Напишите программу, которая выводит третью цифру заданного числа 
// или сообщает, что третьей цифры нет. (Решить для числа int)
//=============================================================================


Console.Clear();
Console.WriteLine(
    "Программа выводит третью цифру заданного числа " +
    "или сообщает, что третьей цифры нет.\n"
);

int number;
int thirdDigit = 0;
bool checkResult = false;
int digitCounter = 0;
int digitPosition = 3;

ReadData();
CalculateData();
PrintData();

// Считывает число от пользователя
void ReadData()
{
    Console.Write("Введите число: ");
    number = int.Parse(Console.ReadLine() ?? "");
}

// Находит 3 цифру
void CalculateData()
{

    if (number > 99)
    {
        // int number2 = number;
        // Подсчет количества разрядов в числе
        // while (number2 > 0){
        //     number2/=10;
        //     digitCounter++;
        // }
        // // обрезаем не нужные разряды до позиции 3 и берём последнюю цифру
        // thirdDigit =( number / (int) Math.Pow(10,digitCounter-digitPosition)) % 10;
        digitCounter = (int)Math.Log10(number);
        thirdDigit = (number / (int)Math.Pow(10, (digitCounter + 1) - digitPosition)) % 10;

        checkResult = true;
    }
}

//Выводит результат в консоль
void PrintData()
{
    Console.WriteLine(
        checkResult
        ? $"3 цифра числа {number} = {thirdDigit}"
        : $"Третьей цифры нет"
    );
}
