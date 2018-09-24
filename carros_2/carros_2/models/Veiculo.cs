using System.Collections.Generic;
using System.Linq;

namespace carros_2.models
{
    public class Veiculo //: INotifyPropertyChanged
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Fabricante { get; set; }
        public List<Acessorio> Acessorios { get; set; }
        public decimal ValorTotal
        {
            get
            {
                if(!this.Acessorios.Any(a => a.Ativo))
                    return this.Preco;
                else
                    return this.Preco + this.Acessorios.Where(a => a.Ativo).Sum(v => v.Valor);
            }
            set { this.ValorTotal = value; }
        }

        public string NomeCompleto { get
            {
                return this.Fabricante + " - " + this.Nome;
            }  }

        public Veiculo()
        {
            this.Acessorios = new ListagemAcessorios().Acessorios; 
        }
    }
}