namespace GreenHouse.Models
{
	public class Plant
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? SensorValue { get; set; }
		public DateTime SensorUpdate { get; set; }
	}
}
