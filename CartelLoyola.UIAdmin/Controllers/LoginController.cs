using System;
using CartelLoyola.Domain;
using CartelLoyola.Service;
using CartelLoyola.Data;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;

namespace CartelLoyola.UIAdmin.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        CartelLoyolaContext _dbContext = new CartelLoyolaContext();

        public class LoginStatus
        {
            public bool Success { get; set; }
            public string Message { get; set; }
            public string Token { get; set; }
            public string Username { get; set; }
            public int UserId { get; set; }
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("[action]")]
        public JsonResult LoginUsuario([FromBody] Usuario b)
        {

            string hash;
            using (MD5 md5Hash = MD5.Create()) {
                hash = Utils.GetMd5Hash(md5Hash, b.Password);
            }

            var obj = _dbContext.Usuarios.Where(a => a.Username.Equals(b.Username) && a.Password.Equals(hash)).FirstOrDefault();
            LoginStatus status = new LoginStatus();
            
            if (obj != null)
            {
                status.Success = true;
                status.Message = "";
                status.Token = Guid.NewGuid().ToString();
                status.Username = b.Username;
                status.UserId = obj.Id;
                //HttpContext.Session.SetString(UserName, obj.Username.ToString());
            }
            else
            {
                status.Success = false;
                status.Message = "Login inválido";
                status.Token = "";
                status.Username = "";
                status.UserId = 0;
            }
            return Json(status);
        }

    }
}