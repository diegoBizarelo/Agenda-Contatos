using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SGA.ApplicationCore.Model;

namespace SGA.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static void Initialize (PessoaContext context)
        {
            if (context.Pessoas.Any())
            {
                return;
            }

            var pessoas = new Pessoa[]
            {
                new Pessoa()
                {
                    Nome = "Quentin",
                    Sobrenome = "Tarantino",
                    Nascimento = DateTime.Parse("27/03/1963"),
                },
                new Pessoa
                {
                    Nome = "John",
                    Sobrenome = "Travolta",
                    Nascimento = DateTime.Parse("18/02/1954"),
                },
                new Pessoa()
                {
                    Nome = "Samuel",
                    Sobrenome = "L. Jackson",
                    Nascimento = DateTime.Parse("21/12/1948"),
                },
                new Pessoa()
                {
                    Nome = "Bruce",
                    Sobrenome = "Willis",
                    Nascimento = DateTime.Parse("19/03/1955"),
                },
                new Pessoa()
                {
                    Nome = "Uma",
                    Sobrenome = "Thurman",
                    Nascimento = DateTime.Parse("29/04/1970"),
                },
                new Pessoa()
                {
                    Nome = "Tim",
                    Sobrenome = "Roth",
                    Nascimento = DateTime.Parse("14/05/1961"),
                },
                new Pessoa()
                {
                    Nome = "Amanda",
                    Sobrenome = "Plummer",
                    Nascimento = DateTime.Parse("23/03/1957"),
                },
                new Pessoa()
                {
                    Nome = "Harvey",
                    Sobrenome = "Keitel",
                    Nascimento = DateTime.Parse("13/05/1939"),
                },
                new Pessoa()
                {
                    Nome = "Ving",
                    Sobrenome = "Rhames",
                    Nascimento = DateTime.Parse("12/05/1959"),
                },
                new Pessoa()
                {
                    Nome = "Eric",
                    Sobrenome = "Stoltz",
                    Nascimento = DateTime.Parse("30/09/1961"),
                },
                new Pessoa()
                {
                    Nome = "Christopher",
                    Sobrenome = "Walken",
                    Nascimento = DateTime.Parse("31/03/1943"),
                }
            };

            context.AddRange(pessoas);
            context.SaveChanges();
        }
    }
}
