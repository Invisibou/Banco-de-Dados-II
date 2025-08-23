using GreenHouse.Models;
using System.Diagnostics;

namespace GreenHouse.Data
{
	public class Dbinitializer
	{
		public static void Initialize(PlantContext context)
		{
			context.Database.EnsureCreated();

			// Look for any plants.
			if (context.Plants.Any())
			{
				return;   // DB has been seeded
			}
			var Plants = new Plant[]
			{
				new Plant { Name = "Sequoia", SensorValue = "12:00", SensorUpdate = DateTime.Parse("2003-09-01") },
				new Plant { Name = "Baobá", SensorValue = "14:30", SensorUpdate = DateTime.Parse("2010-06-15") },
				new Plant { Name = "Ipê", SensorValue = "09:45", SensorUpdate = DateTime.Parse("2018-11-03") },
				new Plant { Name = "Cacto", SensorValue = "06:15", SensorUpdate = DateTime.Parse("2022-01-21") },
				new Plant { Name = "Oliveira", SensorValue = "17:50", SensorUpdate = DateTime.Parse("2015-03-09") },
				new Plant { Name = "Araucária", SensorValue = "23:10", SensorUpdate = DateTime.Parse("2007-12-25") }
			};
			foreach (Plant p in Plants)
			{
				context.Plants.Add(p);
			}
			context.SaveChanges();
		}
	}
}
