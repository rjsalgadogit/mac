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

		public MacService(ISequelService<GetAddresses> getAddresses, ISequelService<UpdateAddress> updateAddress)
		{
			_getAddresses = getAddresses;
			_updateAddress = updateAddress;
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
	}
}
