using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using adminBusinessObjects;
using employeeBusinessObjects;
using userBusinessObjects;
using dataAccessLayer;
using System.Data.SqlClient;
using System.Collections;

namespace businessLogicLayer
{
    public class logicLayer
    {
        adminDAL adal = new adminDAL();
        private bool wrongDesignation = false;
        static string connectionString = @"Data Source=DEADPOOL\SQLEXPRESS;Initial Catalog=Assignment1;Integrated Security=True";

        public bool changeUserPassword(userBO obj)
        {
            bool passwordChange = false;
            makeUserPasswordEncrypted(obj);
            passwordChange=adal.changeUserPassword(obj);
            return passwordChange;
        }
        public bool loginUser(userBO obj)
        {
            bool loginUser = false;
            makeUserPasswordEncrypted(obj);
            loginUser = adal.loginUser(obj);
            return loginUser;
        }
        public bool registerUser(userBO obj)
        {
            bool register = false;
            makeUserPasswordEncrypted(obj);
            register=adal.registerUser(obj);
            return register;
        }
        public void makeUserPasswordEncrypted(userBO obj)
        {
            string psw = obj.psw;
            char[] encrypt_psw = new char[25];
            int increment = 0;
            for(int i=0,j=psw.Length-1;i < j; i++, j--)
            {
                encrypt_psw[increment++] =  psw.ElementAt(i);
                encrypt_psw[increment++] = psw.ElementAt(j);
            }
            string psw_encrypted = new string(encrypt_psw);
            obj.psw = psw_encrypted;
        }
        public void searchEmployee(int id)
        {
            adal.searchEmployee(id);
        }
        public void deleteEmployee(int id)
        {
            adal.deleteEmployee(id);
        }
        public bool loginAdmin(adminBO obj)
        {
            bool admin=adal.loginAdmin(obj);
            return admin;
        }
        public bool editEmployee(employeeBO obj)
        {
            bool employeeDesignation = false;
            amendEmployee(obj);
            employeeDesignation=addEmployeeDetails(obj);
            if (employeeDesignation == true)
            {

            }
            else
            {
                adal.editEmployee(obj);
            }
            return employeeDesignation;
        }
        public void amendEmployee(employeeBO obj)
        {
            SqlConnection s = new SqlConnection(connectionString);
            if (obj.empName.Length == 0)
            {
                string query = "select name from employees where eid= '" + obj.id + "' ";
                SqlCommand cmd = new SqlCommand(query, s);
                s.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                obj.empName = dr[0].ToString();
            }
            if (obj.empDesignation.Length == 0)
            {
                string query = "select * from employees where eid= '" + obj.id + "' ";
                SqlCommand cmd = new SqlCommand(query, s);
                s.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.empDesignation = dr[5].ToString();
                }
            }
            if (obj.empSalary == 0)
            {
                string query = "select * from employees where eid= '" + obj.id + "' ";
                SqlCommand cmd = new SqlCommand(query, s);
                s.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    obj.empSalary = int.Parse(dr[2].ToString());
                }
            }
        }
        public bool addEmployee(employeeBO obj)
        {
            bool wrongDesignation = false;
            wrongDesignation=addEmployeeDetails(obj);
            if (wrongDesignation == true)
            {

            }
            else
            {
                adal.addEmployee(obj);
            }
            return wrongDesignation;

        }
        public bool addEmployeeDetails(employeeBO obj)
        {
            wrongDesignation = false;
            if(obj.empDesignation=="manager")
            {
                double tax = (15* obj.empSalary)/100;
                obj.empTax = tax;
                double bonus = (10 * obj.empSalary)/100;
                obj.empBonusRatio = bonus;
            }
            else if (obj.empDesignation == "Manager")
            {
                double tax = (15 * obj.empSalary) / 100;
                obj.empTax = tax;
                double bonus = (10 * obj.empSalary) / 100;
                obj.empBonusRatio = bonus;
            }
            else if (obj.empDesignation == "developer")
            {
                double tax = (12 * obj.empSalary) / 100;
                obj.empTax = tax;
                double bonus = (50 * obj.empSalary) / 100;
                obj.empBonusRatio = bonus;
            }
            else if (obj.empDesignation == "Developer")
            {
                double tax = (12 * obj.empSalary) / 100;
                obj.empTax = tax;
                double bonus = (50 * obj.empSalary) / 100;
                obj.empBonusRatio = bonus;
            }
            else if(obj.empDesignation=="HR")
            {
                double tax = (10 * obj.empSalary) / 100;
                obj.empTax = tax;
                double bonus = (20 * obj.empSalary) / 100;
                obj.empBonusRatio = bonus;
            }
            else if (obj.empDesignation == "hr")
            {
                double tax = (10 * obj.empSalary) / 100;
                obj.empTax = tax;
                double bonus = (20 * obj.empSalary) / 100;
                obj.empBonusRatio = bonus;
            }
            else
            {
                wrongDesignation = true;
            }
            return wrongDesignation;
        }
     }
}
