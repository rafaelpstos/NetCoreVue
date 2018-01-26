using System;
using CartelLoyola.Domain;
using CartelLoyola.Service;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Drawing;

namespace CartelLoyola.UIAdmin.Controllers
{
    [Route("api/[controller]")]
    public class ProdutoController : Controller
    {
        ProdutoService _produtoService = new ProdutoService();

        public class ProdutoViewModel
        {
            public string Nome { get; set; }
            public string Descricao { get; set; }
            public IFormFile ImagemProduto { get; set; }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SalvarProduto(ProdutoViewModel b) {

            var produto = new Produto
            {
                Nome = b.Nome,
                Descricao = b.Descricao
            };

            using (var memoryStream = new MemoryStream())
            {
                await b.ImagemProduto.CopyToAsync(memoryStream);
                String s = Convert.ToBase64String(memoryStream.ToArray(), Base64FormattingOptions.InsertLineBreaks);
                produto.ImagemProduto = s;
            }

            _produtoService.Salvar(produto);

            return Ok(produto);
        }


    }
}