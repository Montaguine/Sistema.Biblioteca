﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emprestimos
{
    public enum EstadoEmprestimo
    {
        Cancelado = 1,
        Aprovado = 2,
        AguardandoDevolucao = 3,
        Finalizado = 4,
        FinalizadoComMulta = 5
    }
}
