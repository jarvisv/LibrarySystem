using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Models;
using System.IO;

namespace LibrarySystem
{
    [ServiceContract]
    public interface ILibrarySystem
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "user/{id}",
            ResponseFormat = WebMessageFormat.Json)]
        Member GetUser(string id);

        [OperationContract]
        [WebInvoke(Method = "GET",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "books/title/{title}",
            ResponseFormat = WebMessageFormat.Json)]
        List<Book> GetBooksByTitle(string title);

        [OperationContract]
        [WebInvoke(Method = "GET",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "books/author/{author}",
            ResponseFormat = WebMessageFormat.Json)]
        List<Book> GetBooksByAuthor(string author);

        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "checkout",
            ResponseFormat = WebMessageFormat.Json)]
        string Checkout(Stream data);

        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "return",
            ResponseFormat = WebMessageFormat.Json)]
        string Restock(Stream data);
    }
}
