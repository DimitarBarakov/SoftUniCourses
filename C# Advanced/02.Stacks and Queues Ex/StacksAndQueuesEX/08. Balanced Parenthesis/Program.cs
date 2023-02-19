using System;
using System.Collections.Generic;

namespace _08._Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();
            //for (int i = 0; i < input.Length / 2; i++)
            //{
            //    openingParantheses.Push(input[i]);
            //}
            //for (int i = input.Length / 2; i < input.Length; i++)
            //{
            //    if ((input[i] == ')' && openingParantheses.Peek() == '(') || (input[i] == '}' && openingParantheses.Peek() == '{') || (input[i] == ']' && openingParantheses.Peek() == '['))
            //    {
            //        openingParantheses.Pop();
            //    }
            //    else
            //    {
            //        Console.WriteLine("NO");
            //        return;
            //    }
            //}
            //Console.WriteLine("YES");
            bool areThey = true;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(' || input[i] == '[' || input[i] == '{')
                {
                    stack.Push(input[i]);
                }

                else if (input[i] == ')')
                {
                    if (stack.Pop() != '(')
                    {
                        areThey = false;
                    }
                }
                else if (input[i] == ']')
                {
                    if (stack.Pop() != '[')
                    {
                        areThey = false;
                    }
                }
                else if (input[i] == '}')
                {
                    if (stack.Pop() != '{')
                    {
                        areThey = false;
                    }
                }
            }
            if (areThey)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
