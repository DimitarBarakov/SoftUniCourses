using System;
using System.Collections.Generic;

namespace _03._Songs
{
    class Song
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>();
            for (int i = 1; i <= n; i++)
            {
                string[] input = Console.ReadLine().Split('_');
                Song currentSong = new Song();
                currentSong.Type = input[0];
                currentSong.Name = input[1];
                currentSong.Time = input[2];
                songs.Add(currentSong);
            }
            string type = Console.ReadLine();
            if (type == "all")
            {
                for (int i = 0; i < songs.Count; i++)
                {
                    Console.WriteLine(songs[i].Name);
                }
            }
            else
            {
                for (int i = 0; i < songs.Count; i++)
                {
                    if (songs[i].Type == type)
                    {
                        Console.WriteLine(songs[i].Name);
                    }
                }
            }
        }
    }
}
