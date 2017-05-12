using RDD.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flights.Domain.Collections
{
	public class FlightsCollection
	{
		private IRepository<Flight> _entitySource;

		public FlightsCollection(IRepository<Flight> entitySource)
		{
			_entitySource = entitySource;
		}

		public IEnumerable<Flight> GetFlights()
		{
			return _entitySource.QueryEntities((flights) => flights.ToList());
		}

		public Flight GetFlightById(Guid id)
		{
			return _entitySource.QueryEntities((flights) => flights.Where(f => f.Id == id).ToList()).FirstOrDefault();
		}
	}
}
