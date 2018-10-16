using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace carros_2.models
{
    public class Agendamento
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Hora { get; set; }
        public string Modelo { get; set; }
        public decimal Preco { get; set; }

        public Agendamento(string nome, string telefone, string email, string modelo, decimal preco)
        {
            this.Nome = nome;
            this.Telefone = telefone;
            this.Email = email;
            this.Modelo = modelo;
            this.Preco = preco;
        }
    }
}
