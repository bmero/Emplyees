using EmpleadosData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Empleados.Model
{
    public class EmployeeViewModel
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public double SalaryAnual { set; get; }


        public static double calcsSalary(Employee emp)
        {
            double salaryAnual = 0;
            if (emp.ContractTypeName == "HourlySalaryEmployee")
            {
                salaryAnual = 120 * emp.HourlySalary * 12;
            }
            else if (emp.ContractTypeName == "MonthlySalaryEmployee")
            {
                salaryAnual = emp.MonthlySalary * 12;
            }
            return salaryAnual;
        }

    }

}
