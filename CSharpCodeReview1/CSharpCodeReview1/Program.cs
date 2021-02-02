using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace CSharpCodeReview1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employeeArray = new List<Employee>();
            var filename = "employeelist.csv";

            try
            {
                StreamReader reader = new StreamReader(filename);
                string line;    
                while ((line = reader.ReadLine()) != null)
                {
                    employeeArray.Add(parseRow(line));

                    SaveToDb(parseRow(line));
                }
                
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("error: "+ex.Message);
            }

            for(var i = 0; i <= employeeArray.Count; i++)
            {
                Console.WriteLine($"Position {i} has ID of {employeeArray[i].Id}");
            }
        }

        private static Employee parseRow(string csvdatarow)
        {
            try
            {
                // pretend parsing code is here with csvdatarow
            }
            catch (Exception ex)
            {
                throw;
            }

            return new Employee(
                Employee.NextID,
                "John ", "Doe", "Engineer",
                DateTime.Parse("1980-5-3"), 5000.00);
        }

        private static void SaveToDb(Employee employee)
        {
            string insertSql = 
                $"insert into employees (id, firstname, lastname) VALUES " +
                $"({employee.Id}, '{employee.FirstName}', '{employee.LastName}')";

            // pretend dbManager exists with db connection and public runQuery function 
            // dbManager.runQuery(insertSql);
        }
    }
}