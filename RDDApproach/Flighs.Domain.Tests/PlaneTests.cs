﻿using Flights.Domain;
using Flights.Domain.Collections;
using Moq;
using RDD.Infra.Services;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Flighs.Domain.Tests
{
    public class PlaneTests
    {
		[Fact]
		public void Plane_Should_FlyTrough_Destination_When_Stopped_And_Started()
		{
			var airPort1 = new Airport("One", new GPSPoint(new LatCoordinate(48), new LongCoordinate(1)));
			var airPort2 = new Airport("Two", new GPSPoint(new LatCoordinate(48), new LongCoordinate(10)));
			var plane = new Plane(Guid.NewGuid(), airPort1.Location);
			var flight = new Flight(airPort1, airPort2, plane, null, null);
			var storage = new InMemoryStorageService();
			var flights = new FlightsCollection(() => storage);
			var planes = new PlanesCollection(() => storage);

			flights.Create(flight);
			planes.Create(plane);

			Assert.False(flight.IsPlaneFlying);

			flights.StartFlight(flight.Id);

			Assert.False(flight.IsPlaneFlying);
		}
	}
}