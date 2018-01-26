using System;
using CartelLoyola.Domain;
using CartelLoyola.Service;
using CartelLoyola.Data;
using System.Linq;
using System.Collections.Generic;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;

namespace CartelLoyola.UIAdmin.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        CartelLoyolaContext _dbContext = new CartelLoyolaContext();
        UsuarioService _usuarioService = new UsuarioService();

        [HttpPost("[action]")]
        public string SalvarUsuario(Usuario b)
        {

            var user = _dbContext.Usuarios.Where(a => a.Username.Equals(b.Username)).FirstOrDefault();

            if (user.Username == b.Username) {
                return "false";
            }

            using (MD5 md5Hash = MD5.Create()){
                Usuario usuario = new Usuario
                {
                    Nome = b.Nome,
                    Email = b.Email,
                    Username = b.Username,
                    Password = Utils.GetMd5Hash(md5Hash, b.Password),
                };

                _usuarioService.Salvar(usuario);
            }

            return "Usuario salvo";

            //_context.Add(b);
            //_context.SaveChanges();

            //return RedirectToAction("Usuario");
        }

        [HttpGet("[action]")]
        public object ObterTodosUsuarios()
        {
            return new UsuarioService().ObterTodos();
        }


    }
}