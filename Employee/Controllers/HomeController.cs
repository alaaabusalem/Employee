using Employee.Models;
using Employee.Models.Interfaces;
using Employee.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly IEmployeeRepositry _IEmployeeRepositry;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _HostingEnvironment;   
        public HomeController(IEmployeeRepositry _IEmployeeRepositry, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            this._IEmployeeRepositry = _IEmployeeRepositry;
            this._HostingEnvironment = hostingEnvironment;  

        }
      
        public ViewResult Index()
        {
            IEnumerable<Employees> em = _IEmployeeRepositry.GetEmployees();

            return View(em);
        }


        public ViewResult Details(int Id)
        {

            //if (_IEmployeeRepositry.GetEmployee(Id) == null)
            //   return View(null);

            Employees em = _IEmployeeRepositry.GetEmployee(Id);
            return View(em);

        }
        [HttpGet]
		public ViewResult Creat()
		{
			CreatViewModel em = new();

			return View(em);
		}
        [HttpPost]
		public IActionResult Creat(CreatViewModel employee)
		{
            string filePath = string.Empty;

			if (ModelState.IsValid){
                if(employee.photo != null)
                {
					filePath = PhotoInfo(employee);
                  
                }
                Employees emp = new();
                emp.Name= employee.Name;
                emp.PhotoPath = filePath;
                emp.Email= employee.Email; 
                emp.Department= employee.Department;    

             emp= _IEmployeeRepositry.AddEmployee(emp);

                return RedirectToAction("Details", new { Id = emp.Id }); }
            return View();
            
		}
        public string PhotoInfo(CreatViewModel em)
        {

            string uploadsFolder = Path.Combine(_HostingEnvironment.WebRootPath, "image");
            string uniqueFileName=Guid.NewGuid().ToString()+"_"+ em.photo.FileName;
			//string filePath=Path.Combine(uploadsFolder,uniqueFileName);
			string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                em.photo.CopyTo(fileStream);
            }
			//em.photo.CopyTo(new FileStream(filePath, FileMode.Create));
			return uniqueFileName;

        }
        [HttpGet]
        public ViewResult Edit(int Id) { 
            Employees em = new();
			em = _IEmployeeRepositry.GetEmployee(Id);
            EditViewModel editViewModel = new EditViewModel()
            {
                Id= Id, 
                Name= em.Name, 
                Department= em.Department, 
                photoPath= em.PhotoPath,
                Email= em.Email    
            };  
			return View(editViewModel);
		}
		[HttpPost]
		public IActionResult Edit(EditViewModel employee)
		{
            string fileName = string.Empty;

			if (ModelState.IsValid)
			{
				if (employee.photo != null)
				{
                    if(employee.photoPath != null)
                    {
						fileName = Path.Combine(_HostingEnvironment.WebRootPath, "image", employee.photoPath);
                        System.IO.File.Delete(fileName);
                    }
					fileName = PhotoInfo(employee);

				}
				Employees emp = new();
                emp.Id=employee.Id;
				emp.Name = employee.Name;
				emp.PhotoPath = fileName;
				emp.Email = employee.Email;
				emp.Department = employee.Department;

				emp = _IEmployeeRepositry.UpdateEmployee(emp);
				//new { Id = emp.Id }
				return RedirectToAction("Details",  emp.Id );
			}
			return View();

		}


		[HttpGet]
		public ViewResult Delet(int Id)
		{
			Employees em = new();
			em = _IEmployeeRepositry.GetEmployee(Id);
			
			return View(em);
		}

          
		public IActionResult DeletEmployee(int Id)
		{
			Employees employee = new();

			employee = _IEmployeeRepositry.GetEmployee(Id);

			_IEmployeeRepositry.Delete(employee);
            if (employee.PhotoPath != null)
            {
                string filePath;

                filePath = Path.Combine(_HostingEnvironment.WebRootPath, "image", employee.PhotoPath);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }


			return RedirectToAction("Index");
			}
			



		}
}