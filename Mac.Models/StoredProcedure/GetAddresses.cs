using Sequel.Attributes;
using Sequel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mac.Models.StoredProcedure
{
	public class GetAddresses : ModelBaseSqlStoredProcedure
	{
		[Read]
		public int Id { get; set; }

		[Read]
		public string Address { get; set; }

		[Read]
		public string Description { get; set; }
	}
}
