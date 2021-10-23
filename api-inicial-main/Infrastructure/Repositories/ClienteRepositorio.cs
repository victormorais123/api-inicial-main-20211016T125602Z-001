using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UStart.Domain.Contracts.Repositories;
using UStart.Domain.Entities;
using UStart.Infrastructure.Context;

namespace UStart.Infrastructure.Repositories
{

    


    public class ClienteRepositorio 
    {
        private readonly UStartContext _context;

        public ClienteRepositorio(UStartContext context)
        {
            _context = context;
        }

        public ClienteRepositorio ConsultarPorId(Guid id)
        {
            return _context.Cliente.FirstOrDefault(g => g.Id == id);
        }

        public IEnumerable<ClienteRepositorio> Pesquisar(string pesquisa)
        {
            pesquisa = pesquisa != null ? pesquisa.ToLower() : string.Empty;

            return _context
            .Cliente
            .Where(x => x.nome.ToLower().Contains(pesquisa))
            .ToList();
        }

        public void Add(Cliente Cliente)
        {
            _context.Cliente.Add(Cliente);            
        }

        public void Update(Cliente Cliente)
        {
            _context.Cliente.Update(Cliente);
        }

        public void Delete(Cliente Cliente)
        {
            if (_context.Entry(Cliente).State == EntityState.Detached)
            {
                _context.Cliente.Attach(Cliente);
            }
            _context.Cliente.Remove(Cliente);
        }
    }
}