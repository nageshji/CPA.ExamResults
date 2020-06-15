using CLA.ExamResults.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CLA.ExamResults.Services
{
    public class ExamResultsService : IExamResultsService
    {
        private readonly IHttpService _httpService;

        public ExamResultsService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public IEnumerable<ExamResultsDto> GetResults()
        {
            IList<ExamResultsDto> products = null;
            var response = _httpService.GetResponse("results");
            if (response.IsSuccessStatusCode)
            {
                Task<string> task = response.Content.ReadAsStringAsync();
                task.Wait();
                products = JsonConvert.DeserializeObject<List<ExamResultsDto>>(task.Result);
            }
            return products;
        }
    }
}
