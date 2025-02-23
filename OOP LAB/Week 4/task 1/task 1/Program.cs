using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1
{
    internal class Program
    {
        static List<Product>products = new List<Product>();
        static void Main(string[] args)
        {
            int option = Menu();
            while(option!=5)
            {
                switch(option)
                {
                    case 1:
                        addproduct();
                        break;
                    case 2:
                        searchbytitle();
                        break;
                    case 3:
                        searchbyisbn();
                        break;
                    case 4:
                        update();
                        break;
                    default:
                        break;

                }
                option = Menu();
            }
        }
        static int Menu()
        {
            Console.Clear();
            Console.WriteLine("1.Add a book.");
            Console.WriteLine("2.Search a book by its title.");
            Console.WriteLine("3.search by its ISBN.");
            Console.WriteLine("4.Update number of copies.");
            Console.WriteLine("5.Exit");
            int option = int.Parse(Console.ReadLine());
            return option;
        }
        static void addproduct()
        {

            Console.Clear();
            Console.Write("Title Of Book:");
            string title = Console.ReadLine();
            Console.Write("Author:");
            string author = Console.ReadLine();
            Console.Write("Publisher:");
            string publisher = Console.ReadLine();
            Console.Write("ISBN Number:");
            int isbn = int.Parse(Console.ReadLine());
            Console.Write("Copies:");
            int copies = int.Parse(Console.ReadLine());
            Product book = new Product( title, author, publisher, isbn, copies);
            products.Add( book );
        }
        static void searchbytitle()
        {

            Console.Clear();
            Console.Write("Title Of Book :");
            string title = Console.ReadLine();
            foreach(Product book in products)
            {
                if( book.Title == title )
                {
                    Console.WriteLine($"Title of the book is:{title}");
                    Console.WriteLine($"The name of the author is: {book.Author}");
                    Console.WriteLine($"The name of the publisher is:{book.Publisher}");
                    Console.WriteLine($"The ISBN of {title} is {book.ISBN}");
                    Console.WriteLine($"The number of copies of that book is:{book.Copies}");
                }
            }
        }
        static void searchbyisbn()
        {

            Console.Clear();
            Console.Write("ISBN Number: ");
            int isbn = int.Parse(Console.ReadLine());
            foreach (Product book in products)
            {
                if (book.ISBN == isbn)
                {
                    Console.WriteLine($"Title of the book is:{book.Title}");
                    Console.WriteLine($"The name of the author is: {book.Author}");
                    Console.WriteLine($"The name of the publisher is:{book.Publisher}");
                    Console.WriteLine($"The ISBN of {book.Title} is {isbn}");
                    Console.WriteLine($"The number of copies of that book is:{book.Copies}");
                }
            }
        }
        static void update()
        {

            Console.Clear();
            Console.Write("Title Of Book To Update: ");
            string title = Console.ReadLine() ;
            Console.Write("NEW Name Of Book.");
            string name = Console.ReadLine() ;
            Console.Write("NEW ISBN Number: ");
            int isbn = int.Parse(Console.ReadLine());
            Console.Write("Reenter Author Name:");
            string author = Console.ReadLine() ;
            Console.Write("Renter Publisher: ");
            string publisher = Console.ReadLine() ;
            Console.Write("NEW Copies: ");
            int copie = int.Parse(Console.ReadLine()) ;
            foreach(Product book in products)
            {
                if(book.ISBN == isbn && book.Title == title)
                {
                    book.Title = name;
                    book.Author = author;
                    book.Publisher = publisher;
                    book.Copies = copie;
                }
            }
        }
    }
}
