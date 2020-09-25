using SGA.ApplicationCore.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SGA.ApplicationCore.Interfaces.Services
{
    public interface IPessoaService
    {
        Pessoa Adicionar(Pessoa pessoa);

        void Ataulizar(Pessoa pessoa);

        IEnumerable<Pessoa> ObterTodos();

        Pessoa ObterPorId(int id);

        IEnumerable<Pessoa> Buscar(Expression<Func<Pessoa, bool>> predicado);

        void Remover(Pessoa pessoa);
    }
}
