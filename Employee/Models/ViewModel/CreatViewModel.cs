using System.ComponentModel.DataAnnotations;

namespace Employee.Models.ViewModel
{
	public class CreatViewModel
	{
		
		public string Name { get; set; }
		[Required]

		public string Email { get; set; }
		[Required]
		public Dept? Department { get; set; }
		public IFormFile ? photo { get; set; }
	}
}
