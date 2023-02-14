using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitTutorial.Model
{
    public class Login
    {
       
        //public string URL { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public Login(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
   
}
