using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emprestimos
{
    public class Reserva
    {
        private static int s_contadorReserva = 0;
        public int IdReserva { get; set; }
        public string IdUsuario;
        public string IdLivro;
        public DateTime _dataInicio;
        public DateTime _dataFim;
        public EstadoReserva _estadoReserva;

        public Reserva LocalizarReserva(int? idUsuario, int? idLivro)
        {
            if (nomeLivro != null)
            {
                foreach (Reserva reserva in Livro.Reservas)
                {
                    if (reserva._livro._titulo == nomeLivro)
                    {
                        return reserva;
                    }
                }
            }
            else if (idLivro != 0)
            {
                foreach (Reserva reserva in Livro.Reservas)
                {
                    if (reserva._livro.IdLivro == idLivro)
                    {
                        return reserva;
                    }
                }
            }
            return null;
        }
        public Reserva(Usuario usuario, Livro livro, DateTime dataInicio, DateTime dataFim)
        {
            IdReserva = ++s_contadorReserva;
            _usuario = usuario;
            _livro = livro;
            _dataInicio = dataInicio;
            _dataFim = dataFim;
        }

        public void MostrarDados()
        {
            Console.WriteLine($"Id da reserva: {IdReserva}\n"
                            + $"Usuário: {_usuario._nome}\n"
                            + $"Livro: {_livro._titulo}\n"
                            + $"Data de início: {_dataInicio.ToString()}\n"
                            + $"Data de fim: {_dataFim.ToString()}\n");
        }
    }
}
