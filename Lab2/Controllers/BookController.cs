using Lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public String Hello()
        {
            return "Hell Phong???";
        }
        public ActionResult ListBook()
        {
            var books = new List<String>();
            books.Add("HTML5 & CSS3 The Complete Manual - Author Name Book 1");
            books.Add("HTML5 & CSS Responsitive Web Design cookbook - Author Name Book 2");
            books.Add("Professional ASP.NET MVC5 - Author name Book 3");
            ViewBag.Books = books;
            return View();
        }

        public ActionResult ListBookModel()
        {
            
                var books = new List<Book>();
                books.Add(new Book(1, "HTML5 & CSS3 The Complete Manual", "Author Name Book 1", "/Content/img/book1cover.jpg"));
                books.Add(new Book(2, "HTML5 & CSS Responsitive Web Design cookbook", "Author Name Book 2", "/Content/img/book2cover.jpg"));
                books.Add(new Book(3, "Professional ASP.NET MVC5", "Author name Book 3", "/Content/img/book3cover.jpg"));
                return View(books);
            
        }
    }
}