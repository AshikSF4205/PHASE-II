using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLibraryManagement
{
    public enum StatusEnum{Default,Borrowed,Returned}
    /// <summary>
    /// Class used to Borrow details Datatype creation
    /// </summary>
    public class BorrowDetails
    {
        // field
        /// <summary>
        /// Static field for auto-incrementing the borrow ID id <see cref="UserDetails"/> class
        /// </summary>
        private static int s_id = 300;
        /// <summary>
        /// Static field for return the borrow ID id <see cref="UserDetails"/> class
        /// </summary>
        private string _borrowId;

        // property
        /// <summary>
        /// Property name used to get BorrowId
        /// </summary>
        /// <value>string returnType</value>
        public string BorrowId{get{
            return _borrowId;
        }}
        /// <summary>
        /// Property name used to get BookId
        /// </summary>
        /// <value>string returnType</value>
        public string BookId{get;set;}
        /// <summary>
        /// Property name used to get userId
        /// </summary>
        /// <value>string returnType</value>
        public string UserID{get;set;}
        /// <summary>
        /// Property name used to get Borrowed date
        /// </summary>
        /// <value>DateTime returnType</value>
        public DateTime BorrowedDate{get;set;}
        /// <summary>
        /// Property name used to get status
        /// </summary>
        /// <value>StatusEnum returnType</value>
        public StatusEnum Status{get;set;}
        /// <summary>
        /// Property name used to get Borrowed count
        /// </summary>
        /// <value>int returnType</value>
        public int BorrowBookCount{get;set;}
        /// <summary>
        /// Property name used to get fine
        /// </summary>
        /// <value>double returnType</value>
        public double PaidFineAmount{get;set;}

        // Constructor
        /// <summary>
        /// string bookId, string userId, DateTime borrowedDate, StatusEnum status, int borrowBookCount, double paidFineAmount
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="userId"></param>
        /// <param name="borrowedDate"></param>
        /// <param name="status"></param>
        /// <param name="borrowBookCount"></param>
        /// <param name="paidFineAmount"></param>
        public BorrowDetails(string bookId, string userId, DateTime borrowedDate, StatusEnum status, int borrowBookCount, double paidFineAmount){
            s_id++;
            _borrowId = "LB"+s_id;
            BookId = bookId;
            UserID = userId;
            BorrowedDate = borrowedDate;
            Status = status;
            BorrowBookCount = borrowBookCount;
            PaidFineAmount = paidFineAmount;

        }
    }
}