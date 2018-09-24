namespace carros_2.models
{
    public class Acessorio //: BindableObject
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public bool Ativo { get; set; }
        public string AcessorioValorado
        {
            get
            {
                return string.Format("{0} - {1}", this.Nome, this.Valor.ToString("C2"));
            }
        }
    }
}