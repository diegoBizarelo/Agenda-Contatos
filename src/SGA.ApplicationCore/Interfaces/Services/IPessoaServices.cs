using SGA.ApplicationCore.Model;
using SGA.ApplicationCore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SGA.ApplicationCore.Interfaces.Services
{
    public interface IPessoaServices
    {
        ViewPessoa Adicionar(Pessoa pessoa);
        ViewPessoa Ataulizar(Pessoa pessoa);
        IEnumerable<ViewPessoa> ObterTodos();
        ViewPessoa ObterPorId(int id);
        IEnumerable<ViewPessoa> Buscar(string nome);
        void Remover(Pessoa pessoa);
        List<List<ViewPessoa>> AniversariantesOrdenados();
    }
}
