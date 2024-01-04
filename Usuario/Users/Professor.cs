using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios.Enums;
using Emprestimos;
using Livros;
using Livros.Enums;

namespace Usuarios.Users
{
    internal class Professor : Usuario
    {
        string idProfessor;
        string codigoDeAcesso;
        string senha;

        public Professor()
        {
            nivelAcesso = NivelAcesso.Professor;
        }
        public override void CancelarReserva(int idReserva)
        {
            this.ListarReservas().Find(x => x.Id == idReserva).estadoEmprestimo = EstadoEmprestimo.Cancelado;
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
                multaTotal += SistemaBiblioteca.CalcularMulta(emprestimo.DataLimite, dataDevolucao);
            }
        }

        public override List<Emprestimo> ExibirHistorico(List<Emprestimo> emprestimos)
        {
            return emprestimos.FindAll(x => x.IdUsuario == idProfessor);
        }

        public override List<Emprestimo> ListarReservas(List<Emprestimo> reservas)
        {
            return reservas.FindAll(x => x.IdUsuario == idProfessor);
        }

        public override int LocalizarReserva(string? nomeLivro, int? idLivro)
        {
            if (!string.IsNullOrEmpty(nomeLivro))
            {
                return Reserva.ConsultarPorNomeDoLivro(nomeLivro);
            }
            else if (idLivro.HasValue)
            {
                return Reserva.ConsultarPorIdDoLivro(idLivro.Value);
            }
            else
            {
                throw new ArgumentException("É necessário fornecer o nome do livro ou o ID do livro para realizar a busca.");
            }
        }


        public override bool VerificarDisponibilidade(Livro livro)
        {
            return livro._estadoLivro == EstadoLivro.Disponivel;
        }

        public void SolicitarLivro(int idLivro)
        {
            Livro livro = Livro.Consultar(idLivro);
            if (livro._estadoLivro == EstadoLivro.Disponivel)
            {
                livro._estadoLivro = EstadoLivro.AguardandoAprovacao;
                livro.requerente = idProfessor;
            }
        }
    }
}
