using Sequel.Attributes;
using Sequel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mac.Models.StoredProcedure
{
	public class DeleteAddress : ModelBaseSqlStoredProcedure
	{
		[Param]
		public int Id { get; set; }
	}
}
