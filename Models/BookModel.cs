using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryTestApp.Models
{
    public class BookModel
    {
        /// <summary>
        /// Id of BookModel
        /// </summary>
        [Display(Name = "Id")]
        public int BookId { get; set; }
        /// <summary>
        /// Name of the book
        /// </summary>
        [Required(ErrorMessage = "Book name is required.")]
        public string BookName { get; set; }
        /// <summary>
        /// Is in library information.
        /// </summary>
        [Required(ErrorMessage = "Is the book in library? Required information.")]
        public bool InLibrary { get; set; }
        /// <summary>
        /// Author of the book
        /// </summary>
        [Required(ErrorMessage = "Author name is required.")]
        public string AuthorName { get; set; }
        /// <summary>
        /// Created time of the book
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Borrowed time of the book
        /// </summary>
        public DateTime? LoanedDate { get; set; }
        /// <summary>
        /// TakeBack time of the book
        /// </summary>
        public DateTime? TakeBackDate { get; set; }
        /// <summary>
        /// Information of the taken by whom
        /// </summary>
        public string TakenName { get; set; }
        /// <summary>
        /// Path of the book image
        /// </summary>
        public string BookImage { get; set; }
        /// <summary>
        /// BringBack time of the book
        /// </summary>
        public DateTime? BringBackTime { get; set; }

    }
}
