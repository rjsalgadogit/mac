using Mac.Models;
using Mac.Models.StoredProcedure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mac.Services.Interfaces
{
	public interface IMacService
	{
		public Task<List<MacAddressModel>> GetAddresses();
		public Task UpdateAddress(UpdateAddress updateAddress);
	}
}
