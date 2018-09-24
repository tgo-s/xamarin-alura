using System.Collections.Generic;

namespace carros_2.models
{
    public class ListagemAcessorios
    {
        public List<Acessorio> Acessorios { get; set; }
        public ListagemAcessorios()
        {
            this.Acessorios = new List<Acessorio>()
            {
                new Acessorio(){ Nome = "Turbo", Valor = 15000, Ativo=false },
                new Acessorio(){ Nome = "ECU", Valor = 10000, Ativo=false },
                new Acessorio(){ Nome = "Freios ABS", Valor = 7000, Ativo=false },
                new Acessorio(){ Nome = "Conjunto de Rodas 19\"", Valor = 12000, Ativo=false },
            };

        }
    }
}
