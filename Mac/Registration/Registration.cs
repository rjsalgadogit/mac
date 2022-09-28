using Mac.Models.StoredProcedure;
using Mac.SequelConnection;
using Mac.Services;
using Mac.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Sequel.Service;
using Sequel.Service.Interfaces;

namespace Mac.Registration
{
	public static class Registration
	{
		public static void Register(IServiceCollection services)
		{
			services.AddTransient(typeof(ISequelConnection), typeof(AppSequelConnection));

			#region SP

			services.AddTransient(typeof(ISequelService<GetAddresses>), typeof(SequelService<GetAddresses>));
			services.AddTransient(typeof(ISequelService<UpdateAddress>), typeof(SequelService<UpdateAddress>));
			services.AddTransient(typeof(ISequelService<DeleteAddress>), typeof(SequelService<DeleteAddress>));
			services.AddTransient(typeof(ISequelService<GetAddressDetails>), typeof(SequelService<GetAddressDetails>));

			#endregion

			#region Service

			services.AddTransient(typeof(IMacService), typeof(MacService));

			#endregion
		}
	}
}
