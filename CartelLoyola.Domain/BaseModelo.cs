using System;
using System.Collections.Generic;
using System.Text;

namespace CartelLoyola.Domain
{
    public class BaseModelo
    {
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
