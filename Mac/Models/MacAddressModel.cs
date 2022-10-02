using System.Text.RegularExpressions;

namespace Mac.Models
{
	public class MacAddressModel
	{
		public int Id { get; set; }

		public string Address { get; set; }

		public string AddressGrid { get 
			{ 
				var label = !string.IsNullOrEmpty(this.Address) ? Regex.Replace(this.Address, ".{2}", "$0:") : string.Empty;
				return !string.IsNullOrEmpty(label) ? label.Remove(label.Length - 1) : string.Empty;
			}
		}

		public string Description { get; set; }
	}
}
