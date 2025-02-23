using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace task_2
{
    internal class Program
    {
        static List<MEMBER>list = new List<MEMBER>();
        static void Main(string[] args)
        {
            int total_sale = 0;
            int option = Menu();
            while(option != 10)
            {

                switch(option)
                {
                    case 1:

                        Console.Clear();
                        Console.WriteLine("Name of the Member: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("CNIC : ");
                        long cnic = long.Parse(Console.ReadLine());
                        Console.WriteLine("Phone Number: ");
                        string  phone = Console.ReadLine();
                        MEMBER p = new MEMBER(name, phone, cnic);
                        list.Add(p);

                        Console.ReadKey();
                        break;
                    case 2:

                        Console.Clear();
                        Console.WriteLine("Book Name:");
                        string book_name = Console.ReadLine();
                        
                        int n;
                        do
                        {
                            Console.WriteLine("No. Of Authors (Max 4): ");
                        } while (!int.TryParse(Console.ReadLine(), out n) || n < 1 || n > 4);

                        string[] author_name = new string[n];

                        for (int i = 0; i < n; i++)
                        {
                            Console.Write($"Enter Author {i + 1} Name: ");
                            author_name[i] = Console.ReadLine();
                        }


                        Console.WriteLine("Publisher: ");
                        string publihser = Console.ReadLine();
                        Console.WriteLine("ISBN: ");
                        int isbn = int.Parse(Console.ReadLine());
                        Console.WriteLine("Price: ");
                        int price = int.Parse(Console.ReadLine());
                        Console.WriteLine("Publication: ");
                        int year = int.Parse(Console.ReadLine());
                        MEMBER member = new MEMBER(book_name, author_name, publihser, isbn, price, year);
                        list.Add(member);

                        Console.ReadKey();
                        break;
                    case 3:

                        Console.Clear();
                        Console.WriteLine("Book: ");
                        string title = Console.ReadLine();
                        foreach(MEMBER m in list)
                        {
                            if (m.Book_Name == title)
                            {
                                Console.WriteLine($"Book : {m.Book_Name} ");
                                Console.WriteLine($"Author: {m.Author_Name}");
                                Console.WriteLine($"Publisher: {m.Publisher_name}");
                                Console.WriteLine($"ISBN: {m.ISBN}");
                                Console.WriteLine($"Price: {m.Price}");
                                Console.WriteLine($"Year of publication: {m.Year}");
                            }
                        }

                        Console.ReadKey();
                        break;
                    case 4:

                        Console.Clear();
                        Console.WriteLine("ISBN: ");
                        isbn = int.Parse(Console.ReadLine());
                        foreach (MEMBER m in list)
                        {
                            if (m.ISBN == isbn)
                            {
                                Console.WriteLine($"Name of book : {m.Book_Name} ");
                                Console.WriteLine($"Author of the book: {m.Author_Name}");
                                Console.WriteLine($"Name of the publisher: {m.Publisher_name}");
                                Console.WriteLine($"Price of the book: {m.Price}");
                                Console.WriteLine($"Year of publication: {m.Year}");
                            }
                        }
                        Console.ReadKey();
                        break;
                    case 5:

                        Console.Clear();
                        Console.WriteLine("Name To Search: ");
                        name = Console.ReadLine();
                        foreach (MEMBER m in list)
                        {
                            if(m.Name == name)
                            {
                                Console.WriteLine($"Phone : {m.Phone} ");
                                Console.WriteLine($"CNIC : {m.CNIC}");
                            }
                        }
                        Console.ReadKey();
                        break;
                    case 6:

                        Console.Clear();
                        Console.WriteLine("Enter the name of the member you wannt to update: ");
                        name = Console.ReadLine();
                        Console.WriteLine("Enter the updated phone number: ");
                        phone = Console.ReadLine();
                        Console.WriteLine("Enter the updated CNIC: ");
                        cnic = long.Parse(Console.ReadLine());
                        foreach (MEMBER m in list)
                        {
                            if(m.Name == name)
                            {
                                m.Phone = phone;
                                m.CNIC = cnic;
                            }
                        }
                        Console.ReadKey();
                        break;
                    case 7:

                        Console.Clear();
                        int PRICE =0;
                        int disc_price;
                        int price_after;
                        Console.WriteLine("Enter the name: ");
                        string nam = Console.ReadLine();
                        bool found = false;
                        foreach (MEMBER m in list)
                        {
                            if (m.Name == nam)
                            {
                                Console.WriteLine("Member Found!!!");
                                found = true;
                                break;
                            }
                        }
                        if(!found)
                        {
                            Console.WriteLine("member not found.");
                        }
                        Console.ReadKey();
                        Console.WriteLine("Enter the tile of the book you want to purchase: ");
                        title = Console.ReadLine();
                        Console.WriteLine("Enter the quantity: ");
                        int quantity = int.Parse(Console.ReadLine());
                        bool bookfound = false;
                        foreach(MEMBER m in list)
                        {
                            if(m.Book_Name == title)
                            {
                                PRICE = m.Price;
                                total_sale += (quantity*PRICE);
                                bookfound = true;
                                break;
                            }
                        }
                        if (!bookfound)
                        {
                            Console.WriteLine("No book found.");
                        }
                        else
                        {
                            if (found)
                            {
                                disc_price = quantity * (PRICE * 5 / 100);
                                price_after = (quantity * PRICE) - disc_price;
                                
                                Console.WriteLine($"Since you were a member , you are given a discount {disc_price}");
                                Console.WriteLine($"You are charged only: {price_after}");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine($"Since , you are not a member , you have to pay full fee of : {PRICE}");
                                Console.ReadKey();
                            }
                        }
                        Console.ReadKey();
                        break;
                    case 8:

                        Console.Clear();
                        Console.WriteLine($"Total sales came from books: {total_sale}");
                        Console.ReadKey();
                        break;
                    case 9:

                        Console.Clear();
                        int product;
                        foreach (MEMBER m in list)
                        {
                            Console.WriteLine($"Name : {m.Name} , CNIC : {m.CNIC} , Phone : {m.Phone}");

                        }
                        product = 10*list.Count;
                        Console.WriteLine($"total membership fee collected: {product}");
                        Console.ReadKey();
                        break;
                }
                option = Menu();
            }
        }
        static int Menu()
        {

            Console.Clear();
            Console.WriteLine("1.Add member");
            Console.WriteLine("2.Add a book");
            Console.WriteLine("3.search a book by its title");
            Console.WriteLine("4.Search a book by its ISBN");
            Console.WriteLine("5.Search a member by its name");
            Console.WriteLine("6.update member information");
            Console.WriteLine("7.Purchase a book");
            Console.WriteLine("8.Display total sales");
            Console.WriteLine("9.display total members registered");
            Console.Write("Enter your option: ");
            int option = int.Parse(Console.ReadLine());
            return option;
        }
       
    }
}
