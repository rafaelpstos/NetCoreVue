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
    public class ProdutoService
    {
        ProdutoRepository _ProdutoRepository;
        CartelLoyolaContext _dbContext = new CartelLoyolaContext();

        public ProdutoService()
        {
            _ProdutoRepository = new ProdutoRepository();
        }

        public void Salvar(Produto Produto)
        {
            _ProdutoRepository.Salvar(Produto);
        }

        public object ObterTodos()
        {
            return new ProdutoRepository().ObterTodos();
        }

    }
}