using System.Collections.Generic;

namespace WcfBookServiceLibrary.Book
{
    public interface IBookInfo
    {

        string Title { get; set; }

        string SubTitle { get; set; }

        IEnumerable<string> Authors { get; set; }

        string Description { get; set; }

        string Cover { get; set; }

    }
}
