using CartelLoyola.Domain;
using CartelLoyola.Repository;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CartelLoyola.Service
{
    public class LoginService
    {
        LoginRepository _loginRepository;

        public LoginService()
        {
            _loginRepository = new LoginRepository();
        }


    }
}
