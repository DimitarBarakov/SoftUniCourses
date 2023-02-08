using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Articles_2._0
{
    class Article
    {
        public Article()
        {

        }
        public string title { get; set; }
        public string content { get; set; }
        public string author { get; set; }

        public void ToString()
        {
            Console.WriteLine($"{title} - {content}: {author}");
        }
        internal class Program
        {
            static void Main(string[] args)
            {
                List<Article> articles = new List<Article>();
                int n = int.Parse(Console.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    List<string> elements = Console.ReadLine().Split(", ").ToList();

                    Article article = new Article();
                    article.title = elements[0];
                    article.content = elements[1];
                    article.author = elements[2];

                    articles.Add(article);
                }
                string command = Console.ReadLine();
                List<Article> ordered = new List<Article>();
                if (command == "title")
                {
                    ordered = articles.OrderBy(article => article.title).ToList();
                }
                else if (command == "content")
                {
                    ordered = articles.OrderBy(article => article.content).ToList();
                }
                else if (command == "author")
                {
                    ordered = articles.OrderBy(article => article.author).ToList();
                }
                foreach (Article article in ordered)
                {
                    article.ToString();
                }
            }
        }
    }
}
