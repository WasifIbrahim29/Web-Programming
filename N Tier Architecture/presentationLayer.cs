using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using businessLogicLayer;
using adminBusinessObjects;
using employeeBusinessObjects;
using userBusinessObjects;

namespace presentationLayer
{
    public class input
    {
        private logicLayer bll = new logicLayer();
        private bool editEmployee()
        {
            int id = 0;
            bool wrongDesignation = false;
            string temp = "";
            int temp1 = 0;
            string employeeName = "", employeeDesignation = "";
            double employeeSalary = 0;
            Console.Write("                 Enter ID           :");
            temp = Console.ReadLine();
            Int32.TryParse(temp, out temp1);
            id = temp1;
            Console.Write("                 Enter Name         :");
            employeeName = Console.ReadLine();
            Console.Write("                 Enter Designation  :");
            employeeDesignation = Console.ReadLine();
            Console.Write("                 Enter Salary       :");
            temp = Console.ReadLine();
            Int32.TryParse(temp, out temp1);
            employeeSalary = Convert.ToDouble(temp1);
            employeeBO employeeBo = new employeeBO(id, employeeName, employeeSalary, employeeDesignation);
            wrongDesignation = bll.editEmployee(employeeBo);
            return wrongDesignation;
        }
        private bool addEmployee()
        {
            bool addEmployee = false;
            string temp = "";
            bool wrongDesignation = false;
            int choose = 0;
            int temp1 = 0;
            string employeeName = "", employeeDesignation = "";
            double employeeSalary = 0;
            Console.Write("                 Enter Name         :");
            employeeName = Console.ReadLine();
            Console.Write("                 Enter Designation  :");
            employeeDesignation = Console.ReadLine();
            Console.Write("                 Enter Salary       :");
            temp = Console.ReadLine();
            Int32.TryParse(temp, out temp1);
            employeeSalary = Convert.ToDouble(temp1);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("                 Press 1 to save the data.");
            Console.WriteLine("                 Press 2 to cancel.");
            Console.WriteLine("");
            Console.WriteLine("");
            int[] arr = { 1, 2 };
            Console.Write("        Enter choice: ");
            choose = getRightOption(arr);

            if (choose == 1)
            {
                employeeBO employeeBo = new employeeBO(employeeName, employeeSalary, employeeDesignation);
                wrongDesignation = bll.addEmployee(employeeBo);
            }
            else if (choose == 2)
            {
                addEmployee = false;
            }
            else
            {

            }
            return wrongDesignation;
        }
        private void deleteEmployee()
        {
            int id = 0;
            string temp = "";
            int temp1 = 0;
            Console.Write("                 Enter ID           :");
            temp = Console.ReadLine();
            Int32.TryParse(temp, out temp1);
            id = temp1;
            bll.deleteEmployee(id);
        }
        private void searchEmployee()
        {
            int id = 0;
            string temp = "";
            int temp1 = 0;
            Console.Write("                 Enter ID           :");
            temp = Console.ReadLine();
            Int32.TryParse(temp, out temp1);
            id = temp1;
            bll.searchEmployee(id);
        }
        private void EmployeeManagement()
        {
            int option = 0;
            logicLayer bll = new logicLayer();
            Console.WriteLine("                 Press 1 to Add an Employee.");
            Console.WriteLine("                 Press 2 to Edit an Employee.");
            Console.WriteLine("                 Press 3 to Delete an Employee.");
            Console.WriteLine("                 Press 4 to Search an Employee.");
            Console.WriteLine("                 Press 0 to log out.");
            Console.WriteLine("");
            Console.WriteLine("");
            int[] arr = { 1, 2, 3, 4, 0 };
            Console.Write("        Enter choice: ");
            option = getRightOption(arr);
            Console.WriteLine("");
            Console.WriteLine("");
            if (option == 1)
            {
                bool wrongDesignation = false;
                wrongDesignation=addEmployee();
                if (wrongDesignation == true)
                {
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("                        ** You have entered wrong designation **        ");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("        Kindly Try Again!!!                   ");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    EmployeeManagement();
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("                        ** Saved **                     ");
                }
            }
            else if (option == 2)
            {
                bool wrongDesignation = false;
                wrongDesignation = editEmployee();
                if (wrongDesignation == true)
                {
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("                        ** You have entered wrong designation **        ");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("        Kindly Try Again!!!                   ");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    EmployeeManagement();
                }
                Console.WriteLine("");
                Console.WriteLine("");
            }
            else if (option == 3)
            {
                deleteEmployee();
            }
            else if (option == 4)
            {
                searchEmployee();
            }
            else if(option==0)
            {
                start();
            }
        }
        private bool AdminAccountManagment()
        {
            string adminName = "", adminPassword = "";
            Console.Write("                 Enter Admin username: ");
            adminName = Console.ReadLine();
            Console.Write("                 Enter Admin password: ");
            adminPassword = Console.ReadLine();
            adminBO adminBo = new adminBO(adminName, adminPassword);
            logicLayer bll = new logicLayer();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            bool admin = bll.loginAdmin(adminBo);
            return admin;
        }
        private bool registerUser()
        {
            bool registered = false;
            string userName = "", userPassword = "";
            Console.Write("                 Enter username: ");
            userName = Console.ReadLine();
            Console.Write("                 Enter password: ");
            userPassword = Console.ReadLine();
            userBO userBo = new userBO(userName, userPassword);
            logicLayer bll = new logicLayer();
            registered = bll.registerUser(userBo);
            return registered;
        }
        private bool loginUser()
        {
            bool loginUser = false;
            string userName = "", userPassword = "";
            Console.Write("                 Enter username: ");
            userName = Console.ReadLine();
            Console.Write("                 Enter password: ");
            userPassword = Console.ReadLine();
            userBO userBo = new userBO(userName, userPassword);
            logicLayer bll = new logicLayer();
            loginUser = bll.loginUser(userBo);
            return loginUser;
        }
        private bool changeUserPassword(int passwordTry)
        {
            bool passwordChange = false;
            int id = 0;
            string temp = "";
            string password = "";
            string confirmPassword = "";
            int temp1 = 0;
            Console.Write("                 Enter ID                 :");
            temp = Console.ReadLine();
            Int32.TryParse(temp, out temp1);
            id = Convert.ToInt32(temp1);
            Console.Write("                 Enter password           :");
            password = Console.ReadLine();
            Console.Write("                 Enter password again     :");
            confirmPassword = Console.ReadLine();
            userBO obj = new userBO(id, confirmPassword);
            Console.WriteLine("");
            Console.WriteLine("");
            if (password == confirmPassword)
            {
                passwordChange = bll.changeUserPassword(obj);
            }
            else
            {
                passwordTry++;
                if (passwordTry == 3)
                {
                    Console.WriteLine("                         ** Kindly Login again now **               ");
                    start();
                }
                Console.WriteLine("                         ** Passwords not matched **               ");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.Write("        Kindly, Try again : ");
                Console.WriteLine("");
                Console.WriteLine("");
                changeUserPassword(passwordTry);
            }
            return passwordChange;
        }
        private int getRightOption(int[] arr)
        {
            int option = 0;
            int checkedAll = 0;
            try
            {
                option = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < arr.Length; i++)
                {
                    if (option != arr[i])
                    {
                        checkedAll++;
                    }
                }
                if (checkedAll == arr.Length)
                {
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("              * * * You've entered a wrong option. * * *        ");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.Write("        Kindly, Enter choice again : ");
                    return getRightOption(arr);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("              * * * You've entered a character. It is not allowed. * * *        ");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.Write("        Kindly, Enter choice again : ");
                return getRightOption(arr);
            }
            return option;
        }
        private void adminloggedin()
        {
            int option = 0;
            bool changePassword = false;
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("                 Press 1 for Employee Management.");
            Console.WriteLine("                 Press 2 to change password of Users.");
            Console.WriteLine("                 Press 0 to log out.");
            Console.WriteLine("");
            Console.WriteLine("");
            int[] arr1 = { 0, 1, 2 };
            Console.Write("        Enter choice: ");
            option = getRightOption(arr1);

            if (option == 1)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                EmployeeManagement();
            }
            else if (option == 2)
            {
                int passwordTry = 0;
                changePassword = changeUserPassword(passwordTry);
                if (changePassword == true)
                {
                    Console.WriteLine("                     ** Password Changed Successfully **");
                    adminControl();
                }
                else
                {
                    Console.WriteLine("                      ** Password didn't change. Try again!!! **");
                }

            }
            else if (option == 0)
            {
                start();
            }
            else
            {
                Console.WriteLine("                        ** Wrong Admin Details **             ");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("        Kindly Try Again!!!                   ");
                start();
            }
        }
        private void adminControl()
        {
            int option = 0;
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            bool adminVerified = AdminAccountManagment();
            if (adminVerified == true)
            {
                bool changePassword = false;
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("                 Press 1 for Employee Management.");
                Console.WriteLine("                 Press 2 to change password of Users.");
                Console.WriteLine("                 Press 0 to log out.");
                Console.WriteLine("");
                Console.WriteLine("");
                int[] arr1 = { 0, 1, 2 };
                Console.Write("        Enter choice: ");
                option = getRightOption(arr1);

                if (option == 1)
                {
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    EmployeeManagement();
                }
                else if (option == 2)
                {
                    int passwordTry = 0;
                    changePassword = changeUserPassword(passwordTry);
                    if (changePassword == true)
                    {
                        Console.WriteLine("                     ** Password Changed Successfully **");
                        adminloggedin();
                    }
                    else
                    {
                        Console.WriteLine("                      ** Password didn't change. Try again!!! **");
                    }

                }
                else if (option == 0)
                {
                    start();
                }
            }
            else
            {
                Console.WriteLine("                        ** Wrong Admin Details **             ");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("        Kindly Try Again!!!                   ");
                start();
            }
        }
        private void userControl()
        {
            int option = 0;
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("                 Press 1 to register a user.");
            Console.WriteLine("                 Press 2 to login a user");
            Console.WriteLine("                 Press 0 to go back to main menu.");
            Console.WriteLine("");
            Console.WriteLine("");
            int[] arr1 = { 0, 1, 2 };
            Console.Write("        Enter choice: ");
            option = getRightOption(arr1);
            Console.WriteLine("");
            Console.WriteLine("");
            if (option == 1)
            {
                bool registered = registerUser();
                Console.WriteLine("");
                Console.WriteLine("");
                if (registered == true)
                {
                    Console.WriteLine("                       ** User is registered successfully **           ");
                    userControl();
                }
                else
                {
                    Console.WriteLine("User is not registered. Try Again!!!");
                    userControl();
                }
            }
            else if (option == 2)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                bool userLogin = loginUser();
                if (userLogin == true)
                {
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("                 Press 1 for Employee Management.");
                    Console.WriteLine("                 Press 0 to log out.");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    int[] arr2 = { 0, 1 };
                    Console.Write("        Enter choice: ");
                    option = getRightOption(arr2);
                    Console.WriteLine("");
                    Console.WriteLine("");
                    if (option == 1)
                    {
                        EmployeeManagement();
                    }
                    else
                    {
                        start();
                    }
                }
                else
                {
                    Console.WriteLine("                 User couldn't be logged in successfully. Try Again!!!");
                    userControl();
                }
            }
            else
            {
                start();
            }
        }

        public void start()
        {
            int option = 0;
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("                 - - -Welcome to Employee Management System- - -        ");
            Console.WriteLine("");
            Console.WriteLine("                 Press 1 for Admin Account.");
            Console.WriteLine("                 Press 2 for User Account.");
            Console.WriteLine("                 Press 0 to Exit.");
            Console.WriteLine("");
            Console.WriteLine("");
            int [] arr = { 0, 1, 2 };
            Console.Write("        Enter choice: ");
            option = getRightOption(arr);
            if (option == 1)
            {
                adminControl();
            }
            else if (option == 2)
            {
                userControl();
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("                 - - -Program Terminated- - -                  ");
                Console.WriteLine("");
                Console.WriteLine("");
            }
            
        }
    }
}
