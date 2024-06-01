using Microsoft.EntityFrameworkCore;
using UserManagerAPI.db;

namespace UserManagerAPI.EndPoints
{
    public class EmployeeEndPoints
    {
        public static void Map(WebApplication app)
        {
            var group = app.MapGroup("/employees");

            group.Map("/", async (EmployeeDb db) =>
            {
                return await db.Employees.ToListAsync();
            });
        }
    }
}
