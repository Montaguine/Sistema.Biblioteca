using Emprestimos;
using Livros.Enums;
using Livros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios.Enums;
using Usuarios.Users;

namespace Usuarios.Funcionarios
{
    public class Atendente : Funcionario
    {
        public int idAtendente;

        public void AtualizarCadastro(Usuario usuario, string? nome, string? sobrenome, string? email, NivelAcesso? nivelAcesso)
        {
            if (nome != null) usuario.nome = nome;
            if (sobrenome != null) usuario.sobrenome = sobrenome;
            if (email != null) usuario.email = email;
            if (nivelAcesso != null) usuario.nivelAcesso = (NivelAcesso)nivelAcesso;
        }

        public void AutorizarEmprestimo(Livro livro, Usuario usuario, int? idReserva = 0)
        {
            if (livro._estadoLivro == EstadoLivro.AguardandoAprovacao)
            {
                livro._estadoLivro = EstadoLivro.Emprestado;
                Emprestimo emprestimo = new Emprestimo();
                emprestimo.Id = Emprestimo.qtdEmprestimos + 1;
                emprestimo.IdLivro = livro.IdLivro;
                emprestimo.IdUsuario = usuario.codigoDeAcesso;
                emprestimo.DataEmprestimo = DateTime.Now;
                emprestimo.DataLimite = DateTime.Now.AddDays(7);
                emprestimo.EstadoEmprestimo = EstadoEmprestimo.AguardandoDevolucao;
                Emprestimo.Emprestimos.Add(emprestimo);
                if (idReserva != 0)
                {
                    Reserva.CancelarReserva((int)idReserva);
                }
            }
        }
    }
}
