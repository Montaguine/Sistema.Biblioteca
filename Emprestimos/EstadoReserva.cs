using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emprestimos
{
    public enum EstadoReserva
    {
        SemReserva = 0,
        Cancelado = 1,
        AguardandoAprovacao = 2,
        Aprovado = 3
    }
}
