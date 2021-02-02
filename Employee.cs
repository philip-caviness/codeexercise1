using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SampleBadApplication
{
    [DataContract]
    public class Employee
    {
        private DateTime _birthDate;

        [DataMember]
        public DateTime BirthDate
        {
            get
            {
                return _birthDate;
            }
            set
            {
                _birthDate = value;
                Age = CalculateAge();
            }
        }

        private int id;

        [DataMember]
        public int Id
        {
            get => id; set
            {
                this.id = value;
                Employee.nextID = value >= Employee.nextID ? this.id + 1 : Employee.nextID;
            }
        }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string JobTitle { get; set; }

        [DataMember]
        public double MonthlySalaryCZK { get; set; }

        public static double TaxRate => 0.21;

        public int Age { get; private set; }

        private static int nextID = 0;

        public Employee(int id, string firstName, string lastName, string jobTitle, DateTime birthDate, double monthlySalaryCZK)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            JobTitle = jobTitle;
            BirthDate = birthDate;
            MonthlySalaryCZK = monthlySalaryCZK;
        }

        public Employee() { }


        /// <summary>
        /// Always contains the next available ID
        /// </summary>
        public static int NextID
        {
            get
            {
                return Employee.nextID++;
            }
        }

        /// <summary>
        /// Method to calculate age of employee in days
        /// </summary>
        /// <returns>Age of employee in days as int</returns>
        private int CalculateAge()
        {
            // todo: complete this function
        }

        /// <summary>
        /// Method to count sum of 12 salaries (one per month) of the employee
        /// based on attribute monthlySalaryCZK
        /// </summary>
        /// <returns>Sum of all the 12 salaries</returns>
        public virtual double CalcYearlySalaryCZK()
        {
            return MonthlySalaryCZK * 12;
        }

        /// <summary>
        /// Method to count the net income of the employee
        /// based on attribute taxRate
        /// calls method CalcYearlySalaryCZK
        /// </summary>
        /// <returns>Net income of the employee after taxes</returns>
        public virtual double CalcYearlyIncome()
        {
            // todo: complete this function
        }

        /// <summary>
        /// Method to calculate salary after taxation
        /// </summary>
        /// <param name="salary">Salary of employee</param>
        /// <returns>Salary after to taxation</returns>
        protected virtual double ApplyTaxRateToSalary(double salary)
        {
            return salary * (1 - TaxRate);
        }

        public override string ToString() => $"ID:  {Id}; NAME: {FirstName} {LastName}; JOB:{JobTitle}; SALARY: {MonthlySalaryCZK}";

    }
}