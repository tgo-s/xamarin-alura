using System;

namespace carXapi.model
{
    public class Agendamento
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Hora { get; set; }
        public Veiculo Veiculo { get; set; }
    }
}
