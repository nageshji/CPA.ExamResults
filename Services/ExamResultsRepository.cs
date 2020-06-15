using CLA.ExamResults.Models;
using System.Collections.Generic;
using System.Linq;

namespace CLA.ExamResults.Services
{
    public class ExamResultsRepository : IExamResultsRepository
    {
        // Fields
        private readonly IExamResultsService _examResultService;
        public ExamResultsRepository(IExamResultsService examResultService)
        {
            _examResultService = examResultService;
        }

        // Methods
        public IEnumerable<ExamResultsViewModel> GetResults()
        {
            return _examResultService.GetResults().SelectMany(p => p.Results, 
                (e, r) => new ExamResultsViewModel
                { 
                    Subject = e.Subject, 
                    Year = r.Year,
                    Grade = r.Grade
                });  
        }
    }
}
