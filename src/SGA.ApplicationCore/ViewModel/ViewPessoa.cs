using System;
using System.Collections.Generic;
using System.Text;

namespace SGA.ApplicationCore.ViewModel
{
    public class ViewPessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime Nascimento { get; set; }
        public int DiasAteProximoAniversario { get; set; }
        public string Parabens { get; set; }
        public string FullName { get; set; }
        
    }
}
