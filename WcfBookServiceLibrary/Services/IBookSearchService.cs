using System.ServiceModel;

namespace WcfBookServiceLibrary.Services
{
    [ServiceContract]
    public interface IBookSearchService
    {
        [OperationContract]
        string GetBookInfo(string isbn);

    }
    
}
