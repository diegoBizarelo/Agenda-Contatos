using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGA.ApplicationCore.Model
{
    public class Pessoa
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Sobrenome { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Nascimento { get; set; }

        public int DiasAteProximoAniversario
        {
            get
            {
                return CalcDias();
            }
        }

        public string Parabens
        {
            get
            {
                return $"Parabéns, {this.Nome} {this.Sobrenome}, " +
                  $"pelos seus {DateTime.Now.Year - Nascimento.Year} anos. ";
            }
        }

        private int CalcDias()
        {
            DateTime aniversarioEsteAno = new DateTime(DateTime.Now.Year, Nascimento.Month, Nascimento.Day);
            TimeSpan intervalo = aniversarioEsteAno - DateTime.Now;

            if (intervalo.Days < 0)
            {
                aniversarioEsteAno = new DateTime(DateTime.Now.Year + 1, Nascimento.Month, Nascimento.Day);
                intervalo = aniversarioEsteAno - DateTime.Now;
            }
            else if (intervalo.Days == 0 && intervalo.Hours <= 0 &&
                       intervalo.Minutes <= 0 && intervalo.Seconds <= 0 &&
                       intervalo.Milliseconds <= 0)
            {
                return 0;
            }
            var dias = intervalo.Days + 1;
            return dias;
        }
    }
}
