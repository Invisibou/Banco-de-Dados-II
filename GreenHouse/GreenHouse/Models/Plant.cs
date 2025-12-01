using System.ComponentModel.DataAnnotations;

namespace GreenHouse.Models
{
	public class Plant
	{
		[Key]
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? SensorValue { get; set; }
		public DateTime SensorUpdate { get; set; }
	}
}
