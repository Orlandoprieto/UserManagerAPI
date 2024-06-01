namespace UserManagerAPI.Models
{
	public class Employee : Person
	{
		public DateTime StartDate { get; set; }
		public int Id { get; set; }
		public decimal Salary { get; set; }
		public string Position { get; set; }
	
	}
}
