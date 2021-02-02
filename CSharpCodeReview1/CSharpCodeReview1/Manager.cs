using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CSharpCodeReview1
{
    public class Boss : Employee
    {
        private const int MONTHS_OF_YEAR = 12;
        private double perEmployeeSalaryBonus;
        private HashSet<Employee> employees;


        /// <summary>
        /// Constructor for Boss class.
        /// </summary>
        /// <param name="department">Department under boss control.</param>
        public Boss()
        {
            employees = new HashSet<Employee>();
        }

        public Boss(int id, string firstName, string lastName, string job, DateTime birthDate, double monthlySalary) :
            base(id, firstName, lastName, job, birthDate, monthlySalary)
        {
            employees = new HashSet<Employee>();
        }

        public double SalaryBonusPerEmployee
        {
            get => perEmployeeSalaryBonus;
            set
            {
                if (value >= 0.0)
                    perEmployeeSalaryBonus = value;
            }
        }

        public void Add(Employee employee)
        {
            if (employee == null) throw new ArgumentNullException("Employee is null");
            employees.Add(employee);
        }

        /// <summary>
        /// Method on remove employee from boss control.
        /// </summary>
        /// <param name="employee">Employee which is remove from boss control.</param>
        public void Remove(Employee employee)
        {
            if (employee == null) throw new ArgumentNullException("Employee is null");
            employees.Remove(employee);
        }


        /// <summary>
        /// Method which return if employess is under boss control.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>Return true if employee is found. Else return false.  </returns>
        public bool HasEmployee(Employee employee)
        {
            // todo: complete this function
        }


        /// <summary>
        /// Method which return all employees.
        /// </summary>
        /// <returns>Return all employees in HashSet.</returns>
        public ISet<Employee> GetEmployees() => new HashSet<Employee>(employees);

        /// <summary>
        /// Property for get count of employees.
        /// </summary>
        /// <returns>Return count of employees.</returns>
        public int EmployeeCount => employees.Count;

        /// <summary>
        /// Method which calculate year salary and subemployee bonus (include boss salary).
        /// </summary>
        /// <returns>Return value of year department salary.</returns>
        public double CalcYearlySalary() => base.CalcYearlySalary() + CalculateYearlyBonusForEmployees();

        private double CalculateYearlyBonusForEmployees() => EmployeeCount * perEmployeeSalaryBonus * MONTHS_OF_YEAR;

        /// <summary>
        /// Method calculate yearly income of all employees (with VAT).
        /// </summary>
        /// <returns>Return calculate yearly income after tax.</returns>
        public double CalcYearlyIncome() => ApplyTaxRateToSalary(CalcYearlySalary());

        protected override double ApplyTaxRateToSalary(double salary) => salary * (1 - Boss.TaxRate);

        public override string ToString() => base.ToString() + $"; Employee count={GetEmployees().Count}";

    }
}