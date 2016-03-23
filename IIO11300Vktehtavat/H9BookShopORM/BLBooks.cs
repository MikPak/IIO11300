using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace H9BookShopORM
{
    public class Book
    {
        #region properties
        private string author;

        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int id;

        public int Id
        {
            get { return id; }
        }

        private int year;

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        private string country;

        public string Country
        {
            get { return country; }
            set { country = value; }
        }
        #endregion
        #region CONSTRUCTORS

        public Book(int id)
        {
            this.id = id;
        }

        public Book(int id, string name, string author, string country, int year)
        {
            this.id = id;
            this.name = name;
            this.author = author;
            this.country = country;
            this.year = year;
        }
        #endregion
        #region METHODS
        public override string ToString()
        {
            return name + " written by " + author;
        }
        #endregion
    }
    public class BookShop
    {
        public static List<Book> GetTestBooks()
        {
            //throw new NotImplementedException();
            // metodi palauttaa kokoelman Book-olioita
            List<Book> temp = new List<Book>();
            temp.Add(new Book(1, "Sota ja rauha", "Leo Tolstoi", "Venäjä", 1867));
            temp.Add(new Book(1, "Sota ja rauha", "Leo Tolstoi", "Venäjä", 1867));
            return temp;
        }

        public static List<Book> GetBooks(Boolean useDB)
        {
            // haetaan kirjoja, db-kerroksen palauttama datatable mapataan olioksi
            if(useDB)
            {
                throw new NotImplementedException();
            } else
            {
                DataTable dt = DBBooks.GetTestData();
            }

            // Tehdään ORM eli DataTablen rivit muutetaan olioksi

        }

        public static void UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
