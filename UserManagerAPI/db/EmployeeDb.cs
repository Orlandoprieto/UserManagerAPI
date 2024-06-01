using Microsoft.EntityFrameworkCore;
using UserManagerAPI.Models;

namespace UserManagerAPI.db
{
	public class EmployeeDb : DbContext
	{
		public EmployeeDb(DbContextOptions<EmployeeDb> options) : base(options) { }

		public DbSet<Employee> Employees => Set<Employee>();
	}

	public static class Extension
	{
		public static void CreateDbIfNotExist (this IHost host)
		{
			using var scope = host.Services.CreateScope();
			var service = scope.ServiceProvider;
			var context = service.GetRequiredService<EmployeeDb>();
			context.Database.EnsureCreated();
			
			if (context.Employees.Any())
			{
				return;
			}

			var employees = new List<Employee>() 
			{
				new Employee { 
					Id = 1, 
					Name = "Orlando", 
					Lastname = "Prieto", 
					DataOfBirth = new DateTime(1996, 2, 24), 
					Position = "FrontEnd Developer", 
					StartDate = new DateTime(2020, 6, 1), 
					Salary = 460300.50m
				},
				new Employee { 
					Id = 2, 
					Name = "Javiar", 
					Lastname = "Claros", 
					DataOfBirth = new DateTime(1998, 5, 12), 
					Position = "Data Base Developer", 
					StartDate = new DateTime(2023, 4, 20), 
					Salary = 160300.85m
				}

			};

			context.Employees.AddRange(employees);
			context.SaveChanges();
		}
	}
}



