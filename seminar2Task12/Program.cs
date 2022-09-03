//=============================================================================
//                                     Задача 12
// Напишите программу, которая будет принимать 2 числа и выводить, 
// является ли второе число кратным первому. 
// Если второе число не кратно первому, то программа выдаёт остаток от деления.
//=============================================================================


Console.Clear();
Console.WriteLine(
    "Программа принимает 2 числа и выводит, является ли второе число кратным первому.\n"+
    "Если второе число не кратно первому, то программа выдаёт остаток от деления.\n"
);

int firstNumber;
int secondNumber;
bool checkDivision;

ReadData();
CalculateResult();
PrintData();

// Получение данных от пользователя
void ReadData(){
    Console.Write("Введите первое число: ");
    firstNumber = int.Parse( Console.ReadLine() ?? "");

    Console.Write("Введите второе число: ");
    secondNumber = int.Parse( Console.ReadLine() ?? "");
}

// Определение Кратности чисел
void CalculateResult(){
    checkDivision = secondNumber % firstNumber == 0;
}

// Вывод результата в консоль
void PrintData(){
    if (checkDivision) 
        Console.WriteLine(
            $"Второе число {secondNumber} кратно {firstNumber} (делится без остатка)."
        );
    else 
        Console.WriteLine(
            "Второе число не кратно первому. "+
            $"Остаток от деления {secondNumber}/{firstNumber} = {secondNumber % firstNumber}"
        );
}
