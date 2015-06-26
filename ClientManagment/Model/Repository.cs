using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManagment.Model
{
	public class Repository
	{
		public static IEnumerable<Client> GetClients()
		{
			var clients = new List<Client>
			{
				new Client { Name = "Jan", Surname = "Kowalski" },
				new Client { Name = "Włodzimierz", Surname = "Makowski" },
				new Client { Name = "Piotr", Surname = "Sulmiński" },
				new Client { Name = "Barbara", Surname = "Żarkowska" },
			};

			return clients;
		}

	}
}
