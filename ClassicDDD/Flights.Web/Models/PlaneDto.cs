﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flights.Web.Models
{
	public class PlaneDto
	{
		public Guid Id { get; set; }
		public decimal Lat { get; set; }
		public decimal Long { get; set; }
		public bool IsFlying { get; set; }
	}
}