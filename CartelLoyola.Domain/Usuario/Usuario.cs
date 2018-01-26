using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CartelLoyola.Domain
{
    public class Usuario : BaseModelo
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
