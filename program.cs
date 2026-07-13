
using System;
using LibraryManagementSystem.model;
using LibraryManagementSystem.service;

namespace LibraryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            library lib = new library();

            lib.seed_data();

            int choice;

            do
            {
                Console.Clear();

                Console.WriteLine("==================================");
                Console.WriteLine("   Library Management System");
                Console.WriteLine("==================================");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Register Member");
                Console.WriteLine("3. Borrow Book");
                Console.WriteLine("4. Return Book");
                Console.WriteLine("5. Search Books");
                Console.WriteLine("6. Search Members");
                Console.WriteLine("7. View All Books");
                Console.WriteLine("8. View All Members");
                Console.WriteLine("9. Member Borrow History");
                Console.WriteLine("10. Late Return Report");
                Console.WriteLine("11. View All Borrow Records");
                Console.WriteLine("0. Exit");
                Console.WriteLine();

                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice.");
                    Console.ReadKey();
                    continue;
                }

                try
                {
                    switch (choice)
                    {
                        case 1:
                        {
                            book b = new book();

                            Console.Write("Title: ");
                            b.title = Console.ReadLine();

                            Console.Write("Author: ");
                            b.author = Console.ReadLine();

                            Console.Write("Year: ");
                            b.year = int.Parse(Console.ReadLine());

                            Console.Write("Genre: ");
                            b.genre = Console.ReadLine();

                            b.isavailable = true;

                            lib.add_book(b);

                            Console.WriteLine($"\nBook added successfully.");
                            Console.WriteLine($"Book ID = {b.id}");
                            break;
                        }

                        case 2:
                        {
                            member m = new member();

                            Console.Write("Name: ");
                            m.name = Console.ReadLine();

                            Console.Write("Email: ");
                            m.email = Console.ReadLine();

                            Console.Write("Phone: ");
                            m.phone = Console.ReadLine();

                            Console.Write("Premium Member? (Y/N): ");
                            bool premium =
                                Console.ReadLine().Trim().ToUpper() == "Y";

                            lib.add_member(m, premium);

                            Console.WriteLine("\nMember registered successfully.");
                            Console.WriteLine($"Member ID = {m.id}");
                            break;
                        }

                        case 3:
                        {
                            Console.Write("Member ID: ");
                            int memberId = int.Parse(Console.ReadLine());

                            Console.Write("Book ID: ");
                            int bookId = int.Parse(Console.ReadLine());

                            lib.borrow_book(memberId, bookId);

                            Console.WriteLine("\nBook borrowed successfully.");
                            break;
                        }

                        case 4:
                        {
                            Console.Write("Member ID: ");
                            int memberId = int.Parse(Console.ReadLine());

                            Console.Write("Book ID: ");
                            int bookId = int.Parse(Console.ReadLine());

                            lib.return_book(memberId, bookId);

                            Console.WriteLine("\nBook returned successfully.");
                            break;
                        }

                        case 5:
                        {
                            Console.Write("Enter search text: ");
                            string query = Console.ReadLine();

                            var books = lib.search_books(query);

                            if (books.Count == 0)
                            {
                                Console.WriteLine("No books found.");
                            }
                            else
                            {
                                Console.WriteLine("\nBooks Found:\n");

                                foreach (var b in books)
                                {
                                    Console.WriteLine(b.get_info());
                                    Console.WriteLine("----------------------------");
                                }
                            }

                            break;
                        }

                        case 6:
                        {
                            Console.Write("Enter search text: ");
                            string query = Console.ReadLine();

                            var members = lib.search_members(query);

                            if (members.Count == 0)
                            {
                                Console.WriteLine("No members found.");
                            }
                            else
                            {
                                Console.WriteLine("\nMembers Found:\n");

                                foreach (var m in members)
                                {
                                    Console.WriteLine(m.get_info());
                                    Console.WriteLine("----------------------------");
                                }
                            }

                            break;
                        }

                        case 7:
                        {
                            Console.WriteLine("\nAvailable Books:\n");
                            lib.display_all_books();
                            break;
                        }

                        case 8:
                        {
                            Console.WriteLine("\nMembers:\n");
                            lib.display_all_members();
                            break;
                        }

                        case 9:
                        {
                            Console.Write("Enter Member ID: ");
                            int memberId = int.Parse(Console.ReadLine());

                            Console.WriteLine();

                            lib.display_user_borrow_records(memberId);

                            break;
                        }

                        case 10:
                        {
                            Console.WriteLine("\nLate Return Report:\n");

                            lib.display_late_borrow_records();

                            break;
                        }

                        case 11:
                        {
                            Console.WriteLine("\nBorrow Records:\n");

                            lib.display_all_borrow_records();

                            break;
                        }

                        case 0:
                        {
                            Console.WriteLine("Goodbye!");
                            break;
                        }

                        default:
                        {
                            Console.WriteLine("Invalid choice.");
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nError: " + ex.Message);
                }

                if (choice != 0)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }

            } while (choice != 0);
        }
    }
}

