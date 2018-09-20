using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using adminBusinessObjects;
using employeeBusinessObjects;
using userBusinessObjects;
using System.IO;
using System.Data.SqlClient;
using System.Collections;

namespace dataAccessLayer
{
    public class adminDAL
    {
        static string connectionString = @"Data Source=DEADPOOL\SQLEXPRESS;Initial Catalog=Assignment1;Integrated Security=True";

        public bool changeUserPassword(userBO obj)
        {
            bool passwordChange = false;
            SqlConnection s = new SqlConnection(connectionString);
            string query = "update users set password= '" + obj.psw + "' where uid= '" + obj.id + "' ";
            SqlCommand cmd = new SqlCommand(query, s);
            s.Open();

            int i = cmd.ExecuteNonQuery();

            if (i > 0)
            {
                passwordChange = true;
            }
            else
            {
                passwordChange = false;
            }
            return passwordChange;
        }
        public bool loginUser(userBO obj)
        {
            SqlConnection s = new SqlConnection(connectionString);

            bool userAuth = false;

            string query = "select * from users where (userName = '" + obj.name + "')  and (password= '" + obj.psw + "') ";

            SqlCommand cmd = new SqlCommand(query, s);
            s.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            Console.WriteLine("");
            Console.WriteLine("");
            while (dr.Read())
            {                
                Console.WriteLine("                         - - -Welcome User " + dr[1] + "- - -         ");
                userAuth = true;
            }

            s.Close();
            return userAuth;
        }
        public bool registerUser(userBO obj)
        {
            bool registered = false;
            int uidIncrement = getUserID();
            uidIncrement++;
            //Console.WriteLine(eidIncrement);

            SqlConnection s = new SqlConnection(connectionString);
            string query = "insert into users(uid,username,password) Values ('" + uidIncrement + "' , '" + obj.name + "','" + obj.psw + "')";
            //string query = "insert into employees (eid,name,salary,bonusRatio,tax,designation) Values ('" + eidIncrement + "','" + obj.empName + "','" + obj.empSalary + "', '" + obj.empBonusRatio + "','" + obj.empTax + "','" + obj.empDesignation + "')";
            //eidIncrement++;
            SqlCommand cmd = new SqlCommand(query, s);
            s.Open();

            int i = cmd.ExecuteNonQuery();

            if (i > 0)
            {
                registered = true;
                //Console.WriteLine("User is registered.");
            }
            else
            {
                //Console.WriteLine("User is not registered.");
                registered = false;
            }
            return registered;
        }
        public void searchEmployee(int id)
        {
            SqlConnection s = new SqlConnection(connectionString);

            string query = "select * from employees where eid= '" + id + "'";

            SqlCommand cmd = new SqlCommand(query, s);
            s.Open();

            Console.WriteLine("");
            Console.WriteLine("");
            int check = 0;

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine("                 Name: " + dr[1]);
                Console.WriteLine("                 Salary: " + dr[2]);
                Console.WriteLine("                 Bonus ratio: " + dr[3]);
                Console.WriteLine("                 Tax: " + dr[4]);
                Console.WriteLine("                 Designation: " + dr[5]);
                check = 1;
            }
            if(check==0)
            {
                Console.WriteLine("");
                Console.WriteLine("                        ** No such employee exists. **                     ");
            }
            s.Close();
        }
        public void deleteEmployee(int id)
        {
            SqlConnection s = new SqlConnection(connectionString);

            string query = "select * from employees where eid= '" + id + "'";

            SqlCommand cmd = new SqlCommand(query, s);
            s.Open();

            int check = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                check = 1;
            }
            if (check == 0)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("                        ** No such employee exists. **                     ");
            }
            else if (check == 1)
            {
                SqlConnection b = new SqlConnection(connectionString);
                string query1 = "delete from employees where eid= '" + id + "'";
                cmd = new SqlCommand(query1, b);
                b.Open();

                cmd.ExecuteNonQuery();
                b.Close();
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("                        ** Employee is deleted **                     ");
                check = 1;
            }
            s.Close();
        }

        public bool loginAdmin(adminBO obj)
        {

            SqlConnection s = new SqlConnection(connectionString);

            bool adminAuth = false;

            string query = "select * from admin where (adminName = '"+obj.Name+"')  and (password= '"  +obj.Password+ "') " ;

            SqlCommand cmd = new SqlCommand(query, s);
            s.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine("                         - - -Welcome Admin " + dr[1] + "- - -         ");
                adminAuth = true;
            }

            s.Close();
            return adminAuth;
        }
        public static int getEmployeeID()
        {
            int value = 0;
            SqlConnection s = new SqlConnection(connectionString);
            string query = "Select eid from employees";
            SqlCommand cmd = new SqlCommand(query, s);
            s.Open();

            SqlDataReader id = cmd.ExecuteReader();
            while (id.Read())
            {
                value = int.Parse(id[0].ToString());
            }
           // Console.WriteLine(value);
            return value;
        }
        public static int getUserID()
        {
            int value = 0;
            SqlConnection s = new SqlConnection(connectionString);
            string query = "Select uid from users";
            SqlCommand cmd = new SqlCommand(query, s);
            s.Open();

            SqlDataReader id = cmd.ExecuteReader();
            while (id.Read())
            {
                value = int.Parse(id[0].ToString());
            }
            // Console.WriteLine(value);
            return value;
        }
        public void editEmployee(employeeBO obj)
        {

            SqlConnection s = new SqlConnection(connectionString);

            string query = "select * from employees where eid= '" + obj.id + "'";

            SqlCommand cmd = new SqlCommand(query, s);
            s.Open();

            int check = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                check = 1;
            }
            if(check==0)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("                        ** No such employee exists. **                     ");
            }
            else if (check == 1)
            {
                SqlConnection b = new SqlConnection(connectionString);
                string query1 = "update employees set name= '" + obj.empName + "' , salary= '" + obj.empSalary + "', bonusRatio = '" + obj.empBonusRatio + "' , tax= '" + obj.empTax + "', designation= '" + obj.empDesignation + "' where eid= '" + obj.id + "' ";
                cmd = new SqlCommand(query1, b);
                b.Open();

                cmd.ExecuteNonQuery();
                b.Close();
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("                        ** New data is saved **                     ");
                check = 1;
            }
            s.Close();
        }
        public bool addEmployee(employeeBO obj)
        {
            bool addEmployee = false;
            int eidIncrement = getEmployeeID();
            eidIncrement++;

            SqlConnection s = new SqlConnection(connectionString);
            string query = "insert into employees (eid,name,salary,bonusRatio,tax,designation) Values ('" +eidIncrement+"','" +obj.empName+ "','" +obj.empSalary+ "', '" +obj.empBonusRatio+ "','" +obj.empTax+ "','" +obj.empDesignation+ "')";
            SqlCommand cmd = new SqlCommand(query, s);
            s.Open();

            int i = cmd.ExecuteNonQuery();

            if (i > 0)
            {
                addEmployee = true;
            }
            else
            {
                addEmployee = false;
            }
            return addEmployee;

        }
    }
}
