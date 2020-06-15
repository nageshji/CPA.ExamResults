using AutoMapper;
using CLA.ExamResults.Models;
using CLA.ExamResults.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace CLA.ExamResults.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamResultsController : ControllerBase
    {
        private IExamResultsRepository _examResultsRepository;
        private readonly ILogger<ExamResultsController> _logger;
       
        public ExamResultsController(ILogger<ExamResultsController> logger, 
            IExamResultsRepository examResultsRepository)
        {
            _examResultsRepository = examResultsRepository;
            _logger = logger;           
        }

        [HttpGet]
        public IEnumerable<ExamResultsViewModel> Get()
        {
            return _examResultsRepository.GetResults();           
        }        
    }
}