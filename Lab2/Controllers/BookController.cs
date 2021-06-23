using Lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Lab2.Controllers
{
    public class BookController : Controller
    {

        

        // GET: Book
        public String Hello()
        {
            return "Hell there, in my first Web application???";
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

        //Getbook
        public ActionResult Edit(int id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The Complete Manual", "Author Name Book 1", "/Content/img/book1cover.jpg"));
            books.Add(new Book(2, "HTML5 & CSS Responsitive Web Design cookbook", "Author Name Book 2", "/Content/img/book2cover.jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVC5", "Author name Book 3", "/Content/img/book3cover.jpg"));


            Book book = new Book();
            foreach(Book b in books)
            {
                if(b.Id == id)
                {
                    book = b;
                    break;
                }
            }
            if(book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        //Post
        [HttpPost,ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, string title,string author, string ImageCover)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The Complete Manual", "Author Name Book 1", "/Content/img/book1cover.jpg"));
            books.Add(new Book(2, "HTML5 & CSS Responsitive Web Design cookbook", "Author Name Book 2", "/Content/img/book2cover.jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVC5", "Author name Book 3", "/Content/img/book3cover.jpg"));

            if(id == null)
            {
                return HttpNotFound();
            }
            foreach(Book b in books)
            {
                if(b.Id == id)
                {
                    b.Title = title;
                    b.Author = author;
                    b.ImageCover = ImageCover;
                    break;
                }
            }
            return View("ListBookModel", books);
        }


        public ActionResult CreateBook()
        {
            return View();
        }

        [HttpPost,ActionName("CreateBook")]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include ="Id,Title,Author,ImageCover")]Book book)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The Complete Manual", "Author Name Book 1", "/Content/img/book1cover.jpg"));
            books.Add(new Book(2, "HTML5 & CSS Responsitive Web Design cookbook", "Author Name Book 2", "/Content/img/book2cover.jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVC5", "Author name Book 3", "/Content/img/book3cover.jpg"));

            try
            {
                if (ModelState.IsValid)
                {
                    books.Add(book);
                }
            }catch(Exception)
            {
                ModelState.AddModelError("", "Error Save data");
            }
            return View("ListBookModel", books);
        }


        //Delete
        //Get
        public ActionResult Delete()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The Complete Manual", "Author Name Book 1", "/Content/img/book1cover.jpg"));
            books.Add(new Book(2, "HTML5 & CSS Responsitive Web Design cookbook", "Author Name Book 2", "/Content/img/book2cover.jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVC5", "Author name Book 3", "/Content/img/book3cover.jpg"));

            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    books.Remove(b);
                    break;
                }
            }
            return View("ListBookModel", books);
        }

    }
}