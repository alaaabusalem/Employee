namespace Employee.Models.Interfaces
{
    public interface IEmployeeRepositry
    {
         Employees GetEmployee(int id);

        public IEnumerable<Employees>? GetEmployees();
        public Employees AddEmployee(Employees em);
		public Employees UpdateEmployee (Employees em);
		public Employees Delete(Employees em);


	}
}
