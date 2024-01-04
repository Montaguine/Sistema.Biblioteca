using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios.Enums;
using Usuarios.Users;
using Livros.Enums;
using Livros;
using Emprestimos;

namespace Usuarios.Funcionarios
{
    public class Funcionario : Usuario
    {
        public string codigoDeAcesso;
        public string senha;
        public string nome;
        public NivelAcesso acesso;

        public override bool VerificarDisponibilidade(Livro livro)
        {
            return livro._estadoLivro == EstadoLivro.Disponivel;
        }

        public override int LocalizarReserva(string? nomeLivro, int? idLivro)
        {
            return ControleDeReservas.Consultar(nomeLivro, idLivro);
        }

        public override void CancelarReserva(int idEmprestimo)
        {
            this.ListarReservas().Find(x => x.Id == idEmprestimo).EstadoEmprestimo = EstadoEmprestimo.Cancelado;
        }

        public override void DevolverLivro(int idEmprestimo, DateTime dataDevolucao)
        {
            Emprestimo emprestimo = Emprestimo.LocalizarEmprestimo(idEmprestimo);
            if (emprestimo.DataLimite > dataDevolucao)
            {
                emprestimo.EstadoEmprestimo = EstadoEmprestimo.Finalizado;
            }
            else
            {
                emprestimo.EstadoEmprestimo = EstadoEmprestimo.FinalizadoComMulta;
                this.multaTotal += SistemaBiblioteca.CalcularMulta(emprestimo.DataLimite, dataDevolucao);
            }
        }

        public override List<Emprestimo> ExibirHistorico(List<Emprestimo> emprestimos)
        {
            return emprestimos = emprestimos.FindAll(x => x.IdUsuario == this.codigoDeAcesso);
        }

        public List<Emprestimo> ListarReservasUsuario(List<Emprestimo> reservas, Usuario u)
        {
            return reservas = reservas.FindAll(x => x.IdUsuario == u.codigoDeAcesso);
        }

        public List<Emprestimo> ExibirHistoricoUsuario(List<Emprestimo> emprestimos, Usuario u)
        {
            return emprestimos = emprestimos.FindAll(x => x.IdUsuario == u.codigoDeAcesso);
        }

        public override List<Emprestimo> ListarReservas(List<Emprestimo> reservas)
        {
            return reservas = reservas.FindAll(x => x.IdUsuario == this.codigoDeAcesso);
        }

    }
}
