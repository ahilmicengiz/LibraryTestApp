using LibraryTestApp.Models;
using LibraryTestApp.Repository;
using LibraryTestApp.ViewModels;
using log4net;
using log4net.Core;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace LibraryTestApp.Controllers
{
    public class BookController : Controller
    {
        //Creating controller constructors
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<BookController> _logger;
        private readonly ILog log;
        BookRepository bookRepository = new BookRepository();
        //Main controller of the app
        public BookController(IWebHostEnvironment environment, ILogger<BookController> logger)
        {
            _logger = logger;
            _environment = environment;
            log = LogManager.GetLogger(typeof(BookController));
        }
       
        public ActionResult AddBook()
        {
            return View();
        }

        //Getting all book informations
        /// <summary>
        /// Method for list all books. Takes a starting page param for PagedList.
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult GetAllBooks(int page = 1)
        {
            try
            {
                return View(bookRepository.GetAllBooks().ToPagedList(page, 5));
            }
            catch (Exception ex)
            {
                log.Error("Error on GetAllBooks method", ex); //Logging exceptions of this method
                throw ex;
            }
        }

        //Adding posted viewmodel object   
        /// <summary>
        /// Method for add a book.Takes BookImageViewModel as param
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddBook(BookImageViewModel book)
        {
            try
            {
                if (ModelState.IsValid)
                {   
                    string uniqueFileName = ProcessUploadedFile(book);
                    BookModel newBook = new BookModel()
                    {
                        AuthorName = book.AuthorName,
                        BookName = book.BookName,
                        CreatedDate = DateTime.Now,
                        InLibrary = true,
                        LoanedDate = null,
                        TakeBackDate = null,
                        TakenName = null,
                        BringBackTime=null,
                        BookImage = uniqueFileName
                    };
                    bookRepository.AddBook(newBook);
                }
                ViewBag.Message = "Records added successfully.";

                return RedirectToAction("GetAllBooks"); //Get backing to listing page after add/insert method
            }
            catch (Exception ex)
            {
                log.Error("Error on AddBook method", ex);
                throw ex;
            }
        }
        //Getting a book to borrow a book with id of BookModel
        /// <summary>
        /// Get method for borrow a book.Takes BookId as param 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult BorrowBook(int id)
        {
            try
            {
                return View(bookRepository.GetAllBooks().Find(x => x.BookId == id));
            }
            catch(Exception ex )
            {
                log.Error("Error on BorrowBook method", ex);
                throw ex;
            }
            
        }
        //Method for TakeBack a book. Updating database with InLibrary and TakeBackDate objects.
        //Setting borrowed time(LoanedDate) and borrowed by whom to null. Because the book is in the Library.
        /// <summary>
        /// Method for TakeBack a book.Takes BookId as param
        /// </summary>
        /// <param name="id"></param>
        /// <returns>RedirectToAction("GetAllBooks")</returns>
        public ActionResult TakeBackBook(int id)
        {
            try
            {
                var book = bookRepository.GetAllBooks().Find(x => x.BookId == id);
                book.InLibrary = true;
                book.TakeBackDate = DateTime.Now;
                book.LoanedDate = null;
                book.TakenName = null;
                book.BringBackTime = null;
                bookRepository.UpdateBook(book);
                return RedirectToAction("GetAllBooks");
            }
            catch (Exception ex)
            {
                log.Error("Error on TakeBackBook method", ex);
                throw ex;
            }
        }

        // POST:Update method for borrow a book. Updates database with borrowing informations.
        // 
        /// <summary>
        /// Update method for borrow a book. Takes BookModel as param
        /// </summary>
        /// <param name="id"></param>
        /// <param name="book"></param>
        /// <returns>RedirectToAction("GetAllBooks")</returns>
        [HttpPost]
        public ActionResult EditBookDetail(BookModel book)
        {
            try
            {
                book.InLibrary = false;
                book.TakeBackDate = null;
                bookRepository.UpdateBook(book);
                return RedirectToAction("GetAllBooks");
            }
            catch(Exception ex)
            {
                log.Error("Error on EditBookDetail method", ex);
                throw ex;
            }
        }
        //Method for uploding image. Controls value of image file.
        //Creates a directory for uploaded image if the directory doesn't exits.
        //Copies image to directory of project.
        /// <summary>
        /// Method for uploding image. Controls value of image file.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>uniqueFileName</returns>
        private string ProcessUploadedFile(BookImageViewModel model)
        {
            try
            {
                string uniqueFileName = null;
                string path = Path.Combine(_environment.WebRootPath, "Images");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if (model.ImageFile != null)
                {
                    string uploadsFolder = Path.Combine(_environment.WebRootPath, "Images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImageFile.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        model.ImageFile.CopyTo(fileStream);
                    }
                }
                return uniqueFileName;
            }
            catch(Exception ex)
            {
                log.Error("Error on ProcessUploadedFile method", ex);
                throw ex;
            }
        }
    }
}
