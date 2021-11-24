using System;

namespace ADOProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            EmployeeModel model = new EmployeeModel();
            model.employeeName = "archana";
            model.employeeSalary = 50000;
           /* model.startDate =DateTime.Now;
            model.gender = "F";
            model.phoneNumber = 546743289;*/

            EmployeeRepository employeeRepository = new EmployeeRepository();
            // employeeRepository.retriveEmployeeDetails();
            // employeeRepository.AddEmployee(model);
            employeeRepository.UpdateEmployeeDetails(model);
            Console.ReadLine();

        }
    }
}
