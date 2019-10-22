using System;
using System.Web.Script.Serialization;
using WcfBookServiceLibrary.Book;

namespace WcfBookServiceLibrary.Services
{
    public class BookSearchService : IBookSearchService
    {
        private IsbnSearchInvoker _isbnSearchInvoker;

        public BookSearchService(IsbnSearchInvoker isbnSearchInvoker)
        {
            _isbnSearchInvoker = isbnSearchInvoker;
        }

        public string GetBookInfo(string isbn)
        {
            isbn = isbn.Replace("-", String.Empty);
            IBookInfo bookInfo = _isbnSearchInvoker.GetBookInfo(isbn);

            if (bookInfo == null)
            {
                return null;
            }

            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            return jsSerializer.Serialize(bookInfo);
        }

    }
}
