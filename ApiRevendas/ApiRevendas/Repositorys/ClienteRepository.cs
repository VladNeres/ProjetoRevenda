using ApiRevenda.Interfaces;
using AutoMapper;
using CategoriaApi.Data;
using CategoriaApi.Model;
using RevendaApi.Data.Dto.ClienteDto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiRevenda.Repositorys
{
    public class ClienteRepository: IRepositoryCliente
    {
        private  DatabaseContext _context;
        public ClienteRepository( DatabaseContext context)
        {
            _context = context;
        }

        public void AdicionarCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void ExcluirCliente(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
        } 
        public void Salvar()
        {
            _context.SaveChanges();
        }

        public List<Cliente> PesquisarListaCliente()
        {
          return  _context.Clientes.ToList();
        }

        
        public Cliente RecuperaClientePorId(int id)
        {
            Cliente clienteId= _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
            return clienteId;
        }
    }
}
