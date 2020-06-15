using System.Net.Http;

namespace CLA.ExamResults.Services
{
    public interface IHttpService
    {
        public HttpResponseMessage GetResponse(string url);
    }
}
