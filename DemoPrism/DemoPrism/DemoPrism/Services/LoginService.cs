using DemoPrism.IServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DemoPrism.Services
{
    public class LoginService : ILoginService
    {
        public void Login()
        {
            Debug.WriteLine("Login Thành công!!!!!!!!!!!!");
        }
    }
}
