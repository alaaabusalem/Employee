using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Employee.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee.DB.Extentions
{
	public static class ModelBuilderExtentions
	{
		public static void seed (this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Employees>().HasData(
				new Employees {Id=1, Name="ali",
				Department=Dept.Hr,
				Email="ali@hotmail.com",
					
				},
				new Employees {Id=2,
					Name = "ali",
					Department = Dept.Enginering,
					Email = "ali@hotmail.com",

				}

				);
		}
	}
}
