using CartelLoyola.Domain;
using CartelLoyola.Repository;
using CartelLoyola.Data;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CartelLoyola.Service
{
    public class UsuarioService
    {
        UsuarioRepository _usuarioRepository;
        CartelLoyolaContext _dbContext = new CartelLoyolaContext();

        public UsuarioService() {
            _usuarioRepository = new UsuarioRepository();
        }

        public void Salvar(Usuario usuario)
        {
            _usuarioRepository.Salvar(usuario);
        }

        public object ObterTodos()
        {
            return new UsuarioRepository().ObterTodos();
        }

    }
}
