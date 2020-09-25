using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SGA.ApplicationCore.Interfaces.Services;
using SGA.ApplicationCore.Model;
using SGA.ApplicationCore.ViewModel;
using SGA.Infrastructure.Data;


namespace SGA.UIWeb.Controllers
{
    public class PessoasController : Controller
    {
        private readonly IPessoaServices _pessoaService;

        public PessoasController(IPessoaServices context)
        {
            _pessoaService = context;
        }

        public IActionResult Index()
        {
            return View( _pessoaService.AniversariantesOrdenados());
        }
       
        public IActionResult Details(int id)
        {
            var pessoa = _pessoaService.ObterPorId(id);
            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Nome,Sobrenome,Nascimento")] Pessoa pessoa)
        {
            ViewPessoa p = null;
            if (ModelState.IsValid)
            {
                p = _pessoaService.Adicionar(pessoa);
                return RedirectToAction(nameof(Index));
            }
            return View(p);
        }
        
        public IActionResult Edit(int id)
        {
            var pessoa = _pessoaService.ObterPorId(id);
            if (pessoa == null)
            {
                return NotFound();
            }
            return View(pessoa);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Nome,Sobrenome,Nascimento")] Pessoa pessoa)
        {
            if (id != pessoa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _pessoaService.Ataulizar(pessoa);
                return RedirectToAction(nameof(Index));
            }
            return View(pessoa);
        }
        
        public IActionResult Delete(int id)
        {
            var pessoa = _pessoaService.ObterPorId(id);
            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Pessoa pessoa)
        {
            _pessoaService.Remover(pessoa);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult List()
        {
            return View(_pessoaService.ObterTodos());
        }

        [HttpPost]
        public IActionResult Search(string nome)
        {
            var pessoas = _pessoaService.Buscar(nome);

            if (String.IsNullOrEmpty(nome))
            {
                return View("Index", pessoas);
            }
                        
            return View(pessoas);
        }

    }
}
