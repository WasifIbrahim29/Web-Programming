using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace userBusinessObjects
{
    public class userBO
    {
        int uid;
        string username;
        string password;

        userBO()
        {

        }
        public userBO(string username,string password)
        {
            this.username = username;
            this.password = password;
        }
        public userBO(int id,string password)
        {
            this.uid = id;
            this.password = password;
        }
        public string name
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }
        public string psw
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
        public int id
        {
            get
            {
                return uid;
            }
            set
            {
                uid = value;
            }
        }
    }
}
