using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryTestApp.ViewModels
{
    //ViewModel for BookModel because of uploading with page
    public class BookImageViewModel
    {
        
        [Display(Name = "Id")]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Book name is required.")]
        public string BookName { get; set; }

        [Required(ErrorMessage = "Is the book in library? Required information.")]
        public bool InLibrary { get; set; }

        [Required(ErrorMessage = "Author name is required.")]
        public string AuthorName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LoanedDate { get; set; }
        public DateTime? TakeBackDate { get; set; }
        public string TakenName { get; set; }
        /// <summary>
        /// Formfile object for image of the book
        /// </summary>
        [Required(ErrorMessage = "Image of the book is required.")]
        public IFormFile ImageFile { get; set; }

    }
}
