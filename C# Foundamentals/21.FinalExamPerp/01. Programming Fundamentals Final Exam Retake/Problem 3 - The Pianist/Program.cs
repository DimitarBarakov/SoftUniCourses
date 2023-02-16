using System;
using System.Collections.Generic;

namespace Problem_3___The_Pianist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> pieceCompositorKey = new Dictionary<string, List<string>>(); 
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string text = Console.ReadLine();
                string[] tokens = text.Split('|');
                string piece = tokens[0];
                string compositor = tokens[1];
                string key = tokens[2];
                pieceCompositorKey.Add(piece, new List<string> { compositor, key });
            }
            string command;
            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] tokens = command.Split('|');
                string action = tokens[0];
                if (action == "Add")
                {
                    string piece = tokens[1];
                    if (pieceCompositorKey.ContainsKey(piece))
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                    else
                    {
                        string composer = tokens[2];
                        string key = tokens[3];

                        pieceCompositorKey.Add(piece, new List<string> { composer, key });
                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                    }
                }
                else if (action == "Remove")
                {
                    string piece = tokens[1];
                    if (pieceCompositorKey.ContainsKey(piece))
                    {
                        pieceCompositorKey.Remove(piece);
                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
                else if (action == "ChangeKey")
                {
                    string piece = tokens[1];
                    string key = tokens[2];
                    if (pieceCompositorKey.ContainsKey(piece))
                    {
                        pieceCompositorKey[piece][1] = key;
                        Console.WriteLine($"Changed the key of {piece} to {key}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
            }
            foreach (var item in pieceCompositorKey)
            {
                string piece = item.Key;
                string composer = item.Value[0];
                string key = item.Value[1];
                Console.WriteLine($"{piece} -> Composer: { composer}, Key: { key}");
            }
        }
    }
}
