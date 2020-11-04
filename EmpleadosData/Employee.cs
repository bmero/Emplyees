using System;
using System.Collections.Generic;
using System.Text;

namespace EmpleadosData
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ContractTypeName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public object RoleDescription { get; set; }
        public double HourlySalary { get; set; }
        public double MonthlySalary { get; set; }
    }
}
