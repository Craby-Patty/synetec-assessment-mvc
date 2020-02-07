using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InterviewTestTemplatev2.Data;
using InterviewTestTemplatev2.Models;


namespace InterviewTestTemplatev2.Controllers
{
    public class BonusPoolController : Controller
    {

        private MvcInterviewV3Entities1 db = new MvcInterviewV3Entities1();

        public ActionResult Index()
        {            
            BonusPoolCalculatorModel model = new BonusPoolCalculatorModel();
            model.AllEmployees = getEmployees();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Calculate(BonusPoolCalculatorModel model)
        {
            int selectedEmployeeId = model.SelectedEmployeeId;
            int totalBonusPool = model.BonusPoolAmount;
            HrEmployee hrEmployee = (HrEmployee)db.HrEmployees.FirstOrDefault(item => item.ID == selectedEmployeeId);

            Payroll payroll = new Payroll();
            payroll.AllEmployees = getEmployees();
            payroll.TotalCostToCompany = payroll.PayrollCostTocompany(payroll.AllEmployees);

            BonusPool bonusPool = new BonusPool();
            bonusPool.BonusPoolAmount = totalBonusPool;       

            BonusPoolCalculatorResultModel result = new BonusPoolCalculatorResultModel();
            Allocation allocation = new Allocation();
            result.hrEmployee = hrEmployee;
            result.bonusPoolAllocation = allocation.BonusAllocationCalculation(hrEmployee, payroll, bonusPool);
            return View(result);
        }  

        public List<HrEmployee> getEmployees()
        {
            Payroll payroll = new Payroll();
            payroll.AllEmployees = db.HrEmployees.ToList<HrEmployee>();
            return payroll.AllEmployees;
        }

    }
}