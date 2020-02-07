using System;
using System.Collections.Generic;
using InterviewTestTemplatev2.Data;
using InterviewTestTemplatev2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SynetecMvcAssessment.UnitTests
{
    [TestClass]
    public class BonusAllocationTests
    {
        [TestMethod]
        public void PayrollCostTocompany_CalculatePayrollCostTocompany_ReturnPayrollCostTocompany()
        {
            var payroll = new Payroll();

            List<HrEmployee> Employees = new List<HrEmployee>();
            var Employee1 = new HrEmployee();
            Employee1.Salary = 500000;
            Employees.Add(Employee1);

            var Employee2 = new HrEmployee();
            Employee2.Salary = 250000;
            Employees.Add(Employee2);
     
            var result = (int)payroll.PayrollCostTocompany(Employees);

            Assert.AreEqual(result, 750000 );
        }

        [TestMethod]
        public void BonusAllocationCalculation_CalculateBonusAllocation_ReturnBonusAllocation()
        {
            var allocation = new Allocation();
            var employee = new HrEmployee();
            var payroll = new Payroll();
            var bonusPool = new BonusPool();

            employee.Salary = 50000;
            payroll.TotalCostToCompany = 1000000;
            bonusPool.BonusPoolAmount = 1000;

            var result = allocation.BonusAllocationCalculation(employee, payroll, bonusPool);
            Assert.AreEqual(result, 50);
        }

        [TestMethod]
        public void BonusAllocationPercentageCalculation_CalculateBonusAllocationPercentage_ReturnBonusAllocationPercentage()
        {
            var allocation = new Allocation();
            var employee = new HrEmployee();
            var payroll = new Payroll();          

            employee.Salary = 20000;
            payroll.TotalCostToCompany = 1000000;        

            var result = (decimal)allocation.BonusAllocationPercentageCalculation(employee, payroll);
            Assert.AreEqual(result, (decimal)0.02);
        }
    }
}
