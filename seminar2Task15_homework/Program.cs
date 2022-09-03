//=============================================================================
//                                     Задача 15
// Напишите программу, которая принимает на вход цифру, 
// обозначающую день недели, и проверяет, является ли этот день выходным.
//=============================================================================


Console.Clear();
Console.WriteLine(
    "Программа принимает на вход цифру, обозначающую день недели, "+
    "и проверяет, является ли этот день выходным.\n"
);

int dayNumber;
string result = "";
bool checkNumber = false;

ReadData();
CalculateData();
PrintData();

// Считывает число от пользователя
void ReadData () {
    Console.Write("Введите число: ");
    dayNumber = int.Parse( Console.ReadLine() ?? "" );
}

// Проверка на выходной день
void CalculateData(){
    if (dayNumber >= 1 && dayNumber <= 7){
        if (dayNumber == 6 || dayNumber == 7) result = "Выходной день";
        else result = "Будний день";
        checkNumber = true;
    }
   
    
}

//Выводит результат в консоль
void PrintData(){
    Console.WriteLine(
        (checkNumber) 
            ? result
            : "Такого дня нет. В неделе 7 дней."
    );
}
