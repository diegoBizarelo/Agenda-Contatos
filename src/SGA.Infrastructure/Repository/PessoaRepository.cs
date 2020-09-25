using SGA.ApplicationCore.Interfaces.Repository;
using SGA.ApplicationCore.Model;
using SGA.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGA.Infrastructure.Repository
{
    public class PessoaRepository : EFRepository<Pessoa>, IPessoaRepository
    {

        public PessoaRepository(BaseContext dbContext) : base(dbContext)
        {

        }
    }
}
