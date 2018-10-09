using System;
using System.Collections.Generic;
using System.Text;

namespace carros_2.models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string DataNascimento { get; set; }
        public string Telefone { get; set; }
    }
}
