using Employee.Models.Interfaces;

namespace Employee.Models.imlementation
{
    public class MockEmployeeRepositry : IEmployeeRepositry
    {

        private List<Employees> ? _employees;  
        public MockEmployeeRepositry() { 
        _employees= new List<Employees>()
        {
            new Employees(){Id=1,Name="alaa",Email="alaa@company.com",Department=Dept.Hr},
            new Employees(){Id=2,Name="Ahmad",Email="ahmad@company.com",Department=Dept.Playroll },
            new Employees(){Id=3,Name="Kady",Email="Kady@company.com",Department=Dept.Hr},
            new Employees(){Id=4,Name="sara",Email="sara@company.com",Department=Dept.Enginering},

        };   
        
        }

		public Employees AddEmployee(Employees em)
		{
            em.Id =_employees.Max(em=>em.Id)+1;
            _employees.Add(em);
            return em;
		}

		public Employees Delete(int Id)
		{
			throw new NotImplementedException();
		}

		public Employees Delete(Employees em)
		{
			throw new NotImplementedException();
		}

		public Employees ? GetEmployee(int id)
        {
           
            return _employees.FirstOrDefault(em => em.Id == id);
            
        }
        public IEnumerable<Employees>? GetEmployees()
        {

            return _employees;

        }

		public Employees UpdateEmployee(Employees em)
		{
			throw new NotImplementedException();
		}
	}
}
