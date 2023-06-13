using Employee.DB;
using Employee.Models.Interfaces;

namespace Employee.Models.imlementation
{
	public class SqlEmployeeRepositry : IEmployeeRepositry
	{
		private readonly AppDbContext dbContext;
		public SqlEmployeeRepositry(AppDbContext Db) {

			this.dbContext = Db;		
		}
		public Employees AddEmployee(Employees em)
		{
			dbContext._Employees.Add(em);
			dbContext.SaveChanges();
			return em;
		}

		public Employees Delete(int Id)
		{
			Employees E=dbContext._Employees.Find(Id);
			if(E!=null)
			{
				dbContext._Employees.Remove(E);	
				dbContext.SaveChanges();	
		
			}
			return E;

		}

		public Employees Delete(Employees em)
		{
			Employees E = dbContext._Employees.Find(em.Id);
			if(E!=null)
			{
				dbContext._Employees.Remove(E);	
				dbContext.SaveChanges();	
				return E;	
			}
			return E;
		}

		public Employees GetEmployee(int Id)
		{
			Employees E = dbContext._Employees.Find(Id);
				return E;
		}

		public IEnumerable<Employees>? GetEmployees()
		{
			 return dbContext._Employees;
		}

		public Employees UpdateEmployee(Employees em)
		{

			if (dbContext._Employees.Find(em.Id) != null)
			{
				dbContext._Employees.Update(em);	
				dbContext.SaveChanges();
				
			}
			return em;
		}
	}
}
