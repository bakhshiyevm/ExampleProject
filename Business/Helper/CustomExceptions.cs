using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helper
{
    public class PasswordException : Exception
    {
        public PasswordException() : base("Incorrect password!")
        {
        }
    }
    public class UsernameException : Exception
    {
        public UsernameException() : base("This username does not exist!")
        {
        }
    }
    public class UsernameExistsException : Exception
    {
        public UsernameExistsException() :base("Same username/email/phone is already signed up!")
        {

        }
    }
}
