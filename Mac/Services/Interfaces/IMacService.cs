using Mac.Models;
using Mac.Models.StoredProcedure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mac.Services.Interfaces
{
	public interface IMacService
	{
		public Task<List<MacAddressModel>> GetAddresses(GetModel parameters);
		public Task UpdateAddress(UpdateAddress updateAddress);
		public Task DeleteAddress(DeleteAddress deleteAddress);
		public Task<MacAddressModel> GetAddressDetails(GetAddressDetails getAddressDetails);
	}
}
