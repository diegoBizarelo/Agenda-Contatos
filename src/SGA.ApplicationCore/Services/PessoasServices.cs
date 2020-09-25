using SGA.ApplicationCore.Interfaces.Repository;
using SGA.ApplicationCore.Interfaces.Services;
using SGA.ApplicationCore.Model;
using SGA.ApplicationCore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SGA.ApplicationCore.Services
{
    public class PessoasServices : IPessoaServices
    {
        private readonly IPessoaRepository _pessoaRepository;
        public PessoasServices(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }
        public ViewPessoa Adicionar(Pessoa pessoa)
        {
            return PessoaToViewPessoa(_pessoaRepository.Add(pessoa));
        }

        public ViewPessoa Ataulizar(Pessoa pessoa)
        {
            return PessoaToViewPessoa(_pessoaRepository.UpDate(pessoa));
        }

        public IEnumerable<ViewPessoa> Buscar(string nome)
        {
            var pessoas = _pessoaRepository.Search(p => (p.Nome.ToUpper()+p.Sobrenome.ToUpper()).Contains(nome.ToUpper()));
            return PessoaToViewPessoa(pessoas);
        }

        public ViewPessoa ObterPorId(int id)
        {
            return PessoaToViewPessoa(_pessoaRepository.GetById(id));
        }

        public IEnumerable<ViewPessoa> ObterTodos()
        {
            return PessoaToViewPessoa(_pessoaRepository.GetAll());
        }

        public void Remover(Pessoa pessoa)
        {
            _pessoaRepository.Remove(pessoa);
        }

        public List<List<ViewPessoa>> AniversariantesOrdenados()
        {
            var pessoasList = PessoaToViewPessoa(_pessoaRepository.GetAll().OrderBy(p => p.Nascimento).AsEnumerable());
            List<ViewPessoa> aniversariantesDoDia = new List<ViewPessoa>();
            List<ViewPessoa> amigosOrdenadosNascimento = new List<ViewPessoa>();
            List<List<ViewPessoa>> mergeList = new List<List<ViewPessoa>>();
            foreach (ViewPessoa p in pessoasList)
            {
                if (p.Nascimento.Day == DateTime.Now.Day
                    && p.Nascimento.Month == DateTime.Now.Month)
                {
                    aniversariantesDoDia.Add(p);
                }
                else
                {
                    amigosOrdenadosNascimento.Add(p);
                }
            }
            mergeList.Add(aniversariantesDoDia);
            mergeList.Add(amigosOrdenadosNascimento);
            return mergeList;
        }

        private ViewPessoa PessoaToViewPessoa(Pessoa pessoa)
        {
            ViewPessoa vp = new ViewPessoa
            {
                Id = pessoa.Id,
                Nome = pessoa.Nome,
                Sobrenome = pessoa.Sobrenome,
                Nascimento = pessoa.Nascimento,
                DiasAteProximoAniversario = pessoa.DiasAteProximoAniversario,
                Parabens = pessoa.Parabens
            };

            return vp;
        }

        private IEnumerable<ViewPessoa> PessoaToViewPessoa(IEnumerable<Pessoa> pessoas)
        {
            List<ViewPessoa> vpList = new List<ViewPessoa>();
            foreach (Pessoa p in pessoas)
            {
                vpList.Add(PessoaToViewPessoa(p));
            }
            return vpList;
        }
    }
}
