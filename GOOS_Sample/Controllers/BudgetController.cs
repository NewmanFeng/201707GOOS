using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GOOS_Sample.Models;
using GOOS_Sample.Models.DataModels;
using GOOS_Sample.ViewModels;

namespace GOOS_Sample.Controllers
{
    public class BudgetController : Controller
    {
        private IBudgetService budgetServiceStub;


        public BudgetController()
        {
            this.budgetServiceStub = new BudgetService();
        }

        public BudgetController(IBudgetService budgetServiceStub)
        {
            this.budgetServiceStub = budgetServiceStub;
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(BudgetAddViewModel model)
        {
            this.budgetServiceStub.Create(model);
            ViewBag.Message = "added successfully";
            return View(model);
        }
    }

    public class BudgetService : IBudgetService
    {
        public void Create(BudgetAddViewModel model)
        {
            using (var dbcontext = new NorthwindEntities())
            {
                var budget = new Budget() { Amount = model.Amount, YearMonth = model.Month };
                dbcontext.Budgets.Add(budget);
                dbcontext.SaveChanges();
            }
        }
    }
}