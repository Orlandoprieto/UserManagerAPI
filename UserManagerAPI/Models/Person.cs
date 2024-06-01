namespace UserManagerAPI.Models
{
	public class Person
	{
		public string Name { get; set; }
		public string Lastname { get; set; }
		public DateTime DataOfBirth { get; set; }

		public int GetAge()
		{
			int YearCurrent = new DateTime().Year;
			return YearCurrent - DataOfBirth.Year;
		}
	}
}
