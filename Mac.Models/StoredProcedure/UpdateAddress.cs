using Sequel.Attributes;
using Sequel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mac.Models.StoredProcedure
{
	public class UpdateAddress : ModelBaseSqlStoredProcedure
	{
		[Param]
		public int Id { get; set; }

		[Param]
		public string Address { get; set; }

		[Param]
		public string Description { get; set; }
	}
}
