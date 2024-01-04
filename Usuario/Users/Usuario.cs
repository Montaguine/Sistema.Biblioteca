using Emprestimos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios.Enums;
using Livros;

namespace Usuarios.Users
{
    public abstract class Usuario
    {
        public string nome;
        public string sobrenome;
        public string email;
        public double multaTotal;
        public NivelAcesso nivelAcesso;
        public string? codigoDeAcesso;

        public abstract bool VerificarDisponibilidade(Livro livro);
        public abstract List<Emprestimo> ExibirHistorico(List<Emprestimo> emprestimos);
        public abstract List<Emprestimo> ListarReservas(List<Emprestimo> reservas);
        public abstract int LocalizarReserva(string? nomeLivro, int? idLivro);
        public abstract void CancelarReserva(int idEmprestimo);
        public abstract void DevolverLivro(int idEmprestimo, DateTime dataDevolucao);
    }
}
