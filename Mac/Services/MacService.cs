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
		private readonly ISequelService<GetAddressDetails> _getAddressDetails;

		public MacService(ISequelService<GetAddresses> getAddresses
			, ISequelService<UpdateAddress> updateAddress
			, ISequelService<DeleteAddress> deleteAddress
			, ISequelService<GetAddressDetails> getAddressDetails)
		{
			_getAddresses = getAddresses;
			_updateAddress = updateAddress;
			_deleteAddress = deleteAddress;
			_getAddressDetails = getAddressDetails;
		}

		public async Task<List<MacAddressModel>> GetAddresses(GetModel parameters)
		{
			var list = new List<MacAddressModel>();

			try
			{
				var result = await _getAddresses.GetSPResultsFromSequelClientAsync(new GetAddresses 
				{ 
					OffSet = parameters.PageNumber, 
					PageSize = parameters.PageSize,
					Keyword = parameters.keyword
				});

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

		public async Task<MacAddressModel> GetAddressDetails(GetAddressDetails getAddressDetails)
		{
			var model = new MacAddressModel();

			try
			{
				var result = await _getAddressDetails.GetSPResultsFromSequelClientAsync(getAddressDetails);

				if (result != null)
					model = result.Select(i => i.ToViewModel()).FirstOrDefault();
			}
			catch (Exception ex) { throw; }

			return model;
		}
	}
}
