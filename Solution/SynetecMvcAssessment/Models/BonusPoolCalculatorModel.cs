using InterviewTestTemplatev2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewTestTemplatev2.Models
{
    public class BonusPoolCalculatorModel
    {
        public int BonusPoolAmount { get; set; }
        public List<Data.HrEmployee> AllEmployees { get; set; }        
        public int SelectedEmployeeId { get; set; }
    }

    public class Payroll
    {
        public int NumberOfActiveEmployees { get; set; }
        public int TotalCostToCompany { get; set; }
        public List<Data.HrEmployee> AllEmployees { get; set; }

        public int PayrollCostTocompany(List<HrEmployee> hrEmployees)
        {
            int result = (int)hrEmployees.Sum(item => item.Salary);
            return result;
        }

    }

    public class Allocation
    {
        public decimal PercentAllocation { get; set; }
        public int AmountAllocation { get; set; }

        public decimal BonusAllocationPercentageCalculation(HrEmployee hrEmployee, Payroll payroll)
        {
            decimal result = (decimal)hrEmployee.Salary / (decimal)payroll.TotalCostToCompany;

            return result;
        }

        public int BonusAllocationCalculation(HrEmployee hrEmployee, Payroll payroll, BonusPool bonusPool)
        {
            Allocation EmployeeAllocation = new Allocation();

            EmployeeAllocation.PercentAllocation = BonusAllocationPercentageCalculation(hrEmployee, payroll);

            int result = (int)(EmployeeAllocation.PercentAllocation * bonusPool.BonusPoolAmount);

            return result;
        }


    }

    public class BonusPool
    { 
        public int BonusPoolAmount { get; set; }
    }


}