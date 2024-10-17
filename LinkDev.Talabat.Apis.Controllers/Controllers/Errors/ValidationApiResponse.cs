using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Apis.Controllers.Controllers.Errors
{
	public class ValidationApiResponse :ApiResponse
	{
    //    public required Dictionary<string,List<string>> Errors { get; set; }
        public required IEnumerable<ValidationError> Errors { get; set; }
        public ValidationApiResponse(string? message =null) :base(400,message)
        {
            
        }

      public class ValidationError
        {
            public required string Field { get; set; }
            public required IEnumerable<string> Erros { get; set; }
        }


    }
}
