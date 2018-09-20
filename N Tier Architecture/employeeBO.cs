using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employeeBusinessObjects
{
    public class employeeBO
    {
        int eid;
        string employeeName;
        double employeeSalary;
        double employeeBonusRatio;
        double employeeTax;
        string employeeDesignation;

        public employeeBO()
        {

        }
        public employeeBO(int eid,string employeeName, double employeeSalary, string employeeDesignation)
        {
            this.eid = eid;
            this.employeeSalary = employeeSalary;
            this.employeeName = employeeName;
            this.employeeDesignation = employeeDesignation;
        }
        public employeeBO(string employeeName, double employeeSalary,string employeeDesignation)
        {
            this.employeeSalary = employeeSalary;
            this.employeeName = employeeName;
            this.employeeDesignation = employeeDesignation;
        }
        public int id
        {
            get
            {
                return eid;
            }
            set
            {
                eid = value;
            }
        }
        public string empName
        {
            get
            {
                return employeeName;
            }
            set
            {
                employeeName = value;
            }
        }
        public double empSalary
        {
            get
            {
                return employeeSalary;
            }
            set
            {
                employeeSalary = value;
            }
        }
        public string empDesignation
        {
            get
            {
                return employeeDesignation;
            }
            set
            {
                employeeDesignation = value;
            }
        }
        public double empBonusRatio
        {
            get
            {
                return employeeBonusRatio;
            }
            set
            {
                employeeBonusRatio = value;
            }
        }
        public double empTax
        {
            get
            {
                return employeeTax;
            }
            set
            {
                employeeTax = value;
            }
        }

    }
}
