using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ShuntingYard
{
    static string expr = "2*(3+-2*(2/-1) + 3) --2";
   
    static Stack<double> numbers = new Stack<double>();
    static Stack<char> operators = new Stack<char>();

    static void Main()
    {
        HandleUnaryMinus();
        for (int i = 0; i < expr.Length; i++)
        {
            if (expr[i] >= '0' && expr[i] <= '9')
            {
                ReadNumber(ref i);
            }
            else if(expr[i] != ' ')
            {
                if (expr[i] == ')')
                {
                    while (operators.Peek() != '(')
                    {
                        CalculateTwoNumbers();
                    }

                    operators.Pop();
                }
                else
                {
                    if (expr[i] != '(' && operators.Count > 0 && operators.Peek() != '(' && GetPriority(operators.Peek()) >= GetPriority(expr[i]))
                    {
                        CalculateTwoNumbers();
                    }

                    operators.Push(expr[i]);
                }
            }
        }

        while (operators.Count > 0)
        {
            CalculateTwoNumbers();
        }

        Console.WriteLine(numbers.Pop());
    }

    static void HandleUnaryMinus()
    {
        HandleUnaryMinus('-');
        HandleUnaryMinus('+');
        HandleUnaryMinus('*');
        HandleUnaryMinus('/');
    }

    private static void HandleUnaryMinus(char firstOp)
    {
        int startIndex;
        while((startIndex = expr.IndexOf(firstOp + "-") + 1) > 0)
        {
            expr = expr.Insert(startIndex, "(0");

            startIndex += 3;

            while (startIndex < expr.Length)
            {
                if ((expr[startIndex] < '0' || expr[startIndex] > '9') && expr[startIndex] != ',')
                {
                    break;
                }
                startIndex++;
            }

            expr = expr.Insert(startIndex, ")");
        }
    }

    private static double Operation(double num1, double num2, char op)
    {
        switch(op)
        {
            case '+': return num1 + num2;
            case '-': return num1 - num2;
            case '*': return num1 * num2;
            default:  return num1 / num2;
        }
    }

    private static int GetPriority(char op)
    {
        return (op == '+' || op == '-') ? 1 : 2;
    }

    private static void CalculateTwoNumbers()
    {
        char op = operators.Pop();
        double num2 = numbers.Pop();
        double num1 = numbers.Pop();

        numbers.Push(Operation(num1, num2, op));
    }

    private static void ReadNumber(ref int start)
    {
        string token = "";
        while (expr[start] >= '0' && expr[start] <= '9' || expr[start] == ',')
        {
            token += expr[start];
            start++;

            if (start == expr.Length) break;
        }

        start--;

        numbers.Push(double.Parse(token));
    }
}
