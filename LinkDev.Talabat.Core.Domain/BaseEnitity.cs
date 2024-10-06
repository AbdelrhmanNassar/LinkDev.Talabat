﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core.Domain
{
	public abstract class BaseEnitity<TKey>
	{
        public required TKey Id { get; set; }

        public required string CreatedBy  { get; set; }
        public DateTime CreatedOn { get; set; }
        public required string LastModigiedBy  { get; set; }
        public DateTime LastModifiedOn { get; set; }


        

    }
}
