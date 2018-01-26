using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CartelLoyola.Domain
{

    public class Produto : BaseModelo
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string ImagemProduto { get; set; }
    }
}
