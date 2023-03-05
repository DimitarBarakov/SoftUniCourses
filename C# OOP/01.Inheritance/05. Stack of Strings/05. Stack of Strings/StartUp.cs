using System;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stack = new StackOfStrings();
            Console.WriteLine(stack.IsEmpty());
            stack.AddRange(new System.Collections.Generic.List<string>() { "1", "2", "3" });
            Console.WriteLine(stack.IsEmpty());
            Console.WriteLine(String.Join(" ", stack));
        }
    }
}
