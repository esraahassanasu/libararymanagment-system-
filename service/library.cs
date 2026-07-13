using system;
using System.Collections.Generic;
using LibraryManagementSystem.model;
namespace LibraryManagementSystem.service
{
   public class library
    {
        public List<book> books;
        public List<member> members;
        public List<borrowrec> borrowrecords;
        
        public int total_books { get { return books.Count; } }
        public int total_members { get { return members.Count; } }
        public int total_borrow_records { get { return borrowrecords.Count; } }

        public library()
        {
        
            books = new List<book>();
            members = new List<member>();
            borrowrecords = new List<borrowrec>();
            
            
        }
//add 
        public void add_member(member member, bool isPremium )
        {
            member.id = members.Count + 1;
            if (isPremium)
            {
                premiummem premiumMember = new premiummem();
                premiumMember.id = member.id;
                premiumMember.name = member.name;
                premiumMember.email = member.email;
                premiumMember.phone = member.phone;
                members.Add(premiumMember);
            }
            else
            {
                members.Add(member);
            }
            
        }
        

        public void add_borrow_record(borrowrec record)
        {
            record.id = borrowrecords.Count + 1;
            borrowrecords.Add(record);}
            
        public void add_book(book book)
        {
            book.id = books.Count + 1;
            books.Add(book);
            
        }
        //find
        public book find_book_by_id(int id)
        {
            return books.Find(b => b.id == id);
        }
        public member find_member_by_id(int id)
        {
            return members.Find(m => m.id == id);
        }
        public borrowrec find_borrow_record_by_id(int id)
        {
            return borrowrecords.Find(r => r.id == id);
        }
        //search
        public List<book> search_books(string query)
        {
            return books.FindAll(b => b.MatchesQuery(query));
        }
        public List<member> search_members(string query)
        {
            return members.FindAll(m => m.MatchesQuery(query));
        }
        public List<borrowrec> search_borrow_records(string query)
        {
            return borrowrecords.FindAll(r => r.MatchesQuery(query));
        }
        //borrow and return
        public void borrow_book(int memberId, int bookId)
        {
            member member = find_member_by_id(memberId);
            book book = find_book_by_id(bookId);
            if (member != null && book != null && book.isavailable)
            {
                borrowrec record = new borrowrec();
                record.memberid = memberId;
                record.bookid = bookId;
                borrowrecords.Add(record);
                book.isavailable = false;
                member.no_of_borrowed_books++;
            }
        }
        public void return_book(int memberId, int bookId)
        {
            member member = find_member_by_id(memberId);
            book book = find_book_by_id(bookId);
            borrowrec record = borrowrecords.Find(r => r.memberid == memberId && r.bookid == bookId&& r.return_date == null);
            if (member != null && book != null && record != null)
            {
                record.return_date = DateTime.Now;
                book.isavailable = true;
                member.no_of_borrowed_books--;
            }
        }
        //displayall
        public void display_all_books()
        {
            foreach (book book in books)
            {
                Console.WriteLine(book.get_info());
            }
        }
        public void display_all_members()
        {
            foreach (member member in members)
            {
                Console.WriteLine(member.get_info());
            }
        }
        public void display_all_borrow_records()
        {
            foreach (borrowrec record in borrowrecords)
            {
                Console.WriteLine(record.get_info());
            }
        }
        public void display_late_borrow_records()
        {
            foreach (borrowrec record in borrowrecords)
            {
                if (record.islate())
                {
                    Console.WriteLine(record.get_info());
                }
            }
        }
        //display user borrow records
        public void display_user_borrow_records(int memberId)
        {
            foreach (borrowrec record in borrowrecords)
            {
                if (record.memberid == memberId)
                {
                    Console.WriteLine(record.get_info());
                }
            }
        }
        public void seed_data()
        {
            book book1 = new book();
            book1.id = books.Count + 1;
            book1.title = "sherlock holmes";
            book1.author = "Arthur Conan Doyle";
            book1.year = 1892;
            book1.genre = "Mystery";
            book1.isavailable = true;
            add_book(book1);
            book book2 = new book();
            book2.id = books.Count + 1;
            book2.title = "The Great Gatsby";
            book2.author = "F. Scott Fitzgerald";
            book2.year = 1925;
            book2.genre = "Fiction";
            add_book(book2);
            member member1 = new member();
            member1.id = members.Count + 1;
            member1.name = "John Doe";
            member1.email = "john.doe@example.com";
            member1.phone = "123-456-7890";
            add_member(member1,false);
            member member2 = new member();
            member2.id = members.Count + 1;
            member2.name = "Jane Smith";
            member2.email = "jane.smith@example.com";
            member2.phone = "098-765-4321";
            add_member(member2,true);
        }
    }
}