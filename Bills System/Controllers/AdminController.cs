using Bills_System.Data;
using Bills_System.Models;
using Bills_System.Repository;
using Microsoft.AspNetCore.Mvc;
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
		public IActionResult CreateCompany(Company company)
		{
			if (!ModelState.IsValid) 
				return View(company);
			else
			{
				companyRepository.Add(company);
				return RedirectToAction(nameof(Index));

			}
		}
		#endregion

		#region 1.2 Manage Items

		[Route("species")]
		public IActionResult CreateType()
		{
			ViewBag.Companies =  companyRepository.GetAll();
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult CreateType(Company company)
		{
			ViewBag.Companies = companyRepository.GetAll();

			if (!ModelState.IsValid)
				return View(company);
			else
			{
				companyRepository.Add(company);
				return RedirectToAction(nameof(Index));

			}
		}
		#endregion

		#region 1.3 Manage Units

		[Route("units")]
		public IActionResult CreateUnit()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult CreateUnit(Company company)
		{
			return View(company);
		}
		#endregion

		#region 1.4 Manage Categories

		[Route("categories")]
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

		/*public IActionResult IsTypeExisted(string Name,int id)
		{
			Company company = dBContext.Companies.FirstOrDefault(c => c.Id == id);
			company.Types.FirstOrDefault(t => t.Name.ToLower() == Name);
			return View();
		}
		*/
		#endregion




	}
}
