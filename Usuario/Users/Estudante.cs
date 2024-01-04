using Emprestimos;
using Livros;
using Livros.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios.Enums;

namespace Usuarios.Users
{
    internal class Estudante : Usuario
    {
        string matricula;
        public Estudante()
        {
            nivelAcesso = NivelAcesso.Estudante;
        }
        public override void CancelarReserva(int idReserva)
        {
            Reserva reserva = Reserva.LocalizarReserva(idReserva);
            reserva._estadoReserva = EstadoReserva.Cancelado;
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
            return emprestimos = emprestimos.FindAll(x => x.IdUsuario == matricula);
        }

        public override List<Emprestimo> ListarReservas(List<Emprestimo> reservas)
        {
            return reservas = reservas.FindAll(x => x.IdUsuario == matricula);
        }

        public override int LocalizarReserva(string? nomeLivro, int? idLivro)
        {
            return ControleDeReservas.Consultar(nomeLivro, idLivro);
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
                livro.requerente = matricula;
            }
        }
    }
}
