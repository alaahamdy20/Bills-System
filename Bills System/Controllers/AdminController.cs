using Bills_System.Data;
using Bills_System.Models;
using Bills_System.Repository;
using Bills_System.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Bills_System.Controllers
{
	public class AdminController : Controller
	{
		private readonly ICompanyRepository companyRepository;

		public AdminController(ICompanyRepository CompanyRepository)
		{
			companyRepository = CompanyRepository;
		}
		
		#region Index
		public IActionResult Index()
		{
			return View();
		}
        #endregion

        #region 1.1 Manage Company data

        //[Route("company_data")]
		public IActionResult CreateCompany()
		{
			return View();
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		//[Route("company_data")]
		public IActionResult CreateCompany(Company comapny)
		{
			if (!ModelState.IsValid) 
				return View(comapny);
			else
			{

				
			

				companyRepository.Add(comapny);
				return RedirectToAction(nameof(Index));

			}
		}
		#endregion

		#region 1.2 Manage Items

		//[Route("species")]
		public IActionResult CreateType()
		{
			ViewBag.Companies = companyRepository.GetAll().Select(c => new SelectListItem() { Text = c.Name, Value = c.Name });
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult CreateType(ComapnyTypesViewModel comapnyTypesViewModel)
		{
			ViewBag.Companies = companyRepository.GetAll().Select(c => new SelectListItem() { Text = c.Name, Value = c.Id.ToString() });
		

			if (!ModelState.IsValid)
				return View(comapnyTypesViewModel);
			else
			{
				Type type = new Type()
				{
					Name = comapnyTypesViewModel.Name,
					Notes = comapnyTypesViewModel.Notes,
					
				};
				type.Companies.Add(companyRepository.GetByName(comapnyTypesViewModel.ComapnyName));
				typeRepository.Add(type);
				return RedirectToAction(nameof(Index));

			}
		}
		#endregion

		#region 1.3 Manage Units

		//[Route("units")]
		public IActionResult CreateUnit()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult CreateUnit(Unit unit)
		{
			unitRepository.Add(unit);
			return View();
		}
		
		#endregion

		#region 1.4 Manage Categories

		public IActionResult CreateCategory()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult CreateCategory(Company company)
		{
			return View(company);
		}
		#endregion

		#region 1.5 Manage Clients

		[Route("clients")]
		public IActionResult CreateClient()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult CreateClient(Company company)
		{
			return View(company);
		}
		#endregion

		#region 1.6 Creating Invoices

		[Route("sales")]
		public IActionResult CreateInvoice()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult CreateInvoice(Company company)
		{
			return View(company);
		}
		#endregion

		#region 1.7 Retrieve Sales Reporting
		/*[Route("sales_report")]
		public IActionResult CreateSalesReport()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult CreateSalesReport(Company company)
		{
			return View(company);
		}*/
		#endregion


		#region 1.1 Remote


		public IActionResult IsNameAvailble(string Name)
		{
			Company company = companyRepository.GetByName(Name);

			if (company != null)
			{
				return Json(false);

			}
			return Json(true);
		}



		#endregion

		#region 1.2 Remote

		public IActionResult IsTypeExisted(string Name,string ComapnyName)
		{
			Company company = companyRepository.GetByName(ComapnyName);

			Type type = company.Types.FirstOrDefault(t => t.Name.ToLower() == Name.ToLower());

			if (type != null)
			{
				return Json(false);

			}
			return Json(true);
		}

		#endregion





	}
}
