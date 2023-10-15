using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLibraryManagement
{
    /// <summary>
    /// Class used to Book details Datatype creation
    /// </summary>
    public class BookDetails
    {
        // Field
        /// <summary>
        /// Static field for auto-incrementing the book ID id <see cref="UserDetails"/> class
        /// </summary>
        private static int s_id = 100;
        /// <summary>
        /// Static field for return the book id <see cref="UserDetails"/> class
        /// </summary>
        private string _bookId;

        // property
        
        /// <summary>
        /// Property name used to get BookId
        /// </summary>
        /// <value>string returnType</value>
        public string BookId{get{
            return _bookId;
        }}
        // property
        /// <summary>
        /// Property name used to get Book name
        /// </summary>
        /// <value>string returnType</value>
        public string BookName{get;set;}
        // property
        /// <summary>
        /// Property name used to get Author name
        /// </summary>
        /// <value>string returnType</value>
        public string AuthorName{get;set;}
        // property
        /// <summary>
        /// Property name used to get Book count
        /// </summary>
        /// <value>int returnType</value>
        public int BookCount{get;set;}

        // constructor
        /// <summary>
        /// string bookName, string authorName, int bookCount
        /// </summary>
        /// <param name="bookName"></param>
        /// <param name="authorName"></param>
        /// <param name="bookCount"></param>
        public BookDetails(string bookName, string authorName, int bookCount){
            s_id++;
            _bookId = "BID"+s_id;
            BookName = bookName;
            AuthorName = authorName;
            BookCount = bookCount;
        }
    }
}