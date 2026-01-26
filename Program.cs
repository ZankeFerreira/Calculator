using System;

//Get inputs from user
Console.WriteLine("Enter the first number: ");
int input1 = int.Parse(Console.ReadLine());

Console.WriteLine("Enter the second number: ");
int input2 = int.Parse(Console.ReadLine());

Console.WriteLine("Enter an operation (+ , - , * , /) :");

string operation = Console.ReadLine();

//Make an instance the calculator class
Calculator calculator = new Calculator();

Calculator.OperationType operationType = Calculator.OperationType.Add;

if (operation == "-")
{
   operationType = Calculator.OperationType.Sub;
}
else if (operation == "*")
{
    operationType = Calculator.OperationType.Multi;

}
else if(operation == "/")
{
    operationType = Calculator.OperationType.Divide;

}
else
{
    if(operation != "+")
    {
        Console.WriteLine("Invalid Operation type");
        System.Environment.Exit(0);
    }
   
}

CalculationRequest request = new CalculationRequest(input1, input2, operationType);

double Result = calculator.calculate(request.a, request.b,request.operation);

Console.WriteLine(Result);
