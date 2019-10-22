using System.IO;
using System.Net;
using WcfBookServiceLibrary.Book;
namespace WcfBookServiceLibrary
{
    public abstract class AbstractIsbnSearchInvoker : IsbnSearchInvoker
    {
        protected abstract string BuildIsbnSearchRequestUri(string isbn);

        protected abstract IBookInfo BuildBookInfoFromResponse(string jsonResponse);
        
        public IBookInfo GetBookInfo(string isbn)
        {
            HttpWebRequest request = WebRequest.Create(BuildIsbnSearchRequestUri(isbn)) as HttpWebRequest;

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    string webServiceResponse = reader.ReadToEnd();

                    return BuildBookInfoFromResponse(webServiceResponse);
                }

                return null;
            }

        }

    
    }
}