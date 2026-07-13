using System;
using LibraryManagementSystem.interfaces;

namespace LibraryManagementSystem.model
{
    public class member : ISearchable
    {
        //id,name,email,phone,borrowed_books,joined_date,no_of_borrowed_books
        public int id {get;set;}
        public string name {get;set;}
        public string email {get;set;}
        public string phone {get;set;}
        public List<Book> borrowed_books {get;set;}
        public DateTime joined_date {get;set;}
        public int no_of_borrowed_books {get;set;}
        public member()
        {
            borrowed_books = new List<Book>();
            joined_date = DateTime.Now;
            no_of_borrowed_books = 0;
        }
        public override string get_info()
        {
            return "Member ID: " + id + "\nName: " + name + "\nEmail: " + email + "\nPhone: " + phone + "\nJoined Date: " + joined_date + "\nNo of Borrowed Books: " + no_of_borrowed_books;
        }
        public bool MatchesQuery(string query)
        {
            return name.ToLower().Contains(query) || email.ToLower().Contains(query) || phone.ToLower().Contains(query);
        }

    }
    }