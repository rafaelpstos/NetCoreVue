using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartelLoyola.Domain
{
    public class Imagem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string ContentType { get; set; }
    }
}
