//=============================================================================
//                                     Задача 14
// Напишите программу, которая выводит третью цифру заданного числа 
// или сообщает, что третьей цифры нет.
//=============================================================================


Console.Clear();
Console.WriteLine(
    "Программа выводит третью цифру заданного числа "+
    "или сообщает, что третьей цифры нет.\n"
);

string number;
char thirdDigit = '0';
bool checkResult = false;

ReadData();
CalculateData();
PrintData();

// Считывает число от пользователя
void ReadData () {
    Console.Write("Введите число: ");
    number = Console.ReadLine() ?? "";
}

// Находит 3 цифру
void CalculateData(){
    if ( number.Length >= 3)
    {
    char[] digitArray = number.ToCharArray();
    
        thirdDigit = digitArray[2];
        checkResult = true;
    } 
}

//Выводит результат в консоль
void PrintData(){
    Console.WriteLine(
        checkResult 
        ? $"3 цифра числа {number} = {thirdDigit}"
        : $"Третьей цифры нет"
    );
}
