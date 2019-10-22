namespace WcfBookServiceLibrary.Book
{
    public class BookBuilder
    {
        private static IBookInfo _bookInfo;
        
        public static BookBuilder GetInstance()
        {
            _bookInfo = new BookInfo();
            return new BookBuilder();
        }

        public BookBuilder WithTitle(string bookTitle)
        {
            _bookInfo.Title = bookTitle;
            return this;
        }

        public BookBuilder WithSubTitle(string bookSubTitle)
        {
            _bookInfo.SubTitle = bookSubTitle;
            return this;
        }

        public BookBuilder WithAuthors(params string[] authors)
        {
            _bookInfo.Authors = authors;
            return this;
        }

        public BookBuilder WithDescription(string bookDescription)
        {
            _bookInfo.Description = bookDescription;
            return this;
        }

        public BookBuilder WithCover(string bookCover)
        {
            _bookInfo.Cover = bookCover;
            return this;
        }

        public IBookInfo Build()
        {
            return _bookInfo;
        }
    }
}
