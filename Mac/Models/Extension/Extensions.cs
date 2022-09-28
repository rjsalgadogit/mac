using Mac.Models.StoredProcedure;

namespace Mac.Models.Extension
{
	public static class Extensions
	{
		public static MacAddressModel ToViewModel(this GetAddresses getAddresses)
			=> new MacAddressModel
			{
				Id = getAddresses.Id,
				Address = getAddresses.Address,
				Description = getAddresses.Description
			};

		public static MacAddressModel ToViewModel(this GetAddressDetails getAddressDetails)
			=> new MacAddressModel
			{
				Id = getAddressDetails.Id,
				Address = getAddressDetails.Address,
				Description = getAddressDetails.Description
			};
	}
}
