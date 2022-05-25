namespace Stefanini.Domain.Entities
{
    public class Pessoa : EntityBase
    {
        public string nome { get; set; }
        public string cpf { get; set; }
        public int id_cidade { get; set; }
        public int idade { get; set; }
    }
}
