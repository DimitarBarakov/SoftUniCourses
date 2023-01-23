using System;
using System.Linq;

namespace _10._LadyBugs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int filedSize = int.Parse(Console.ReadLine());
            int[] indexesWithLaduBugs = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] initialField = new int[filedSize];
            for (int i = 0; i < indexesWithLaduBugs.Length; i++)
            {
                if (indexesWithLaduBugs[i] >= 0 && indexesWithLaduBugs[i] < initialField.Length)
                {
                    initialField[indexesWithLaduBugs[i]] = 1;
                }

            }
            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] splittedCommand = command.Split(' ',StringSplitOptions.RemoveEmptyEntries).ToArray();
                int ladybugIndex = int.Parse(splittedCommand[0]);
                string direction = splittedCommand[1];
                int lenght = int.Parse(splittedCommand[2]);

                if ((ladybugIndex >= initialField.Length) || (ladybugIndex < 0) || (initialField[ladybugIndex] == 0))
                {
                    command = Console.ReadLine();
                    continue;
                }
                //if (initialField[ladybugIndex] == 0)
                //{
                //    command = Console.ReadLine();
                //    continue;
                //}
                else
                {
                    if (direction == "right")
                    {
                        int newIndex = ladybugIndex + lenght;
                        if (newIndex >= initialField.Length || newIndex < 0)
                        {
                            initialField[ladybugIndex] = 0;
                        }
                        else
                        {
                            if (initialField[newIndex] == 1)
                            {
                                newIndex += lenght;
                                if (newIndex >= initialField.Length || newIndex < 0)
                                {
                                    initialField[ladybugIndex] = 0;
                                }
                                else
                                {
                                    initialField[ladybugIndex] = 0;
                                    initialField[newIndex] = 1;
                                }
                            }
                            else
                            {
                                initialField[ladybugIndex] = 0;
                                initialField[newIndex] = 1;
                            }
                        }
                    }
                    if (direction == "left")
                    {
                        int newIndex = ladybugIndex - lenght;
                        if (newIndex < 0 || newIndex >= initialField.Length)
                        {
                            initialField[ladybugIndex] = 0;

                        }
                        else
                        {
                            if (initialField[newIndex] == 1)
                            {
                                newIndex -= lenght;
                                if (newIndex < 0 || newIndex >= initialField.Length)
                                {
                                    initialField[ladybugIndex] = 0;
                                }
                                else
                                {
                                    initialField[ladybugIndex] = 0;
                                    initialField[newIndex] = 1;
                                }
                            }
                            else
                            {
                                initialField[ladybugIndex] = 0;
                                initialField[newIndex] = 1;
                            }
                        }
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(String.Join(" ", initialField));
        }
    }
}
