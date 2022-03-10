using Bills_System.Data;
using Bills_System.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Bills_System.Controllers
{
	public class AdminController : Controller
	{
		private readonly ApplicationDBContext dBContext;

		public AdminController(ApplicationDBContext dBContext)
		{
			this.dBContext = dBContext;
		}
		
		#region Index
		public IActionResult Index()
		{
			return View();
		}
        #endregion

        #region 1.1 Manage Company data

        [Route("company_data")]
		public IActionResult CreateCompany()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Route("company_data")]
		public IActionResult CreateCompany(Company company)
		{
			if (!ModelState.IsValid) 
				return View(company);
			else
				return RedirectToAction(nameof(Index));
		}
		#endregion

		#region 1.2 Manage Items

		[Route("species")]
		public IActionResult CreateType()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult CreateType(Company company)
		{
			return View(company);
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

		[HttpPost]
		public IActionResult IsAlreadyExisted(string Name)
		{

			return Json(IsNameAvailable(Name));

		}

		public bool IsNameAvailable(string Name)
		{
			
			bool status;
			Company company = dBContext.Companies.FirstOrDefault(c=>c.Name.ToLower() == Name); 
			if (company != null)
			{
				//Already registered  
				status = false;
			}
			else
			{
				//Available to use  
				status = true;
			}


			return status;
		}

		#endregion

	}
}
