using CLA.ExamResults.Models;
using System.Collections.Generic;

namespace CLA.ExamResults.Services
{
    public interface IExamResultsRepository
    {
        public IEnumerable<ExamResultsViewModel> GetResults();        
    }
}
