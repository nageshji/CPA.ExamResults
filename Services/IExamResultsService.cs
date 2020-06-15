using CLA.ExamResults.Models;
using System.Collections.Generic;

namespace CLA.ExamResults.Services
{
    public interface IExamResultsService 
    {
        public IEnumerable<ExamResultsDto> GetResults();
    }
}
