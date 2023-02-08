using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Articles
{
    class Article
    {
        public Article()
        {

        }
        public string title { get; set; }
        public string content { get; set; }
        public string author { get; set; }

        public string Edit(string newContent)
        {
            return this.content = newContent;
        }
        public string ChangeAuthor(string newAuthor)
        {
            return this.author = newAuthor;
        }
        public string Rename(string newTitle)
        {
            return this.title = newTitle;
        }
        public void ToString()
        {
            Console.WriteLine($"{title} - {content}: {author}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine().Split(", ").ToList();  
            Article article = new Article();
            article.title = elements[0];
            article.content = elements[1];
            article.author = elements[2];
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string command = Console.ReadLine();
                string[] tokens = command.Split(": ");
                string action = tokens[0];
                if (action == "Edit")
                {
                    article.Edit(tokens[1]);
                }
                else if (action == "Rename")
                {
                    article.Rename(tokens[1]);
                }
                else if (action == "ChangeAuthor")
                {
                    article.ChangeAuthor(tokens[1]);
                }
            }
            article.ToString();
        }
    }
}
