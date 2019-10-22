using System.Collections.Generic;

namespace WcfBookServiceLibrary.Book
{
    public class BookInfo : IBookInfo
    {
        /// <summary>
        /// Mandatory empty constructor required by JavaScriptSerializer
        /// </summary>
        public BookInfo() { }

        public string Title { get; set; }
        public string SubTitle { get; set; }
        public IEnumerable<string> Authors { get; set; }
        public string Description { get; set; }
        public string Cover { get; set; }
    }
}
