using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioPoo2
{
    public class Reserva
    {
        public Pessoa Hospede { get; set; }
        public Suite Suite { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public decimal CalcularValorTotal()
        {
            TimeSpan duracao = DataFim - DataInicio;
            decimal valorTotal = (decimal)duracao.TotalDays * Suite.ValorDiaria;

            if (duracao.TotalDays > 10)
            {
                valorTotal *= 0.9m;
            }

            return valorTotal;
        }
    }
}
