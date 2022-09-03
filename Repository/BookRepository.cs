using Dapper;
using LibraryTestApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryTestApp.Repository
{
    public class BookRepository
    {   
        //I'm not logging exceptions in this layer because of logging in controller
        //Sqlconnection constructor
        public SqlConnection con;
        //To Handle connection related activities      
        private void DatabaseConnection()
        {
            con = new SqlConnection("Data Source =**add here server information ; Initial Catalog =**add here database information; Integrated Security = True;");//database information string (Must add information of sql server and database
        }
        //To add book with details      
        public void AddBook(BookModel objBook)
        {
            //Adding the book      
            try
            {
                DatabaseConnection();
                con.Open();//to open SQL database connetion
                con.Execute("AddBookDetail", objBook, commandType: CommandType.StoredProcedure);//executing a storedprocedure which adds informations of the book to tbl_Book with BookModel
                con.Close();//to close SQL database connetion
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //To view book details with generic list       
        public List<BookModel> GetAllBooks()
        {
            try
            {
                //listing all books
                DatabaseConnection();
                con.Open();
                IList<BookModel> BookList = SqlMapper.Query<BookModel>(
                                  con, "GetBooks").ToList();//executing a storedprocedure(GetBooks) which lists informations of books 
                con.Close();
                return BookList.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //To update book details      
        public void UpdateBook(BookModel bookUpdate)
        {
            try
            {
                //updating posted book
                DatabaseConnection();
                con.Open();
                con.Execute("UpdateBookDetails", bookUpdate, commandType: CommandType.StoredProcedure);//executing a storedprocedure which updates informations of the book to tbl_Book with BookModel
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
