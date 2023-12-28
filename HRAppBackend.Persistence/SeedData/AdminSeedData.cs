using HRAppBackend.Domain.Entities;
using HRAppBackend.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRAppBackend.Persistence.SeedData
{
	public class AdminSeedData
	{
		public static class ApplicationDbContextSeed
		{
			public static async Task SeedDataAsync(AppDbContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
			{
				// Veritabanında herhangi bir kullanıcı var mı kontrol et
				if (!context.Users.Any())
				{

					if (!context.Roles.Any(x => x.Name == "Admin"))
					{
						IdentityRole adminRole = new() { Name = "Admin" };
						roleManager.CreateAsync(adminRole).Wait();
					}



					//Kullanıcı oluştur
					var user = new AppUser
					{
						UserName = "admin@example.com",
						Email = "admin@example.com",
						EmailConfirmed = true,
						ConfirmCode = 123456, // ConfirmCode değerini dilediğiniz gibi değiştirin
											  // Diğer gerekli özellikleri de burada set edebilirsiniz
					};

					// Kullanıcıyı veritabanına ekleyin
					await userManager.CreateAsync(user, "YourPasswordHere"); // Şifreyi güvenli bir şifre ile değiştirin

					// Employee örneği oluşturun
					var employee = new Employee
					{
						FirstName = "John",
						LastName = "Doe",
						// Diğer gerekli özellikleri de burada set edebilirsiniz
					};

					if (!context.Professions.Any())

					{
						context.Professions.AddRange(
							new Profession { Name = "Müdür" },

							new Profession { Name = "Mühendis" },

							new Profession { Name = "Yazılımcı" }

						);

						context.SaveChanges();
					}

					// Departmanları ekle
					if (!context.Departments.Any())
					{

						context.Departments.AddRange(

							new Department { Name = "IT" },

							new Department { Name = "IK" },

							new Department { Name = "İşletme" }

						);


						context.SaveChanges();

					}

					// Oluşturulan örnekleri veritabanına ekleyin
					context.Employees.Add(employee);
					

					// İlişkileri ayarlayın
					user.Employee = employee;
					employee.AppUser = user;

					AppUser createdUser = await userManager.FindByNameAsync("admin@example.com");
					IdentityRole role = await roleManager.FindByNameAsync("Admin");
					await userManager.AddToRoleAsync(createdUser, role.Name);



					// Veritabanını güncelle
					await context.SaveChangesAsync();
				}
			}
		}

		//public static async void Seed(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, AppDbContext _context)
		//{
		//	if(!_context.Roles.Any(x=>x.Name == "Admin"))
		//	{
		//		IdentityRole adminRole = new() { Name = "Admin" };
		//		roleManager.CreateAsync(adminRole).Wait();
		//	}

		//	if(!_context.Users.Any(x=>x.UserName == "Admin"))
		//	{
		//		AppUser user = new()
		//		{
		//			UserName = "Admin",
		//			Email = "admin@bilgeadamboost.com",
		//			EmailConfirmed = true
		//		};

		//		userManager.CreateAsync(user, "BoostTeam2.").Wait();

		//		Profession profession = new()
		//		{
		//			Name = "Software Developer"
		//		};

		//		Department department = new()
		//		{
		//			Name = "IT"
		//		};



		//		Employee employee = new()
		//		{
		//			 FirstName = "Şakir",
		//			 LastName = "Kral",
		//			 StartDate = DateTime.Now,
		//			 AppUserId = user.Id,

		//		}




		//		AppUser createdUser = await userManager.FindByNameAsync()
		//	}


		//}



	}
}
