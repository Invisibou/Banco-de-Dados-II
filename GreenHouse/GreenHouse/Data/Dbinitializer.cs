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
				new Plant {Name="Sequoia", SensorValue="12:00", SensorUpdate=DateTime.Parse("2003-09-01")}
			};
			foreach (Plant p in Plants)
			{
				context.Plants.Add(p);
			}
			context.SaveChanges();
		}
	}
}
