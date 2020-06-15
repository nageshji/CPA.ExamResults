using System.Collections.Generic;

namespace CLA.ExamResults.Models
{
    public class ExamResultsDto
    {
       public string Subject { get; set; }        
       public IEnumerable<ResultDto> Results { get; set; }      
    }    
}
