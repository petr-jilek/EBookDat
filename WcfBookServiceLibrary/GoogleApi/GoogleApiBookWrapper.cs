using System.Linq;
using WcfBookServiceLibrary.Book;

namespace WcfBookServiceLibrary.GoogleApi
{
    public class GoogleApiBookWrapper
    {
        public string kind { get; set; }
        public int totalItems { get; set; }
        public GoogleApiBookItems[] items { get; set; }

        public IBookInfo GetBookInfo
        {
            get
            {
                if (totalItems > 0 && items.Any() && items.ElementAt(0).volumeInfo != null)
                {
                    return BookBuilder.GetInstance()
                        .WithTitle(items.ElementAt(0).volumeInfo.title)
                        .WithSubTitle(items.ElementAt(0).volumeInfo.subtitle)
                        .WithAuthors(items.ElementAt(0).volumeInfo.authors)
                        .WithDescription(items.ElementAt(0).volumeInfo.description)
                        .WithCover(items.ElementAt(0).volumeInfo.ImageLinks != null ? items.ElementAt(0).volumeInfo.ImageLinks.thumbnail : null)
                        .Build();
                }
                return null;
            }
        }
    }

    public class GoogleApiBookItems
    {
        public GoogleApiBookVolumeInfo volumeInfo { get; set; }
    }

    public class GoogleApiBookVolumeInfo
    {
        public string title { get; set; }
        public string subtitle { get; set; }
        public string[] authors { get; set; }
        public string description { get; set; }
        public GoogleApiBookImageLinks ImageLinks { get; set; }
    }

    public class GoogleApiBookImageLinks
    {
        public string thumbnail { get; set; }
    }

}
