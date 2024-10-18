﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core.Application.Exceptions
{
	internal class ValidationException :BadRequestException
	{
        public required IEnumerable<string> Errors { get; set; }
        public ValidationException():base("Validation Error")
        {
            
        }
    }
}
