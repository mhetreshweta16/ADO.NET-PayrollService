using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOProject
{
    class EmployeeRepository
    {
        EmployeeModel model = new EmployeeModel();
        public static string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=payroll_service;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection sqlConnection = new SqlConnection(connectionString);

        public void retriveEmployeeDetails()
        {
            try
            {
                string query = @"select * from employee_payroll";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        model.employeeId = Convert.ToInt32(reader["id"] == DBNull.Value ? default : reader["id"]);
                        model.employeeName = reader["name"] == DBNull.Value ? default : reader["name"].ToString();
                        model.employeeSalary = Convert.ToDouble(reader["salary"] == DBNull.Value ? default : reader["salary"]);
                        model.startDate = (DateTime)(reader["startDate"] == DBNull.Value ? default : reader["startDate"]);
                        model.gender = reader["gender"] == DBNull.Value ? default : reader["gender"].ToString();
                        model.phoneNumber = Convert.ToInt32(reader["phone"] == DBNull.Value ? default : reader["phone"]);
                        model.address = reader["address"] == DBNull.Value ? default : reader["address"].ToString();
                        model.department = reader["department"] == DBNull.Value ? default : reader["department"].ToString();
                        model.basicPay = Convert.ToDouble(reader["basic_pay"] == DBNull.Value ? default : reader["basic_pay"]);
                        model.deduction = Convert.ToDouble(reader["deduction"] == DBNull.Value ? default : reader["deduction"]);
                        model.taxeablePay = Convert.ToDouble(reader["taxeable_pay"] == DBNull.Value ? default : reader["taxeable_pay"]);
                        // model.incomeTax = Convert.ToDouble(reader["incometax"] == DBNull.Value ? default : reader["incometax"]);
                        //model.netPay = Convert.ToDouble(reader["netpay"] == DBNull.Value ? default : reader["netpay"]);
                        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10}", model.employeeId, model.employeeName, model.employeeSalary,
                            model.startDate, model.gender, model.phoneNumber, model.address, model.department, model.basicPay, model.deduction, model.taxeablePay);
                        Console.WriteLine("\n");

                    }
                }
                else
                {
                    Console.WriteLine("no rows present");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        /// <summary>
        /// Adds the employee.
        /// </summary>
        /// <param name="model">The model.</param>
        public void AddEmployee(EmployeeModel model)
        {
            try
            {
                using (this.sqlConnection)
                {
                    SqlCommand command = new SqlCommand("dbo.SpAddEmployeeDetails", this.sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", model.employeeName);
                    command.Parameters.AddWithValue("@salary", model.employeeSalary);
                    command.Parameters.AddWithValue("@startdate", model.startDate);
                    command.Parameters.AddWithValue("@gender", model.gender);
                    command.Parameters.AddWithValue("@phone", model.phoneNumber);

                    sqlConnection.Open();
                    var res = command.ExecuteNonQuery();
                    if (res != 0)
                    {
                        Console.WriteLine("successfully inserted..");
                    }
                    else
                        Console.WriteLine("unsuccessfull");

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void UpdateEmployeeDetails(EmployeeModel model)
        {
            try
            {
                using (this.sqlConnection)
                {
                    SqlCommand command = new SqlCommand("dbo.SpUpdateDetails", this.sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", model.employeeName);
                    command.Parameters.AddWithValue("@salary", model.employeeSalary);
                    
                   sqlConnection.Open();
                    var res = command.ExecuteNonQuery();
                    if (res != 0)
                    {
                        Console.WriteLine("successfully Updated");
                    }
                    else
                        Console.WriteLine("unsuccessfull");

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                sqlConnection.Close();
            }


        }

    }
}
