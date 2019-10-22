using System.Web.Script.Serialization;
using WcfBookServiceLibrary.Book;

namespace WcfBookServiceLibrary.GoogleApi
{
    public class GoogleApiIsbnSearchInvoker : AbstractIsbnSearchInvoker
    {
        private const string GoogleApiBookV1IsbnSearchBaseUrl = "https://www.googleapis.com/books/v1/volumes?q=isbn:{0}";

        protected override string BuildIsbnSearchRequestUri(string isbn)
        {
            return string.Format(GoogleApiBookV1IsbnSearchBaseUrl, isbn);
        }

        protected override IBookInfo BuildBookInfoFromResponse(string jsonResponse)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            GoogleApiBookWrapper googleApiBookWrapper = jsSerializer.Deserialize<GoogleApiBookWrapper>(jsonResponse);

            return googleApiBookWrapper.GetBookInfo;
        }

    }
}
