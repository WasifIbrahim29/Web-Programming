using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace adminBusinessObjects
{
   
    public class adminBO
    {
        string userName;
        string password;

        public adminBO() 
        {

        }
        public adminBO(string n, string p)
        {
            this.userName = n;
            this.password = p;
        }
        public string Name
        {
            get
            {
                return userName;
            }
            set
            {
               userName = value;
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

    }
}
