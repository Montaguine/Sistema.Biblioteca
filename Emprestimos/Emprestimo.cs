namespace Emprestimos
{
    public class Emprestimo
    {
        public static List<Emprestimo> Emprestimos = new List<Emprestimo>();
        public static int qtdEmprestimos = Emprestimos.Count;
        public int Id { get; set; }
        public int IdLivro { get; set; }
        public string IdUsuario { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataLimite { get; set; }
        public DateTime DataDevolucao { get; set; }
        public bool Devolvido { get; set; }
        public string Descricao { get; set; }
        public EstadoEmprestimo EstadoEmprestimo { get; set; }

        public static Emprestimo LocalizarEmprestimo(int id)
        {
            Emprestimo emprestimo = Emprestimos.Find(x => x.Id == id);
            if (emprestimo == null)
            {
                throw new Exception("Emprestimo não encontrado");
            }
            return emprestimo;
        }
    }
}
