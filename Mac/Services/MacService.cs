using Mac.Models;
using Mac.Models.Extension;
using Mac.Models.StoredProcedure;
using Mac.Services.Interfaces;
using Sequel.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mac.Services
{
	public class MacService : IMacService
	{
		private readonly ISequelService<GetAddresses> _getAddresses;
		private readonly ISequelService<UpdateAddress> _updateAddress;
		private readonly ISequelService<DeleteAddress> _deleteAddress;

		public MacService(ISequelService<GetAddresses> getAddresses
			, ISequelService<UpdateAddress> updateAddress
			, ISequelService<DeleteAddress> deleteAddress)
		{
			_getAddresses = getAddresses;
			_updateAddress = updateAddress;
			_deleteAddress = deleteAddress;
		}

		public async Task<List<MacAddressModel>> GetAddresses()
		{
			var list = new List<MacAddressModel>();

			try
			{
				var result = await _getAddresses.GetSPResultsFromSequelClientAsync(new GetAddresses());

				if (result != null)
					list = result.Select(i => i.ToViewModel()).ToList();
			}
			catch (Exception ex) { throw; }

			return list;
		}

		public async Task UpdateAddress(UpdateAddress updateAddress)
		{
			try
			{
				await _updateAddress.PerformSPFromSequelClientAsync(updateAddress);
			}
			catch (Exception ex) { throw; }
		}

		public async Task DeleteAddress(DeleteAddress deleteAddress)
		{
			try
			{
				await _deleteAddress.PerformSPFromSequelClientAsync(deleteAddress);
			}
			catch (Exception ex) { throw; }
		}
	}
}
